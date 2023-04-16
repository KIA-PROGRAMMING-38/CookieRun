using System;
using System.Collections;
using System.Collections.Generic;
using Sprites;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private PlayerData _playerData;
    private float _maxHp = 100f;
    private SpriteRenderer _spriteRenderer;
    private Color _invincibleColor = new Color(1, 1, 1, 0.5f);
    Color _originalColor = new Color(1,1,1,1);
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerData = GetComponent<PlayerData>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Physics2D.gravity *= _playerData.gravityModifier;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool(PlayerAnimID.IS_JUMPING, false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // 무적상태이면 Hurt로 들어가면 안된다.
        if (col.gameObject.CompareTag("Enemy") && !_playerData.isInvincible)
        {
            OnDamaged();
            _animator.SetTrigger(PlayerAnimID.IS_HURT);
        }
    }

    // Animation Event 호출 함수
    public void Run()
    {
        _animator.SetTrigger(PlayerAnimID.IS_RUN);
    }

    // Hp값 변화 메소드
    public void ChangeHp(float amount)
    {
        PlayerData.HP = Mathf.Clamp(PlayerData.HP + amount, 0, _maxHp);
    }

    private void OnDamaged()
    {
        // 무적상태 진입
        _playerData.isInvincible = true;
        _spriteRenderer.color = _invincibleColor;
     
        // 3초 뒤 무적상태 해제
        Invoke("OffDamaged", 3);
    }

    private void OffDamaged()
    {
        _spriteRenderer.color = _originalColor;
        _playerData.isInvincible = false;
    }
}
