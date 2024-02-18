using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSystem : MonoBehaviour
{
    private bool zoomIn = false;


    [SerializeField] private CinemachineVirtualCamera defaultCinemachineVirtualCamera;
    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            zoomIn = !zoomIn;            
        }

        if (zoomIn)
        {
            defaultCinemachineVirtualCamera.Priority = 1;
        }
        else
        {
            defaultCinemachineVirtualCamera.Priority = 10;
        }
    }
}
