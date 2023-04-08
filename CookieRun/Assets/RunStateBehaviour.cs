using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStateBehaviour : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJump", true);
        }   
    }
}
