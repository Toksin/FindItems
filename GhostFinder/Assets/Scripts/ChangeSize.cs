using System.Collections;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    [SerializeField] private CameraSystem cameraSystem;
    [SerializeField] private float zoomInSpeed = 1f; 
    [SerializeField] private float zoomOutSpeed = 2f; 
    [SerializeField] private ClickOnTargetSystem clickOnTargetSystem; 
    private RectTransform rectTransform; 
    private Vector3 originalSize; 
    private bool isZoom = true;

    private void Awake()
    {
        cameraSystem.ZoomIn += CameraSystem_ZoomIn;
        cameraSystem.ZoomOut += CameraSystem_ZoomOut;       
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); 
        originalSize = rectTransform.localScale;    
    }

    private void CameraSystem_ZoomOut(object sender, System.EventArgs e)
    {
        if (!isZoom)
        {
            isZoom = true;
            StartCoroutine(ChangeSizeCoroutine(new Vector3(151.46f, 172.2247f, 279.735f), zoomOutSpeed));           
        }
    }

    private void CameraSystem_ZoomIn(object sender, System.EventArgs e)
    {
        if (isZoom)
        {
            isZoom = false;
            StartCoroutine(ChangeSizeCoroutine(new Vector3(6.2f, 7.05f, 11.45092f), zoomInSpeed));           
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
