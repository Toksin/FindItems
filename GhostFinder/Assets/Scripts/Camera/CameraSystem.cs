using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraSystem : MonoBehaviour
{
    private bool zoomIn = false;
    public event EventHandler ZoomIn;
    public event EventHandler ZoomOut; 

    [SerializeField] private CinemachineVirtualCamera defaultCinemachineVirtualCamera;
    private void Update()
    {   
        if (!CutSceneActiveController.Instance.IsCutsceneActive())
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                zoomIn = !zoomIn;

                if (zoomIn)
                {
                    defaultCinemachineVirtualCamera.Priority = 1;
                    ZoomIn?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    defaultCinemachineVirtualCamera.Priority = 10;
                    ZoomOut?.Invoke(this, EventArgs.Empty);
                }
            }
        }       
    }
}
