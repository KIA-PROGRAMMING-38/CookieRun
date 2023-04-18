using System;
using System.Collections;
using System.Collections.Generic;
using Sprites;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private PlayerData _playerData;
    private SpriteRenderer _spriteRenderer;
    private PlayerAnimController _playerAnimController;
    private float _maxHp = 100f;
    private Color _invincibleColor = new Color(1, 1, 1, 0.5f);
    private Color _originalColor = new Color(1,1,1,1);
    private WaitForSeconds _escapeInvincibleTime;

    // 자석에 닿았을시 켜지는 센서
    public GameObject magnetSensor;
    
    public ParticleSystem dashParticle;
    public GameObject dashSprite;
    public GameObject explosionAnimation;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerData = GetComponent<PlayerData>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerAnimController = GetComponent<PlayerAnimController>();

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
                _playerData.isHurt = true;
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

    // LightSpeed상태일때 켜질 Effect
    public void ActivateDashEffect(bool active)
    {
        dashParticle.gameObject.SetActive(active);
        dashSprite.gameObject.SetActive(active);
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
        Debug.Log("무적상태");
        _playerData.isInvincible = true;

        if (_playerData.isHurt)
        {
            _spriteRenderer.color = _invincibleColor;
        }

        // Hurt상태가 아닐시
        else
        {
            _playerAnimController.SetAnimSpeed(_playerData.lightSpeed);
        }

        // 3초 뒤 무적상태 해제
        yield return _escapeInvincibleTime;
        
        // Hurt에서 바뀌었던 색을 원래대로 되돌린다.
        _spriteRenderer.color = _originalColor;
        
        // LightSpeed 상태에서 빨라졌던 플레이어의 애니메이션을 되돌린다.
        _playerAnimController.SetAnimSpeed(_playerData.nomalSpeed);
        
        // GameSpeed를 원래대로 되돌린다.
        GameManager.SetDefaultGameSpeed();
        
        // dashEffect 비활성화
        ActivateDashEffect(false);

        _playerData.isLightSpeed = false;

        Debug.Log("무적상태 해제");
        _playerData.isInvincible = false;
    }
    
    

    public void ActiveInvincibleCoroutine()
    {
        StartCoroutine(Invincible());
    }
}
