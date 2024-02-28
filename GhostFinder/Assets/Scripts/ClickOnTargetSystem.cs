using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnTargetSystem : MonoBehaviour
{
    public static ClickOnTargetSystem Instance { get; private set; }
    [SerializeField] private Camera camera;    
    public event EventHandler OnClick;

    private const string TARGET_TAG = "Target";

    private void Awake()
    {
        Instance = this;       
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.tag == TARGET_TAG)
                {
                    OnClick?.Invoke(this, EventArgs.Empty);                    
                }
            }
        }
    }  
}
