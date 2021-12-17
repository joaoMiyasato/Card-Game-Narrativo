using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    public static AnswerManager instance;
    [HideInInspector]public bool inAnswer;
    public ELEMENTS elements;

    public GameObject[] answerBoxes;

    private void Awake()
    {
        instance = this;
    }

#region setAnswers

    public void newSetAnswers(string[] a)
    {
        answerBoxes[0].gameObject.SetActive(false);
        answerBoxes[1].gameObject.SetActive(false);
        answerBoxes[2].gameObject.SetActive(false);
        //1 fala, 2 pra onde vai, 3 precisa de carta, 4 passou pelo nodo x
        for (int i = 0; i < 3; i++)
        {
            buttons[i].SetActive(false);
            buttons[i].transform.Find("NeedCard").gameObject.SetActive(false);
            buttons[i].transform.Find("BlockOption").gameObject.SetActive(false);
        }

        for (int i = 0; i < a.Length; i++)
        {
            string[] part = a[i].Split(':');
            buttons[i].GetComponentInChildren<Text>().text = part[0];
            if(part.Length >= 2)
            {
                if(part[1] != "")
                {
                    buttons[i].gameObject.GetComponent<VisualNovelButton>().jumpIndex = int.Parse(part[1]);
                }
            }
            if(part.Length >= 3)
            {
                if(part[2] != "")
                {
                    buttons[i].transform.Find("NeedCard").gameObject.SetActive(true);
                }
            }
            if(part.Length >= 4)
            {
                if(part[3] != "")
                {
                    for (int z = 0; z < DialogManager.instance.DialogList.Count; z++)
                    {
                        if(part[3] == DialogManager.instance.DialogList[z].name)
                        {
                            if(!DialogManager.instance.DialogList[z].alreadySpoke)
                            {
                                buttons[i].transform.Find("BlockOption").gameObject.SetActive(true);
                            }
                        }
                    }
                }
            }
            buttons[i].SetActive(true);
        }

        if(buttons[2].gameObject.activeSelf == true && buttons[3].gameObject.activeSelf == false)
        {
            answerBoxes[1].gameObject.SetActive(true);
        }
        else if(buttons[3].gameObject.activeSelf == true)
        {
            answerBoxes[2].gameObject.SetActive(true);
        }
        else if(buttons[1].gameObject.activeSelf == true && buttons[2].gameObject.activeSelf == false)
        {
            answerBoxes[0].gameObject.SetActive(true);
        }
    }
#endregion


#region elements
    [System.Serializable]
    public class ELEMENTS
    {
        public GameObject answerPanel;
        public GameObject[] buttons = new GameObject[4];
    }
    public GameObject answerPanel{get{return elements.answerPanel;}}
    public GameObject[] buttons{get{return elements.buttons;}}
#endregion

}
