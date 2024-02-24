using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    [SerializeField] private CameraSystem cameraSystem;
    [SerializeField] private float zoomInSpeed = 1f; // Скорость для ZoomIn
    [SerializeField] private float zoomOutSpeed = 2f; // Скорость для ZoomOut
    private RectTransform rectTransform; // Use RectTransform for size changes
    private Vector3 originalSize; // Store the original size
    private bool isZoom = false;

    private Vector3 bigSize = new Vector3 (0, 0, 0);

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Use RectTransform for size changes
        originalSize = rectTransform.localScale; // Store the original size

        cameraSystem.ZoomIn += CameraSystem_ZoomIn;
        cameraSystem.ZoomOut += CameraSystem_ZoomOut;
    }

    private void CameraSystem_ZoomOut(object sender, System.EventArgs e)
    {
        if (!isZoom)
        {
            isZoom = true;
            StartCoroutine(ChangeSizeCoroutine(new Vector3(151.46f, 172.2247f, 279.735f), zoomOutSpeed));
            Debug.Log("ZoomOut");
        }
    }

    private void CameraSystem_ZoomIn(object sender, System.EventArgs e)
    {
        if (isZoom)
        {
            isZoom = false;
            StartCoroutine(ChangeSizeCoroutine(new Vector3(6.2f, 7.05f, 11.45092f), zoomInSpeed));
            Debug.Log("ZoomIn");
        }
    }

    IEnumerator ChangeSizeCoroutine(Vector3 targetSize, float speed)
    {
        Vector3 startSize = rectTransform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < speed)
        {
            Vector3 newSize = Vector3.Lerp(startSize, targetSize, elapsedTime / speed);
            rectTransform.localScale = newSize;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.localScale = targetSize;
    }
}
