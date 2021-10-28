using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartButton : MonoBehaviour
{
    public void showView()
    {
        FlowchartManager.instance.flowchartPanel.SetActive(true);
        FlowchartManager.instance.flowchartPanel.transform.Find("View").gameObject.SetActive(true);
    }

    public void hideView()
    {
        FlowchartManager.instance.flowchartPanel.SetActive(false);
        FlowchartManager.instance.flowchartPanel.transform.Find("View").gameObject.SetActive(false);
        FlowchartManager.instance.flowchartPanel.transform.Find("Flowchart").gameObject.SetActive(false);
    }

    public int buttonID = 0;
    public void showFlowchart()
    {
        FlowchartManager.instance.flowchartPanel.transform.Find("Flowchart").gameObject.SetActive(true);
        SwitchChart.instance.switchFlowchart(buttonID);
    }
    public void hideFlochart()
    {
        FlowchartManager.instance.flowchartPanel.transform.Find("Flowchart").gameObject.SetActive(false);
    }
}
