using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : StateMachineBehaviour
{
    private PlayerController _playerController;
    private float _attackValue = -10f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController = animator.GetComponent<PlayerController>();
        // PlayerHP 깍임
        _playerController.ChangeHp(_attackValue);
        
        Debug.Log(PlayerData.HP);
    }
}
