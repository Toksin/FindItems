using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instanse;
    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instanse = this;
        textWriterSingleList = new List<TextWriterSingle> ();
    }

    public static TextWriterSingle AddWriter_Static(TextMeshProUGUI text, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete) 
    {
        if (removeWriterBeforeAdd)
        {
            instanse.RemoveWriter(text);
        }
       return instanse.AddWriter(text, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }
    private TextWriterSingle AddWriter(TextMeshProUGUI text, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(text, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(TextMeshProUGUI text)
    {
        instanse.RemoveWriter(text);
    }

    private void RemoveWriter(TextMeshProUGUI text)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUIText() == text)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        for(int i = 0; i < textWriterSingleList.Count; i++)
        {
           bool destroyInstance = textWriterSingleList[i].Update();
            if(destroyInstance) 
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    public class TextWriterSingle
    {
        private TextMeshProUGUI uiText;
        private string textToWrite;
        private float timePerCharacter;
        private float timer;
        private int characterIndex;
        private bool invisibleCharacters;
        private Action onComplete;

        public TextWriterSingle(TextMeshProUGUI text, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            this.uiText = text;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            characterIndex = 0;
        }
        public bool Update()
        {          
                timer -= Time.deltaTime;
                while (timer <= 0f)
                {
                    timer += timePerCharacter;
                    characterIndex++;
                    string text = textToWrite.Substring(0, characterIndex);
                    if (invisibleCharacters)
                    {
                        text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                    }
                    uiText.text = text;

                    if (characterIndex >= textToWrite.Length)
                    {
                        if(onComplete != null) onComplete();                        
                        return true;
                    }
                }

            return false;
        }

        public TextMeshProUGUI GetUIText()
        {
            return uiText;
        }

        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestory()
        {
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            if (onComplete != null) onComplete();
            TextWriter.RemoveWriter_Static(uiText);
        }
    }
}
