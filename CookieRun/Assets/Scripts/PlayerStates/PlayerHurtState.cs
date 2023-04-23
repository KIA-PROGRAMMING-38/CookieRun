using System.Collections;
using System.Collections.Generic;
using PlayerAnimationID;
using UnityEngine;

public class PlayerHurtState : StateMachineBehaviour
{
    private PlayerController _playerController;
    private float _attackValue = -10f;
    private PlayerData _playerData;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController = animator.GetComponent<PlayerController>();
        _playerData = animator.GetComponent<PlayerData>();

        // PlayerHP 깍임
        _playerController.ChangesHpByAmount(_attackValue);
        
        // jump중에 Enemy랑 닿았다면 isJumping을 false해준다.
        if (_playerData.jumping == true)
        {
            _playerData.jumping = false;
            animator.SetBool(PlayerAnimID.IS_JUMPING, false);
        }
        
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerData.isHurt = false;
    }
}
