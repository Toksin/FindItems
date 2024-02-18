using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OldCameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera defaultCinemachineVirtualCamera;

    private float targetFieldOfView = 50f;
    [SerializeField] private float fieldOfViewMax = 50f;
    [SerializeField] private float fieldOfViewMin = 5f;
    private bool zoomIn = false;
    private bool isZooming = false;

    private void Update()
    {
        if (!isZooming && Mouse.current.rightButton.wasPressedThisFrame)
        {
            StartCoroutine(HandleCameraZoomCoroutine());
        }

    }



    private IEnumerator HandleCameraZoomCoroutine()
    {
        isZooming = true;
        float duration = 3f; // ����������������� ����

        float startTime = Time.time;
        float elapsedTime = 0f;

        // ������������� targetFieldOfView ���� ��� ����� ������ � ����
        float initialFieldOfView = defaultCinemachineVirtualCamera.m_Lens.FieldOfView;
        targetFieldOfView = zoomIn ? fieldOfViewMax : fieldOfViewMin;

        while (elapsedTime < duration)
        {
            elapsedTime = Time.time - startTime;

            // ��������� ���
            defaultCinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(initialFieldOfView, targetFieldOfView, elapsedTime / duration);

            yield return null;
        }

        // ����� ���������� ��������, ������ ����������� ����
        zoomIn = !zoomIn;
        isZooming = false;
    }

}
