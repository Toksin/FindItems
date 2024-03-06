using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{    
    [SerializeField] private Transform levelTransform;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private TextMeshProUGUI textF1;
    [SerializeField] private TextMeshProUGUI textHelp;
    [SerializeField] private GameObject pauseMenu;

    private float rotationSpeed = 6f;
    private bool isRotating = false;
    private bool isF1Pressed = false;
    private bool isEscapePressed = false;  

    private void OnEnable()
    {
        gameInput.OnEnvironmentMoved += GameInput_OnEnvironmentMoved;
        gameInput.OnMenuActivate += GameInput_OnMenuActivate;
    }

    private void OnDisable()
    {
        gameInput.OnEnvironmentMoved -= GameInput_OnEnvironmentMoved;
        gameInput.OnMenuActivate -= GameInput_OnMenuActivate;
    }

    private void GameInput_OnMenuActivate(object sender, GameInput.OnMenuActivateEventArgs e)
    {     
        if (e.control.name.ToString() == "f1" && !isF1Pressed)
        {
            textF1.enabled = false;
            textHelp.enabled = true;
            isF1Pressed = true;
        }
        else if(e.control.name.ToString() == "f1" && isF1Pressed)
        {
            textF1.enabled = true;
            textHelp.enabled = false;
            isF1Pressed = false;
        }
        if (e.control.name.ToString() == "escape" && !isEscapePressed)
        {
            pauseMenu.SetActive(true);
            isEscapePressed = true;
        }
        else if (e.control.name.ToString() == "escape" && isEscapePressed)
        {
            pauseMenu.SetActive(false);
            isEscapePressed = false;
        }
    }

    private void GameInput_OnEnvironmentMoved(object sender, GameInput.OnEnvironmentMovedEventArgs e)
    {
        if (!CutSceneActiveController.Instance.IsCutsceneActive())
        {
            if (!isRotating && e.movementVector.x > 0)
            {
                StartCoroutine(RotateLevel(Vector3.up, 90f, 1f / rotationSpeed));
            }
            else if (!isRotating && e.movementVector.x < 0)
            {
                StartCoroutine(RotateLevel(Vector3.up, -90f, 1f / rotationSpeed));
            }
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
