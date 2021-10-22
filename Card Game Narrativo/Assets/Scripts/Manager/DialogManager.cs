using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public List<DialogIns> DialogList;
    public List<ChoiceIns> AnswerList;

    public static int answerId = -1;
    int indexDialog = 0;
    int indexDialogList = 0;
    int indexDialogAnswer = 0;
    
    SpeachManager dialogue;
    void Start()
    {
        dialogue = SpeachManager.instance;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(AnswerManager.instance.waitingForAnswer)
            {
                int i = AnswerList[indexDialogAnswer].Answer.Length;
                AnswerManager.instance.setNumberOfAnswers(i);
                if(i == 1)
                {
                    AnswerManager.instance.setAnswers  (AnswerList[indexDialogAnswer].Answer[0]);
                }
                else if(i == 2)
                {
                    AnswerManager.instance.setAnswers  (AnswerList[indexDialogAnswer].Answer[0],
                                                        AnswerList[indexDialogAnswer].Answer[1]);
                }
                else if(i == 3)
                {
                    AnswerManager.instance.setAnswers  (AnswerList[indexDialogAnswer].Answer[0],
                                                        AnswerList[indexDialogAnswer].Answer[1],
                                                        AnswerList[indexDialogAnswer].Answer[2]);
                }
                else if(i == 4)
                {
                    AnswerManager.instance.setAnswers  (AnswerList[indexDialogAnswer].Answer[0],
                                                        AnswerList[indexDialogAnswer].Answer[1],
                                                        AnswerList[indexDialogAnswer].Answer[2],
                                                        AnswerList[indexDialogAnswer].Answer[3]);
                }
                
                AnswerManager.instance.answerPanel.SetActive(true);
            }

            if(!dialogue.isSpeaking && !AnswerManager.instance.waitingForAnswer || dialogue.waitingInput && !AnswerManager.instance.waitingForAnswer)
            {
                if(indexDialog >= DialogList[indexDialogList].Dialog.Length)
                {
                    return;
                }

                Say();
            }
        }

        if(AnswerManager.instance.waitingForAnswer)
        {
            indexDialog = 0;
        }
    }

    private void updateDialogue()
    {
        if(answerId == 0)
        {
            indexDialogList++;
        }
        else if(answerId == 1)
        {
            indexDialogList += 2;
        }
        else if(answerId == 2)
        {
            indexDialogList += 3;
        }
        else if(answerId == 3)
        {
            indexDialogList += 4;
        }

        answerId = -1;
        indexDialog = 0;
        indexDialogAnswer++;
    }
    private string lastSpeaker = "";
    public void Say()
    {
        if(answerId != -1)
            updateDialogue();
        string[] parts = DialogList[indexDialogList].Dialog[indexDialog].Split(':');
        string speach = parts[0];
        string speaker = (parts.Length >= 2 && parts[1] != "") ? parts[1] : lastSpeaker;

        if(parts.Length >= 3)
        {
            if(parts[2] == "true")
            {
                AnswerManager.instance.waitingForAnswer = true;
            }
            else
            {
                AnswerManager.instance.waitingForAnswer = false;
            }
        }

        if(parts.Length >= 4)
        {
            if(parts[3] == "true")
            {
                //BATALHA
            }
            else
            {
                //NADA
            }
        }
        if(lastSpeaker != speaker)
        {
            lastSpeaker = speaker;
        }

        dialogue.Say(speach, speaker);
        indexDialog++;
        Debug.Log(indexDialog);
    }
}
