using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFlowchart : MonoBehaviour
{
    public Transform[] parts;
    public GameObject[] nodes;
    void Update()
    {
        goToNode();
    }

    
    public void goToNode()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            if(DialogManager.instance.currendDialog == nodes[i].GetComponent<NodoName>().nodeDialog)
            {
                transform.Find("mFlowchart").gameObject.transform.Find("Chapter 1").gameObject.transform.position = parts[i].position;
                return;
            }
        }
        return;
    }
}
