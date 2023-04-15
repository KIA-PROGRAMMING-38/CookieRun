using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : StateMachineBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerData _playerData;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _playerData = animator.GetComponent<PlayerData>();
        
        _rigidbody.AddForce(Vector2.up * _playerData.jumpForce, ForceMode2D.Impulse);
    }
}
