using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    public static AnswerManager instance;
    public ELEMENTS elements;
    public bool waitingForAnswer = false;
    // [HideInInspector] public int answerId = -1;

    private void Awake()
    {
        instance = this;
    }

#region setAnswers
    public void setAnswers(string a)
    {
        buttons[0].GetComponentInChildren<Text>().text = a;
    }
    public void setAnswers(string a, string b)
    {
        buttons[0].GetComponentInChildren<Text>().text = a;
        buttons[1].GetComponentInChildren<Text>().text = b;
    }
    public void setAnswers(string a, string b, string c)
    {
        buttons[0].GetComponentInChildren<Text>().text = a;
        buttons[1].GetComponentInChildren<Text>().text = b;
        buttons[2].GetComponentInChildren<Text>().text = c;
    }
    public void setAnswers(string a, string b, string c, string d)
    {
        buttons[0].GetComponentInChildren<Text>().text = a;
        buttons[1].GetComponentInChildren<Text>().text = b;
        buttons[2].GetComponentInChildren<Text>().text = c;
        buttons[3].GetComponentInChildren<Text>().text = d;
    }
    public void setNumberOfAnswers(int n)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        for (int i = 0; i < n; i++)
        {
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
