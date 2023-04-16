using System.Collections;
using System.Collections.Generic;
using Sprites;
using UnityEngine;

public class PlayerJumpState : StateMachineBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerData _playerData;
    private Vector2 _up = Vector2.up;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _playerData = animator.GetComponent<PlayerData>();
        
        // Jump
        _rigidbody.AddForce(_up * _playerData.jumpForce, ForceMode2D.Impulse);
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger(PlayerAnimID.IS_DOUBLEJUMPING);
        }       
    }
}
