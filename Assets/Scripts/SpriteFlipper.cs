using Engine.DataContainers;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private VelocityMotionDataContainer velocityMotionDataContainer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        velocityMotionDataContainer = GetComponent<VelocityMotionDataContainer>();
    }

    private void FixedUpdate()
    {
        if (velocityMotionDataContainer.Velocity.x < 0 && !spriteRenderer.flipX)
            spriteRenderer.flipX = true;
        else if (velocityMotionDataContainer.Velocity.x > 0 && spriteRenderer.flipX) spriteRenderer.flipX = false;
    }
}