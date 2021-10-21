using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog")]
public class DialogIns : DialogObj
{
    [TextArea(5,10)]
    public string[] Dialog;
    private void Awake()
    {
        type = DialogType.Dialog;
    }
}