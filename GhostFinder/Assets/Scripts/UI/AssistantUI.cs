using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;
using System;

public class AssistantUI : MonoBehaviour
{
    public static AssistantUI Instance { get; private set; }
    private Animation animation;

    [SerializeField] private SaveLoadData saveLoadData;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private AudioSource talkingAudioSourse;
    private int currentMessageIndex = 0;
    private TextWriter.TextWriterSingle textWriterSingle;

    public event EventHandler StartSpeaking;
    private void Awake()
    {
        Debug.Log(saveLoadData.GetCurrentLevelID());
        Instance = this;
        animation = transform.Find("Message").GetComponent<Animation>();  
        if(saveLoadData.GetCurrentLevelID() == 0)
        {
            transform.Find("Message").GetComponent<Button_UI>().ClickFunc = () =>
            {
                if (textWriterSingle != null && textWriterSingle.IsActive())
                {
                    textWriterSingle.WriteAllAndDestory();
                }
                else
                {
                    string[] messageArray = new string[]
                    {
                       "�����, �� ��� ��� �������� �� �������� ��������",
                       "� ���� ��������� ����� �����볿",
                       "�� ������� ������� �� ���������",
                       "������ ������������ ����, � ���� ��������� �� ������ ��������� �����볿",
                       "���� ���� �� ������� �� ����� �������",
                       "..."
                    };

                    if (currentMessageIndex < messageArray.Length)
                    {
                        string message = messageArray[currentMessageIndex];
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);
                        StartTalkingSound();

                        currentMessageIndex++;
                    }
                }

            };
        }
        else if (saveLoadData.GetCurrentLevelID() == 1)
        {
            transform.Find("Message").GetComponent<Button_UI>().ClickFunc = () =>
            {
                if (textWriterSingle != null && textWriterSingle.IsActive())
                {
                    textWriterSingle.WriteAllAndDestory();
                }
                else
                {
                    string[] messageArray = new string[]
                    {
                      "�� ��������� ����� �, D �� ������ ����� ������ ��� ���� ��� ��������� �����볿",
                      "�� ��������� ����� ������ ���� ������������ ���� ��� ������������ �� ��������� �������",
                      "���� ������� ���� �������� ����� ������ F1",
                      "� ����� ����� �� ����� �� �����볿",                      
                      "..."
                    };

                    if (currentMessageIndex < messageArray.Length)
                    {
                        string message = messageArray[currentMessageIndex];
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);
                        StartTalkingSound();

                        currentMessageIndex++;
                    }
                }

            };
        }
       
        animation.Play();
    }
    private void StartTalkingSound()
    {
        talkingAudioSourse.Play();
    }

    private void StopTalkingSound()
    {
        talkingAudioSourse.Stop();
    }

    public int GetCurrentMessageIndex()
    {
        return currentMessageIndex;
    }
}
