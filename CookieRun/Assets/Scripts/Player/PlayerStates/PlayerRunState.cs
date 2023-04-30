using System.Collections;
using System.Collections.Generic;
using Model;
using Literal;
using UnityEngine;

public class PlayerRunState : StateMachineBehaviour
{
    private CapsuleCollider2D _collider;
    private Vector2 _runColSize = new Vector2(1, 1.5f);
    private Vector2 _runColOffset = new Vector2(0, -1.1f);
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // RunState Collider 수정
        _collider = animator.GetComponent<CapsuleCollider2D>();
        _collider.offset = _runColOffset;
        _collider.direction = CapsuleDirection2D.Vertical;
        _collider.size = _runColSize;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool(PlayerAnimID.IS_JUMPING, true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool(PlayerAnimID.IS_SLIDE, true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            CookieUIModel.Hp = 0;
        }
    }
}
