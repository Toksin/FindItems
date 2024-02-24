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

    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private AudioSource talkingAudioSourse;
    private int currentMessageIndex = 0;
    private TextWriter.TextWriterSingle textWriterSingle;

    public event EventHandler StartSpeaking;
    private void Awake()
    {
        Instance = this;
        animation = transform.Find("Message").GetComponent<Animation>();  
        transform.Find("Message").GetComponent<Button_UI>().ClickFunc = () => 
        {
            if(textWriterSingle != null && textWriterSingle.IsActive())
            {
               textWriterSingle.WriteAllAndDestory();
            }
            else
            {
                string[] messageArray = new string[]
                {
                "Привет, як тобі вже пояснили це секретне завдання,",
                "З нашої лабораторії втікли аномалії",
                "Їх потрібно вислідіти та ліквідувати",
                "Ось тобі лінза №545 з її допомогою ти зможеш знаходити аномалії",
                "Побачимось на місці подій"
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
}
