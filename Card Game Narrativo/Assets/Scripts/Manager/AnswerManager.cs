using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    public static AnswerManager instance;
    [HideInInspector]public bool inAnswer;
    public ELEMENTS elements;

    private void Awake()
    {
        instance = this;
    }

#region setAnswers

    public void newSetAnswers(string[] a)
    {
        //1 fala, 2 pra onde vai, 3 precisa de carta
        for (int i = 0; i < 3; i++)
        {
            buttons[i].SetActive(false);
            buttons[i].transform.Find("NeedCard").gameObject.SetActive(false);
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
            buttons[i].SetActive(true);
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
