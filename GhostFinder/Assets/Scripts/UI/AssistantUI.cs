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
                       "Привіт, як тобі вже пояснили це секретне завдання",
                       "З нашої лабораторії втікли аномалії",
                       "Їх потрібно вислідіти та ліквідувати",
                       "Тримай збільшувальне скло, з його допомогою ти зможеш знаходити аномалії",
                       "Бери його та приходь на першу локацію",
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
                      "За допомогою клавіш А, D ти можешь міняти ракурс для того щоб знаходити аномалії",
                      "За допомогою правої кнопки миші використовуй лінзу для маштабування та виявлення аномалій",
                      "Якщо потрібно нашу підсказку тисни клавішу F1",
                      "А тепер вияви та злови усі аномалії",                      
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
