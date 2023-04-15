using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : StateMachineBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerData _playerData;
    private Vector2 _up = Vector2.up;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _playerData = animator.GetComponent<PlayerData>();
        
        // DoubleJump
        _rigidbody.velocity = _up * _playerData.jumpForce;
    }

 
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

 
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
