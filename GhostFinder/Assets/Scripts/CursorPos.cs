using System.Collections;
using UnityEngine;

public class CursorPos : MonoBehaviour
{
    [SerializeField] CameraSystem cameraSystem;
    [SerializeField] GameObject cursor;  
    [SerializeField] GameObject cursorZoom;

    private float zoomDuration = 4f;   
    private float maxZoomScale = 0.45f;
    private float zoomSpeed = 2.5f;
    private Vector3 DefaultCursorScale = new Vector3(0.15f, 0.15f, 1f);
   

    private bool isZooming = false;
    private void Start()
    {
        
        Cursor.visible = false;
        cameraSystem.ZoomIn += CameraSystem_ZoomIn;
        cameraSystem.ZoomOut += CameraSystem_ZoomOut;
    }

    private void CameraSystem_ZoomOut(object sender, System.EventArgs e)
    {
        if (isZooming)
        {           
            cursorZoom.SetActive(false);
            StartCoroutine(ShrinkCursor(DefaultCursorScale));
        }
    }

    private void CameraSystem_ZoomIn(object sender, System.EventArgs e)
    {
        if (!isZooming)
        {           
            cursorZoom.SetActive(true);
            StartCoroutine(AdjustCursorScale(maxZoomScale));
        }

    }
    private IEnumerator AdjustCursorScale(float targetScale)
    {
        isZooming = true;
        Vector3 initialScale = cursor.transform.localScale;
        float elapsed = 0f;

        while (elapsed < zoomDuration)
        {
            elapsed += Time.deltaTime * zoomSpeed;
            float t = Mathf.Clamp01(elapsed / zoomDuration);
            cursor.transform.localScale = Vector3.Lerp(initialScale, new Vector3(targetScale, targetScale, 1f), t);
            yield return null;
        }

        cursor.transform.localScale = new Vector3(targetScale, targetScale, 1f);
       
    }

    private IEnumerator ShrinkCursor(Vector3 targetScale)
    {       
        Vector3 initialScale = cursor.transform.localScale;
        float elapsedShrink = 0f;

        while (elapsedShrink < zoomDuration)
        {
            elapsedShrink += Time.deltaTime * zoomSpeed;
            float t = Mathf.Clamp01(elapsedShrink / zoomDuration);
            cursor.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        cursor.transform.localScale = targetScale;
        isZooming = false;
    }

    private void Update()
    {       
        Vector3 mousePosition = Input.mousePosition;        
        mousePosition.x -= 5f; 

        cursor.transform.position = mousePosition;
        cursorZoom.transform.position = mousePosition;
    }
}
