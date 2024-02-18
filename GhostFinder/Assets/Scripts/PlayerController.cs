using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    [SerializeField] private Transform levelTransform;
    [SerializeField] private GameInput gameInput;

    private float rotationSpeed = 6f;
    private bool isRotating = false;

    private void Start()
    {
        gameInput.OnEnvironmentMoved += GameInput_OnEnvironmentMoved;
    }

    private void GameInput_OnEnvironmentMoved(object sender, GameInput.OnEnvironmentMovedEventArgs e)
    {       
        if(!isRotating && e.movementVector.x > 0) 
        {
            StartCoroutine(RotateLevel(Vector3.up, 90f, 1f / rotationSpeed));
        }
        else if(!isRotating && e.movementVector.x < 0)
        {
            StartCoroutine(RotateLevel(Vector3.up, -90f, 1f / rotationSpeed));
        }
        
    }

    private IEnumerator RotateLevel(Vector3 axis, float angle, float duration)
    {
        isRotating = true;

        Quaternion fromRotation = levelTransform.rotation;
        Quaternion toRotation = Quaternion.Euler(axis * angle) * levelTransform.rotation;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            levelTransform.rotation = Quaternion.Slerp(fromRotation, toRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        levelTransform.rotation = toRotation;
        isRotating = false;
    }

}
