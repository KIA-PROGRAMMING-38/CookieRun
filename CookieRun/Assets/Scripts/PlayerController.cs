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
    private WaitForSeconds _escapeInvincibleTime;

    // 자석에 닿았을시 켜지는 센서
    public GameObject magnetSensor;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerData = GetComponent<PlayerData>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // 중력 적용
        Physics2D.gravity *= _playerData.gravityModifier;

        _escapeInvincibleTime = new WaitForSeconds(3f);
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
        if (col.CompareTag("Enemy") && !_playerData.isInvincible)
        {
            if (!GameManager.gameOver)
            {
                _animator.SetTrigger(PlayerAnimID.IS_HURT);
                StartCoroutine(Invincible());
            }
        }
    }

    // 자석 센서 활성화. 자석이 플레이어에 닿았을 시 호출된다.
    public void ActivateMagneticEffect()
    {
        magnetSensor.SetActive(true);
    }

    // Animation Event 호출 함수
    public void Run()
    {
        _animator.SetTrigger(PlayerAnimID.IS_RUN);
    }

    // Hp값 변화 메소드
    public void ChangesHpByAmount(float amount)
    {
        PlayerData.HP = Mathf.Clamp(PlayerData.HP + amount, 0, _maxHp);
    }
    
    IEnumerator Invincible()
    {
        // 무적상태 진입
        _playerData.isInvincible = true;
        _spriteRenderer.color = _invincibleColor;
        
        // 3초 뒤 무적상태 해제
        yield return _escapeInvincibleTime;
        _spriteRenderer.color = _originalColor;
        Debug.Log("무적상태 해제");
        _playerData.isInvincible = false;
    }

    public void ActiveInvincibleCoroutine()
    {
        StartCoroutine(Invincible());
    }
}
