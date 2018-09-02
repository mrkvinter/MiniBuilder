using Engine.DataContainers;
using UnityEngine;

public class AnimatorPlayerSetter : MonoBehaviour
{
    private Animator animator;
    private GroundedDataContainer groundedDataContainer;
    private VelocityMotionDataContainer velocityMotionDataContainer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        velocityMotionDataContainer = GetComponent<VelocityMotionDataContainer>();
        groundedDataContainer = GetComponent<GroundedDataContainer>();
    }

    private void FixedUpdate()
    {
        animator.SetBool("Grounded", groundedDataContainer.Grounded);
        animator.SetFloat("VelocityX", Mathf.Abs(velocityMotionDataContainer.Velocity.x));
        animator.SetFloat("VelocityY", velocityMotionDataContainer.Velocity.y);
    }
}