using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private const string OPTION_BOOL_PARAMETR = "Deactivate";
    public static MainMenuManager Instance;

    private void Awake()
    {
        Instance = this; 
    }

    public event EventHandler NewGameCassetteActivate;
    public event EventHandler LoadCassetteActivate;
    public event EventHandler OptionCassetteActivate;
    public event EventHandler SoundActivate;
    public event EventHandler SoundInsertCassette;

    [SerializeField] private Animator newGameCassetteAnimator;
    [SerializeField] private Animator optionCassetteAnimator;
    [SerializeField] private Animator loadingCassetteAnimator;

    [SerializeField] private Outline newGameCassetteOutlineScript;
    [SerializeField] private Outline optionCassetteOutlineScript;   
    [SerializeField] private Outline loadingCassetteOutlineScript;
    [SerializeField] private Outline doorOutlineScript;

    private bool isSoundActivate = false;

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
                    newGameCassetteAnimator.SetTrigger("ActivateCassette");
                    SoundInsertCassette?.Invoke(this, EventArgs.Empty);
                }
                else if (hit.collider.CompareTag("Option"))
                {                   
                    optionCassetteAnimator.SetBool(OPTION_BOOL_PARAMETR, false);
                    OptionCassetteActivate?.Invoke(this, EventArgs.Empty);
                    optionCassetteAnimator.SetTrigger("ActivateCassette");
                    optionCassetteOutlineScript.enabled = true;
                    SoundInsertCassette?.Invoke(this, EventArgs.Empty);
                }
                else if (hit.collider.CompareTag("Loading"))
                {                  
                    LoadCassetteActivate?.Invoke(this, EventArgs.Empty);
                    loadingCassetteAnimator.SetTrigger("ActivateCassette");
                    loadingCassetteOutlineScript.enabled = true;
                    SoundInsertCassette?.Invoke(this, EventArgs.Empty);
                }
                else if (hit.collider.CompareTag("Door"))
                {                    
                    doorOutlineScript.enabled = true;
                }
            }         
          
        }     

        if(Physics.Raycast(ray, out hit))
        {
            if ((hit.collider.CompareTag("NewGame") || hit.collider.CompareTag("Option") || hit.collider.CompareTag("Loading") || hit.collider.CompareTag("Door")) && !isSoundActivate)
            {
                SoundActivate?.Invoke(this, EventArgs.Empty);
                isSoundActivate = true;
            }         

            if (hit.collider.CompareTag("NewGame"))
            {              
                newGameCassetteOutlineScript.enabled = true;            
            }
            else 
            { 
                newGameCassetteOutlineScript.enabled = false;               
            }
            
            if (hit.collider.CompareTag("Option")) 
            {               
                optionCassetteOutlineScript.enabled = true;               
            }
            else { optionCassetteOutlineScript.enabled = false; }
            
            if (hit.collider.CompareTag("Loading"))
            {               
                loadingCassetteOutlineScript.enabled = true;             
            }
            else 
            { 
                loadingCassetteOutlineScript.enabled = false;               
            }
            
            if (hit.collider.CompareTag("Door"))
            {               
                doorOutlineScript.enabled = true;               
            }
            else { doorOutlineScript.enabled = false; }
        }
        else
        {
            isSoundActivate = false;
            newGameCassetteOutlineScript.enabled = false;
            optionCassetteOutlineScript.enabled = false;
            loadingCassetteOutlineScript.enabled = false;
            doorOutlineScript.enabled = false;            
        }
       

    }

   
}
