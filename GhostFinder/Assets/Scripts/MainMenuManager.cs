using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public event EventHandler NewGameCassetteActivate;
    public event EventHandler LoadCassetteActivate;
    public event EventHandler OptionCassetteActivate;

    [SerializeField] private Animator NewGameCassetteAnimator;
    [SerializeField] private Animator OptionCassetteAnimator;
    [SerializeField] private Animator LoadingCassetteAnimator;

    [SerializeField] private Outline NewGameCassetteOutlineScript;
    [SerializeField] private Outline OptionCassetteOutlineScript;   
    [SerializeField] private Outline LoadingCassetteOutlineScript;
    [SerializeField] private Outline DoorOutlineScript;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {       
            if (Physics.Raycast(ray, out hit))
            {               
                if (hit.collider.CompareTag("NewGame"))
                {
                    NewGameCassetteActivate?.Invoke(this, EventArgs.Empty);
                    NewGameCassetteAnimator.SetTrigger("ActivateCassette");
                    
                }
                else if (hit.collider.CompareTag("Option"))
                {
                    OptionCassetteActivate?.Invoke(this, EventArgs.Empty);
                    OptionCassetteAnimator.SetTrigger("ActivateCassette");
                    OptionCassetteOutlineScript.enabled = true;
                }
                else if (hit.collider.CompareTag("Loading"))
                {
                    LoadCassetteActivate?.Invoke(this, EventArgs.Empty);
                    LoadingCassetteAnimator.SetTrigger("ActivateCassette");
                    LoadingCassetteOutlineScript.enabled = true;
                }
                else if (hit.collider.CompareTag("Door"))
                {                   
                    DoorOutlineScript.enabled = true;
                }
            }         
          
        }

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("NewGame"))
            {
                NewGameCassetteOutlineScript.enabled = true;
            }
            else { NewGameCassetteOutlineScript.enabled = false; }
            
            if (hit.collider.CompareTag("Option")) 
            { 
                OptionCassetteOutlineScript.enabled = true; 
            }
            else { OptionCassetteOutlineScript.enabled = false; }
            
            if (hit.collider.CompareTag("Loading"))
            {              
                LoadingCassetteOutlineScript.enabled = true;
            }
            else { LoadingCassetteOutlineScript.enabled = false; }
            
            if (hit.collider.CompareTag("Door"))
            {
                DoorOutlineScript.enabled = true;
            }
            else { DoorOutlineScript.enabled = false; }
        }
        else
        {
            NewGameCassetteOutlineScript.enabled = false;
            OptionCassetteOutlineScript.enabled = false;
            LoadingCassetteOutlineScript.enabled = false;
            DoorOutlineScript.enabled = false;
        }
       

    }
}
