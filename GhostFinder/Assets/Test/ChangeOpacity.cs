using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOpacity : MonoBehaviour
{
    [SerializeField] private CameraSystem cameraSystem;   
    [SerializeField] private float changeSpeed = 2f;
    private Image image;
    private Color originalColor;         

    private bool isZoom = false;   

    void Start()
    {       
        image = GetComponent<Image>();
        originalColor = image.color;

        cameraSystem.ZoomIn += CameraSystem_ZoomIn;
        cameraSystem.ZoomOut += CameraSystem_ZoomOut;
    }

    private void CameraSystem_ZoomOut(object sender, System.EventArgs e)
    {
        if (!isZoom)
        {
            isZoom = true;
            StartCoroutine(FadeImage(0f));
        }
    }

    private void CameraSystem_ZoomIn(object sender, System.EventArgs e)
    {
        if (isZoom)
        {
            isZoom = false;
            StartCoroutine(FadeImage(1f));
        }
    }
    IEnumerator FadeImage(float targetOpacity)
    {
        float startOpacity = image.color.a;
        float elapsedTime = 0f;

        while (elapsedTime < changeSpeed)
        {
            float newOpacity = Mathf.Lerp(startOpacity, targetOpacity, elapsedTime / changeSpeed);
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, newOpacity);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(originalColor.r, originalColor.g, originalColor.b, targetOpacity);
    }
}
