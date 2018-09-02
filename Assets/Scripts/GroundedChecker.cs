using Engine.DataContainers;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
    public LayerMask FloorMask;
    public Transform FootPosition;

    private GroundedDataContainer groundedDataContainer;
    public float RadiusFloorCircleCheck;

    private void Start()
    {
        groundedDataContainer = GetComponent<GroundedDataContainer>();
    }

    private void FixedUpdate()
    {
        groundedDataContainer.Grounded =
            Physics2D.OverlapCircle(FootPosition.position, RadiusFloorCircleCheck, FloorMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(FootPosition.position, RadiusFloorCircleCheck);
    }
}