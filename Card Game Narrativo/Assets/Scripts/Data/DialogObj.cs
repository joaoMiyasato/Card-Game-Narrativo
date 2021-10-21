using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DialogType
{
    Choice,
    Dialog
}

public abstract class DialogObj : ScriptableObject
{
    public DialogType type;
}
