using Engine.PoolManager;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    public GameObject AfterDestroyCreate;


    public void Destroy()
    {
        if (AfterDestroyCreate != null)
        {
            Instantiate(AfterDestroyCreate, transform.position, transform.rotation);
            for (var i = 0; i < 3; i++)
                PoolManager.Instance.Spawn(PoolTag.Resource, transform.position + Vector3.right * 0.1f * i);
        }

        PoolManager.Instance.Despawn(PoolTag.BuilderBlock, gameObject.transform);

        
    }
}