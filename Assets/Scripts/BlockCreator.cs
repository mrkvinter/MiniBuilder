using Engine.DataContainers;
using Engine.PoolManager;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    public AudioClip BlockCreateSound;
    
    
    private BlockCountDataContainer blockCount;
    private AudioSource audioSource;
    
    private void Start()
    {
        blockCount = GetComponent<BlockCountDataContainer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (blockCount.Count > 0 && Input.GetButtonDown("Use"))
        {
            audioSource.PlayOneShot(BlockCreateSound);
            PoolManager.Instance.Spawn(PoolTag.BuilderBlock, transform.position + Vector3.down, transform.rotation);
            blockCount.Count--;
        }
    }
}