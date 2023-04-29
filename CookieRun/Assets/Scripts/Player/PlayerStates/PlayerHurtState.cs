using System.Collections;
using System.Collections.Generic;
using System.IO;
using PlayerAnimationID;
using UnityEngine;
using Literal;

public class PlayerHurtState : StateMachineBehaviour
{
    private PlayerController _playerController;
    private float _attackValue = -10f;
    private PlayerData _playerData;
    private AudioSource _audioSource;
    private AudioClip _hurtAudioClip;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController = animator.GetComponent<PlayerController>();
        _playerData = animator.GetComponent<PlayerData>();
        _audioSource = animator.GetComponent<AudioSource>();

        // PlayerHP 깍임
        _playerController.ChangesHpByAmount(_attackValue);
        _hurtAudioClip = DataManager.LoadAudioClip(AudioClipName.HURT);

        _audioSource.volume = 1;
        _audioSource.PlayOneShot(_hurtAudioClip);
        
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
        _audioSource.volume = 0.5f;
    }
}
