using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodoName : MonoBehaviour
{
    void Start()
    {
        this.transform.Find("Text").GetComponent<Text>().text = this.name;
        if(this.gameObject.name != "Nodo (1)")
        {
            this.transform.Find("Text").gameObject.SetActive(false);
            this.transform.Find("Arrows").gameObject.SetActive(false);
        }
    }
}
