using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{
    public static SpeechManager instance;
    public ELEMENTS elements;
    void Awake()
    {
        instance = this;
    }

    public void Say(string speech, string speeker)
    {
        StopSpeaking();
        speaking = StartCoroutine(Speaking(speech, speeker));
    }

    public void StopSpeaking()
    {
        if(isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }

    public bool isSpeaking {get{return speaking != null;}}
    [HideInInspector] public bool waitingInput = false;

    Coroutine speaking = null;
    IEnumerator Speaking(string speechTarget, string speeker)
    {
        speechPanel.SetActive(true);
        speechText.text = "";
        speekerName.text = speeker;
        waitingInput = false;

        while (speechText.text != speechTarget)
        {
            speechText.text += speechTarget[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }

        waitingInput = true;
        while (waitingInput)
        {
            yield return new WaitForEndOfFrame();
        }

        StopSpeaking();
    }
    

#region elements
    [System.Serializable]
    public class ELEMENTS
    {
        public GameObject speechPanel;
        public Text speechText;
        public Text speekerName;

    }
        public GameObject speechPanel{get{return elements.speechPanel;}}
        public Text speechText{get{return elements.speechText;}}
        public Text speekerName{get{return elements.speekerName;}}
#endregion

}
