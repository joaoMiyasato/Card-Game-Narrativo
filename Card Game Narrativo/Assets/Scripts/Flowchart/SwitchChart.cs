using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchChart : MonoBehaviour
{
    public static SwitchChart instance;
    public Image image;
    public Sprite[] flowcharts;

    private void Awake()
    {
        instance = this;
    }
    public void switchFlowchart(int i)
    {
        if(i > flowcharts.Length)
            return;
        image.sprite = flowcharts[i];
    }
}
