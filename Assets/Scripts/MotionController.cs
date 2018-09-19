using System;
using System.Collections;
using Engine.DataContainers;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    public float ForceJump;

    private GroundedDataContainer groundedDataContainer;
    private new Rigidbody2D rigidbody2D;
    public float TimeWait;
    public float Velocity;
    public float Angular;
    private VelocityMotionDataContainer velocityMotionDataContainer;
    public AudioClip SoundJump;
    private AudioSource audioSource;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityMotionDataContainer = GetComponent<VelocityMotionDataContainer>();
        groundedDataContainer = GetComponent<GroundedDataContainer>();
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        float horizontalVelocity;
        var axis = Input.GetAxis("Horizontal");
        if (!groundedDataContainer.Grounded && Math.Abs(axis) < float.Epsilon)
            horizontalVelocity = velocityMotionDataContainer.Velocity.x;
        else
        {
            if (groundedDataContainer.Grounded)
                horizontalVelocity = axis * Velocity;
            else
                horizontalVelocity =
                    velocityMotionDataContainer.Velocity.x + axis * Velocity * Angular * Time.deltaTime;
        }

        if (Mathf.Abs(horizontalVelocity) > Velocity)
            horizontalVelocity = Velocity * Mathf.Sign(horizontalVelocity);
        var verticalVelocity = rigidbody2D.velocity.y;
        
        //if (!groundedDataContainer.Grounded)
        //    horizontalVelocity = velocityMotionDataContainer.Velocity.x + horizontalVelocity * Angular * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
            StartCoroutine(TryStart());

        velocityMotionDataContainer.Velocity = new Vector2(horizontalVelocity, verticalVelocity);

        rigidbody2D.velocity = velocityMotionDataContainer.Velocity;
    }

    private IEnumerator TryStart()
    {
        var t = 0.0f;
        while (t <= 0.2f)
        {
            if (groundedDataContainer.Grounded && Input.GetButton("Jump"))
            {
                audioSource.PlayOneShot(SoundJump);
                StartCoroutine(TryJump());
                yield break;
            }

            yield return new WaitForFixedUpdate();
            t += Time.fixedDeltaTime;
        }
    }

    private IEnumerator TryJump()
    {
        var t = 0.0f;
        while (t <= TimeWait)
        {
            if (Input.GetButton("Jump"))
            {
                Debug.Log("JUMP!");
                velocityMotionDataContainer.Velocity = new Vector2(velocityMotionDataContainer.Velocity.x, ForceJump);
                rigidbody2D.velocity = velocityMotionDataContainer.Velocity;
            }

            yield return new WaitForFixedUpdate();
            t += Time.fixedDeltaTime;
        }
    }
}