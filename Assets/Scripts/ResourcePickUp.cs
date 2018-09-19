using Assets.Engine.DataContainers;
using Engine.PoolManager;
using UnityEngine;

public class ResourcePickUp : MonoBehaviour
{
    public LayerMask LayerMask;
    public GameObject Effect;

    private Transform parent;

    private void Start()
    {
        parent = transform.parent;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & LayerMask) != 0)
        {
            other.GetComponent<ResourceCountDataContainer>().AddResource();
            PoolManager.Instance.Despawn(PoolTag.Resource, parent);
            Instantiate(Effect, transform.position, transform.rotation);
        }
    }
}