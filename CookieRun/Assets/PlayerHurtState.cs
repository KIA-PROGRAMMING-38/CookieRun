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
        // HP는 0이 되면 Die상태가 된다.
        // HP는 0 미만이 되면 안된다.
        // 3초동안 무적 상태 코루틴 호출
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    
}
