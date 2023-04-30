using System.Collections;
using System.Collections.Generic;
using Literal;
using UnityEngine;

public class PlayerLadingState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 슬라이드 키를 누르고 있으면 착지모션을 취하지 않고 Run상태 진입
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger(PlayerAnimID.IS_RUN);
        }
    }
}
