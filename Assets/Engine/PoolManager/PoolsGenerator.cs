using System;
using Engine.PoolManager;
using UnityEngine;

public class PoolsGenerator : MonoBehaviour
{
    public PoolInformation[] PoolInformations;
    
    private void Start()
    {
        for (var i = 0; i < PoolInformations.Length; i++)
        {
            var poolInfo = PoolInformations[i];
            PoolManager.Instance.AddPool(PoolObjects.Create(poolInfo.PoolTag, poolInfo.PoolObject, poolInfo.Size));
        }
    }
}

[Serializable]
public class PoolInformation
{
    public PoolTag PoolTag;
    public GameObject PoolObject;
    public int Size;
}