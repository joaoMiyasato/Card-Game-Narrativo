using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour
{
    public int buttonId;
    public void setAnswerId()
    {
        DialogManager.answerId = buttonId;
        AnswerManager.instance.answerPanel.SetActive(false);
        AnswerManager.instance.waitingForAnswer = false;
    }
}
