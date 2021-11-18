using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeManager : MonoBehaviour
{
    public static NodeManager instance;

    [HideInInspector]public bool[] nodesBool;
    public GameObject[] nodes;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        nodesBool = new bool[60];
    }
    public void updateNode()
    {
        for (int i = 0; i < nodesBool.Length; i++)
        {
            string dialog = "PC "+i;

            if(DialogManager.instance.currendDialog.name == dialog)
            {
                nodesBool[i] = true;
            }

            for (int j = 0; j < nodes.Length; j++)
            {
                string[] parts = nodes[j].name.Split('(', ')');
                if(int.Parse(parts[1]) == i && nodesBool[i] == true)
                {
                    nodes[j].GetComponent<Image>().color = Color.white;
                    nodes[j].transform.Find("Text").gameObject.SetActive(true);
                    nodes[j].transform.Find("Arrows").gameObject.SetActive(true);
                }
                else if(int.Parse(parts[1]) == i && nodesBool[i] == false)
                {
                    nodes[j].GetComponent<Image>().color = Color.gray;
                    nodes[j].transform.Find("Text").gameObject.SetActive(false);
                    nodes[j].transform.Find("Arrows").gameObject.SetActive(false);
                }
            }
        }

    }
}
