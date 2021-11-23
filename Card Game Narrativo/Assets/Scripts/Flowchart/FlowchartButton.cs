using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartButton : MonoBehaviour
{
    public void showFlowchart()
    {
        FlowchartManager.instance.flowchartPanel.SetActive(true);
        FlowchartManager.instance.flowchartPanel.transform.Find("Flowchart").gameObject.SetActive(true);
    }
    public void hideFlochart()
    {
        FlowchartManager.instance.flowchartPanel.SetActive(false);
        FlowchartManager.instance.flowchartPanel.transform.Find("Flowchart").gameObject.SetActive(false);
    }
}
