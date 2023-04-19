using System.Collections;
using System.Collections.Generic;
using PlayerAnimationID;
using UnityEngine;

public class PlayerSlideState : StateMachineBehaviour
{
    private CapsuleCollider2D _collider;
    private Vector2 _slideColSize = new Vector2(1.5f, 1);
    private Vector2 _slideColOffset = new Vector2(0, -1.3f);
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // SlideState Collider 수정
        _collider = animator.GetComponent<CapsuleCollider2D>();
        _collider.offset = _slideColOffset;
        _collider.direction = CapsuleDirection2D.Horizontal;
        _collider.size = _slideColSize;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool(PlayerAnimID.IS_SLIDE, false);
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
