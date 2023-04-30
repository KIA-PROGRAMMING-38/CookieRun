using System.Collections;
using System.Collections.Generic;
using PlayerAnimationID;
using UnityEngine;
using Literal;

public class PlayerSlideState : StateMachineBehaviour
{
    private CapsuleCollider2D _collider;
    private Vector2 _slideColSize = new Vector2(1.5f, 1);
    private Vector2 _slideColOffset = new Vector2(0, -1.3f);
    private AudioSource _audioSource;

    private AudioClip _slideAudioClip;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // SlideState Collider 수정
        _collider = animator.GetComponent<CapsuleCollider2D>();
        _audioSource = animator.GetComponent<AudioSource>();
        _slideAudioClip = DataManager.LoadAudioClip(AudioClipName.SLIDE);
        
        _collider.offset = _slideColOffset;
        _collider.direction = CapsuleDirection2D.Horizontal;
        _collider.size = _slideColSize;
        _audioSource.PlayOneShot(_slideAudioClip);
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool(PlayerAnimID.IS_SLIDE, false);
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
