using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public static int answerId = -1;

    public string[] s = new string[]
    {
        "Oi, tudo bem com você?:JORGE",
        "Como vai a vida na cidade?:",
        "estou indo muito bem obrigado:JOAO"
    };

    public string[] x = new string[3];
    public string[] z = new string[3];

    public string[] choices = new string[2];
    int index = 0;
    private string[] atual; 
    SpeechManager dialogue;
    void Start()
    {
        dialogue = SpeechManager.instance;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(index >= s.Length)
            {
                AnswerManager.instance.waitingForAnswer = true;
            }
            if(AnswerManager.instance.waitingForAnswer)
            {
                AnswerManager.instance.setNumberOfAnswers(2);
                AnswerManager.instance.setAnswers(choices[0], choices[1]);
                AnswerManager.instance.answerPanel.SetActive(true);
            }
            if(!dialogue.isSpeaking && !AnswerManager.instance.waitingForAnswer || dialogue.waitingInput && !AnswerManager.instance.waitingForAnswer)
            {
                if(index >= s.Length)
                {
                    return;
                }

                // Say(atual[index]);
                Say();
            }
        }

        if(AnswerManager.instance.waitingForAnswer)
        {
            index = 0;
        }
    }

    private void updateDialogue()
    {
        if(answerId == -1)
        {
            atual = s;
        }
        else if(answerId == 0)
        {
            atual = x;
        }
        else if(answerId == 1)
        {
            atual = z;
        }
    }

    // void Say(string s)
    // {
    //     string[] parts = s.Split(':');
    //     string speech = parts[0];
    //     string speaker = (parts.Length >= 2) ? parts[1] : "";

    //     dialogue.Say(speech, speaker);
    // }
    public void Say()
    {
        updateDialogue();
        string[] parts = atual[index].Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        dialogue.Say(speech, speaker);
        index++;
    }
}
