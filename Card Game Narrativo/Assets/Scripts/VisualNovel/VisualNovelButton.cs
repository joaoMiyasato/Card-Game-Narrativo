using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNovelButton : MonoBehaviour
{
    public int jumpIndex;
    public void setAnswerId()
    {
        DialogManager.instance.setDialogList(jumpIndex);
        DialogManager.instance.indexDialog = 0;
        AnswerManager.instance.answerPanel.SetActive(false);
        AnswerManager.instance.inAnswer = false;

        DialogManager.instance.Say();
    }
}
