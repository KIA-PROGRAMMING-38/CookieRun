using System.Collections;
using System.Collections.Generic;
using Sprites;
using UnityEngine;

public class PlayerRunState : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool(PlayerAnimID.IS_JUMPING, true);
        }       
    }
}
