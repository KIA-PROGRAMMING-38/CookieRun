using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyAnimationID;

public class TestEnemyController : MonoBehaviour
{
    private Enemy _enemyData;
    
    private PlayerData _playerData;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Activate(EnemyKind.LarvaSmall);
    }

    public void Activate(EnemyKind enemyKind)
    {
        _enemyData = DataManager.Enemies[(int)enemyKind];
        // BindData
    }

    private void BindData()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        string spriteName = $"enemy_{_enemyData.SpriteName}";

        _spriteRenderer.sprite = DataManager.LoadEnemySprite(spriteName);
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
