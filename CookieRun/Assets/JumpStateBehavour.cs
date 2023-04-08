using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStateBehavour : StateMachineBehaviour
{
    private PlayerData _playerData;
    private Rigidbody2D _rigidbody;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerData = animator.GetComponent<PlayerData>();
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(Vector2.up * _playerData.JumpSpeed, ForceMode2D.Impulse);
        
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJump2", true);
        }
    }
}
