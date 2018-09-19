using System.Collections;
using Engine.DataContainers;
using UnityEngine;

namespace Assets.Engine.DataContainers
{
    class ResourceCountDataContainer : MonoBehaviour, IDataContainer
    {
        public GameObject EffectPickUpBlock;
        
        private BlockCountDataContainer BlockCountDataContainer;

        public int CountResource { get; private set; }

        private void Start()
        {
            BlockCountDataContainer = GetComponent<BlockCountDataContainer>();
        }

        public void AddResource()
        {
            CountResource++;
            if (CountResource == 3)
            {
                CountResource = 0;
                BlockCountDataContainer.Count++;
                StartCoroutine(CreateEffect());
            }
        }

        private IEnumerator CreateEffect()
        {
            yield return new WaitForSeconds(0.7f);
            Instantiate(EffectPickUpBlock, transform.position, transform.rotation);            
        }
    }
}
