using System;
using System.Collections;
using System.Collections.Generic;
using Sprites;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private PlayerData _playerData;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerData = GetComponent<PlayerData>();
        Physics2D.gravity *= _playerData.gravityModifier;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool(PlayerAnimID.IS_JUMPING, false);
        }
    }

    // Animation Event 호출 함수
    public void Run()
    {
        _animator.SetTrigger(PlayerAnimID.IS_RUN);
    }
}
