using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Literal;

public class PlayerDoubleJumpState : StateMachineBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerData _playerData;
    private Vector2 _up = Vector2.up;
    private AudioSource _audioSource;

    private AudioClip _jumpAudioClip;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _playerData = animator.GetComponent<PlayerData>();
        _audioSource = animator.GetComponent<AudioSource>();
        _jumpAudioClip = DataManager.LoadAudioClip(AudioClipName.JUMP);
        
        _audioSource.PlayOneShot(_jumpAudioClip);
        
        // DoubleJump
        _rigidbody.velocity = _up * _playerData.jumpForce;
    }
}
