using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenUI : MonoBehaviour
{
    public event EventHandler OnNextLLevelButtonClicked;

    [SerializeField] private ClickOnTargetSystem clickOnTargetSystem;
    [SerializeField] private RectTransform targetRectTransform;
    [SerializeField] private Button nextLevelButton;

    private float animationDuration = 1f;

    private void Awake()
    {
        clickOnTargetSystem.OnClick += ClickOnTargetSystem_OnClick;

        nextLevelButton.onClick.AddListener(() =>
        {
            OnNextLLevelButtonClicked?.Invoke(this, EventArgs.Empty);
        });
    }
    private void ClickOnTargetSystem_OnClick(object sender, System.EventArgs e)
    {
        StartCoroutine(MoveRectTransformSmoothly(targetRectTransform, new Vector2(0f, targetRectTransform.anchoredPosition.y), animationDuration));
    }

    private IEnumerator MoveRectTransformSmoothly(RectTransform rectTransform, Vector2 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector2 startingPosition = rectTransform.anchoredPosition;

        while (elapsedTime < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition; // Ensure it reaches the exact position
    }
}
