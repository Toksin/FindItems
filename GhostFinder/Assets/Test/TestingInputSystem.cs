using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody sphereRigidbody;
    private PlayerInputActions playerinputActions;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        sphereRigidbody = GetComponent<Rigidbody>();      
        playerinputActions = new PlayerInputActions();

        playerinputActions.Player3D.Enable();
        playerinputActions.Player3D.Jump.performed += Jump;
        playerinputActions.Player3D.Movement.performed += Movement_performed;
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerinputActions.Player3D.Movement.ReadValue<Vector2>();
        float speed = 2.0f;
        sphereRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump");
        }       
    }
    
}
