using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnTargetSystem : MonoBehaviour
{
    [SerializeField] private Camera camera;

    private const string TARGETTAG = "Target";

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.tag == TARGETTAG)
                {
                    Debug.Log("Yes");
                }
            }
        }
    }
}
