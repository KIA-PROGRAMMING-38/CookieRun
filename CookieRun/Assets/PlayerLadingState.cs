using System.Collections;
using System.Collections.Generic;
using Sprites;
using UnityEngine;

public class PlayerLadingState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger(PlayerAnimID.IS_RUN);
        }
    }
}
