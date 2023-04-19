using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyAnimationID;

public class Enemy : MonoBehaviour
{
    private PlayerData _playerData;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _playerData = col.GetComponent<PlayerData>();

        if (_playerData != null && _playerData.isLightSpeed)
        {
            _spriteRenderer.sprite = null;
            _animator.SetTrigger(EnemyAnimID.IS_EXPLOSION);
        }
    }
}
