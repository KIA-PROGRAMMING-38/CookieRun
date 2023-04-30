using System.Collections;
using System.Collections.Generic;
using Literal;
using UnityEngine;

public class ObstacleExplosionState : StateMachineBehaviour
{
    private AudioSource _audioSource;
    private AudioClip _explosionAudioClip;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _audioSource = animator.GetComponent<AudioSource>();
        _explosionAudioClip = DataManager.LoadAudioClip(AudioClipName.EXPLOSION);
        
        _audioSource.PlayOneShot(_explosionAudioClip);
    }
}
