using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog")]
public class DialogIns : DialogObj
{
    [TextArea(5,10)]
    public string[] Dialog;

    public Image Background;

    public bool alreadySpoke;
    private void Awake()
    {
        type = DialogType.Dialog;
    }
}