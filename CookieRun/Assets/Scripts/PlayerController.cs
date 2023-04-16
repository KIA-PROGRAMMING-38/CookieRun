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
    private Color _originalColor = new Color(1,1,1,1);
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerData = GetComponent<PlayerData>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Physics2D.gravity *= _playerData.gravityModifier;
    }

    private void Update()
    {
        // 어느 상태던지 hp가 0이면 Die상태가 된다.
        if (PlayerData.HP == 0)
        {
            _animator.Play("Die");
        }
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
            if (!GameManager.gameOver)
            {
                _animator.SetTrigger(PlayerAnimID.IS_HURT);
                OnDamaged();    
            }
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
        
        // test 1초뒤 무적상태 해제. 3초로 변경 예정
        Invoke("OffDamaged", 1);
    }

    private void OffDamaged()
    {
        _spriteRenderer.color = _originalColor;
        _playerData.isInvincible = false;
    }
}
