using System;
using System.Collections.Generic;
using Engine.DataContainers;
using UnityEngine;

namespace Engine
{
    public class DataContainerController : MonoBehaviour
    {
        private Dictionary<Type, IDataContainer> dataContainers;
        public List<IDataContainer> DataContainers;

        private void Start()
        {
            dataContainers = new Dictionary<Type, IDataContainer>();
            foreach (var dataContainer in DataContainers)
                dataContainers.Add(dataContainer.GetType(), dataContainer);
        }

        public T GetData<T>()
            where T : class, IDataContainer
        {
            return dataContainers[typeof(T)] as T;
        }
    }
}