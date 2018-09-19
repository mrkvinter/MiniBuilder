using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Engine.PoolManager
{
    public class PoolManager : Singleton<PoolManager>
    {
        private readonly Dictionary<PoolTag, PoolObjects> pools = new Dictionary<PoolTag, PoolObjects>();

        public void AddPool(PoolObjects poolObjects)
        {
            if (pools.ContainsKey(poolObjects.PoolTag))
                pools.Remove(poolObjects.PoolTag);

            pools.Add(poolObjects.PoolTag, poolObjects);
        }

        public Transform Spawn(PoolTag poolTag, Vector3? position = null, Quaternion? rotation = null)
        {
            PoolObjects pool;
            return pools.TryGetValue(poolTag, out pool) ? pool.Spawn(position, rotation) : null;
        }

        public void Despawn(PoolTag poolTag, Transform poolObject)
        {
            PoolObjects pool;
            if (pools.TryGetValue(poolTag, out pool))
                pool.Despawn(poolObject);
        }
    }

    public enum PoolTag
    {
        Enemy,
        Resource,
        BuilderBlock
    }

    public class PoolObjects
    {
        private static Transform instancePoolTransform;
        private readonly Queue<Transform> poolObjects;
        private readonly HashSet<Transform> usingPoolObjects;
        public readonly PoolTag PoolTag;
        private readonly GameObject poolObject;
        private readonly Transform parent;

        private PoolObjects(PoolTag poolTag, GameObject poolObject, Queue<Transform> poolObjects, Transform parent)
        {
            this.PoolTag = poolTag;
            this.poolObject = poolObject;
            this.poolObjects = poolObjects;
            this.parent = parent;
            usingPoolObjects = new HashSet<Transform>();
        }

        private static Transform GetPoolTagTransform(PoolTag poolTag)
        {
            var rootPool = (GameObject.Find("[POOL]") ?? new GameObject("[POOL]")).transform;
            var pool = new GameObject(poolTag.ToString());
            pool.transform.parent = rootPool;
            return pool.transform;
        }

        public static PoolObjects Create(PoolTag poolTag, GameObject poolPrefab, int size = 0)
        {
            var parent = GetPoolTagTransform(poolTag);
            var list = SpawnPoolObjects(poolPrefab, size, parent);

            return new PoolObjects(poolTag, poolPrefab, list, parent);
        }

        private static Queue<Transform> SpawnPoolObjects(GameObject poolPrefab, int size, Transform parent)
        {
            var list = new Queue<Transform>();
            for (var i = 0; i < size; i++)
            {
                var go = Object.Instantiate(poolPrefab, parent);
                list.Enqueue(go.transform);
                go.SetActive(false);
            }

            return list;
        }

        public Transform Spawn(Vector3? position = null, Quaternion? rotation = null)
        {
            var go = DequeuePoolObject();

            RecoverPropertiesPoolObject(position, rotation, go);

            return go.transform;
        }

        private static void RecoverPropertiesPoolObject(Vector3? position, Quaternion? rotation, Transform go)
        {
            go.gameObject.SetActive(true);
            if (position != null)
                go.position = position.Value;
            if (rotation != null)
                go.rotation = rotation.Value;
        }

        private Transform DequeuePoolObject()
        {
            var go = poolObjects.Count > 0
                ? poolObjects.Dequeue()
                : Object.Instantiate(poolObject, parent).transform;
            usingPoolObjects.Add(go);
            return go;
        }

        public void Despawn(Transform transform)
        {
            var isRemove = usingPoolObjects.Remove(transform);
            if (isRemove) poolObjects.Enqueue(transform);
            transform.gameObject.SetActive(false);
        }
    }
}