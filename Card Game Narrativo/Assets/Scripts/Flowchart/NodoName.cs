using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodoName : MonoBehaviour
{
    public DialogIns nodeDialog;

    public GameObject[] arrows;
    public GameObject[] beforeNodes;

    public Transform part;

    
    void Start()
    {
        this.transform.Find("Text").GetComponent<Text>().text = this.nodeDialog.name;
        if(this.gameObject.name != "Nodo (1)")
        {
            this.GetComponent<Image>().color = new Color32(1, 1, 1, 0);
            this.transform.Find("Text").gameObject.SetActive(false);
            for (int i = 0; i < arrows.Length; i++)
            {
                arrows[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        if(this.nodeDialog.alreadySpoke == true)
        {
            this.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            this.transform.Find("Text").gameObject.SetActive(true);

            for (int i = 0; i < beforeNodes.Length; i++)
            {
                if(beforeNodes[i].GetComponent<NodoName>().nodeDialog.alreadySpoke == true)
                {

                    arrows[i].gameObject.SetActive(true);
                }
            }
        }

    }
}
