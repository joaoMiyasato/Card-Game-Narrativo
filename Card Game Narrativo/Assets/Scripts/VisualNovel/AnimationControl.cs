using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public void ANIMATION_ACTIVE_TRANSITION()
    {
        DialogManager.instance.transition = true;
    }

    public void ANIMATION_DEACTIVE_TRANSITION()
    {
        DialogManager.instance.transition = false;
    }

    public void CONTINUE_DIALOG()
    {
        DialogManager.instance.Say();
    }
}
