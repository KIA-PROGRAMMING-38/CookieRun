using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyAnimationID;
using UnityEngine.Serialization;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private Obstacle _obstacleData;
    
    private PlayerData _playerData;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private Animator _animator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = _obstacleData.Sprite;
        _animator.runtimeAnimatorController = _obstacleData.Animator;

        ResizeCollider();
    }

    private float _colliderSizeOffset = 0.85f;
    // 콜라이더 사이즈를 sprite의 사이즈로 설정해주는 함수
    private void ResizeCollider()
    {
        Vector2 spriteSize = _spriteRenderer.sprite.bounds.size;
        _boxCollider.size = spriteSize * _colliderSizeOffset;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _playerData = col.GetComponent<PlayerData>();

        if (_playerData != null && _playerData.isLightSpeed)
        {
            _animator.SetTrigger(EnemyAnimID.IS_EXPLOSION);
        }
    }

    // 애니메이션 이벤트 호출 함수
    public void SetIdleAnimation()
    {
        _animator.Play("Idle");
    }
}
