using System;
using Cinemachine;
using UnityEngine;

public class CameraSynchronizer : MonoBehaviour
{
    private Camera camera;
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    private float previousSize;

    private void Start()
    {
        camera = GetComponent<Camera>();
        UpdateSize();
    }

    private void Update()
    {
        if (Math.Abs(camera.orthographicSize - previousSize) > float.Epsilon) UpdateSize();
    }

    private void UpdateSize()
    {
        if (CinemachineVirtualCamera != null)
        {
            CinemachineVirtualCamera.m_Lens.OrthographicSize = camera.orthographicSize;
            previousSize = camera.orthographicSize;
        }
    }
}