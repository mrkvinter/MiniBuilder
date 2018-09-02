using Engine.DataContainers;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    public float ForceJump;
    public float Velocity;

    private GroundedDataContainer groundedDataContainer;
    private VelocityMotionDataContainer velocityMotionDataContainer;
    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityMotionDataContainer = GetComponent<VelocityMotionDataContainer>();
        groundedDataContainer = GetComponent<GroundedDataContainer>();
    }


    private void FixedUpdate()
    {
        var horizontalVelocity = Input.GetAxis("Horizontal") * Velocity;
        var verticalVelocity = rigidbody2D.velocity.y;

        if (groundedDataContainer.Grounded && Input.GetButtonDown("Jump"))
            verticalVelocity = ForceJump;

        velocityMotionDataContainer.Velocity = new Vector2(horizontalVelocity, verticalVelocity);

        rigidbody2D.velocity = velocityMotionDataContainer.Velocity;
    }
}