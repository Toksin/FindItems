using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1StartManager : MonoBehaviour
{
    [SerializeField] private GameObject AssistantUIGameObject;
    private void Update()
    {
        HideAssistant();     
       
    }
    private void HideAssistant()
    {
        if (AssistantUI.Instance.GetCurrentMessageIndex() > 4)
        {
            AssistantUIGameObject.SetActive(false);
        }
    }
}
