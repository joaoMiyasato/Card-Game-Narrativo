using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Choice", menuName = "Choice")]
public class ChoiceIns : DialogObj
{
    [TextArea(5,10)]
    public string[] Answer;
    private void Awake()
    {
        type = DialogType.Choice;
    }
}
