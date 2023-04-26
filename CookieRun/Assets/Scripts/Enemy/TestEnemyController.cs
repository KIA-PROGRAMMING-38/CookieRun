using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyAnimationID;

public class TestEnemyController : MonoBehaviour
{
    private Enemy _enemyData;
    
    private PlayerData _playerData;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private Animator _animator;

    private void Awake()
    {
        Activate(EnemyKind.LarvaHanging);
    }

    public void Activate(EnemyKind enemyKind)
    {
        _enemyData = DataManager.Enemies[(int)enemyKind];
        BindData();
    }

    private void BindData()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();

        string spriteName = $"enemy_{_enemyData.SpriteName}";
        _spriteRenderer.sprite = DataManager.LoadEnemySprite(spriteName);
        ResizeCollider();

        string animatorName = $"enemy_{_enemyData.AnimatorName}";
        
        _animator.runtimeAnimatorController = DataManager.LoadAnimatorController(animatorName);
    }

    private float _colliderSizeOffset = 0.85f;
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

    public void SetIdleAnimation()
    {
        _animator.Play("Idle");
    }
}
