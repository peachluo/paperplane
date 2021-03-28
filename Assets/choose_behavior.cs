using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose_behavior : StateMachineBehaviour
{
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (!DataControl.Instance.character[selectPanel.characterPtr])
            selectPanel.characterPtr--;
    }
}
