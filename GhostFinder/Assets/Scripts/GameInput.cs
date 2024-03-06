using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler<OnEnvironmentMovedEventArgs> OnEnvironmentMoved;
    public event EventHandler<OnMenuActivateEventArgs> OnMenuActivate;

    private PlayerInputActions playerinputActions;

    public class OnEnvironmentMovedEventArgs : EventArgs
    {
        public Vector2 movementVector;       
    }
    public class OnMenuActivateEventArgs : EventArgs
    {
        public InputControl control;
    }

    private void Awake()
    {
        Instance = this;
        playerinputActions = new PlayerInputActions();
        playerinputActions.Player2D.Enable();

        playerinputActions.Player2D.MoveEnvironment.performed += MoveEnvironment_performed;
        playerinputActions.Player2D.Menu.performed += Menu_performed;        

    }

    private void Menu_performed(InputAction.CallbackContext obj)
    {       
        InputControl control = obj.control;
        
        OnMenuActivate?.Invoke(this, new OnMenuActivateEventArgs 
        {
            control = control
        });  
    }

    private void MoveEnvironment_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2 movement = obj.ReadValue<Vector2>();     

        OnEnvironmentMoved?.Invoke(this, new OnEnvironmentMovedEventArgs
        {          
            movementVector = movement
        }); 
    } 
}
