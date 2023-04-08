using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2StateBehaviour : StateMachineBehaviour
{
    private PlayerData _playerData;
    private Rigidbody2D _rigidbody;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerData = animator.GetComponent<PlayerData>();
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(Vector2.up * _playerData.JumpSpeed, ForceMode2D.Impulse);
    }
}
