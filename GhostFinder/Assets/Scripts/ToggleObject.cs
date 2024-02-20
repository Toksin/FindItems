using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectForToggle;
    private bool isObjectActivate = true;
    private float timer = 0f;
    [SerializeField]private float toggleInterval = 3f;
   
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= toggleInterval)
        {
            ToggleObjectState();
            timer = 0f;
        }      
    }

    private void ToggleObjectState()
    {
        isObjectActivate = !isObjectActivate;
        gameObjectForToggle.SetActive(isObjectActivate);        
    }
}
