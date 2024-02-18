using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler<OnEnvironmentMovedEventArgs> OnEnvironmentMoved;

    private PlayerInputActions playerinputActions;

    public class OnEnvironmentMovedEventArgs : EventArgs
    {
        public Vector2 movementVector;
       
    }
    private void Awake()
    {
        playerinputActions = new PlayerInputActions();
        playerinputActions.Player2D.Enable();

        playerinputActions.Player2D.MoveEnvironment.performed += MoveEnvironment_performed;
        
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
