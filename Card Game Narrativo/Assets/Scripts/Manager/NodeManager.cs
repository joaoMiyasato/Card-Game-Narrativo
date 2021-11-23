using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeManager : MonoBehaviour
{
    public static NodeManager instance;
    public GameObject[] nodes;

    private GameObject lastNode = null;

    private void Awake()
    {
        instance = this;
    }

    public GameObject searchNode()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            if(DialogManager.instance.currendDialog == nodes[i].GetComponent<NodoName>().nodeDialog)
            {
                lastNode = nodes[i];
                return lastNode;
            }
        }
        return lastNode;
    }
}
