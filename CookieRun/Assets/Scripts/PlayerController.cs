using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    private void Awake()
    {
        _playerData = GetComponent<PlayerData>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerAnimController = GetComponent<PlayerAnimController>();

        // 중력 적용
        Physics2D.gravity *= _playerData.gravityModifier;

        _escapeInvincibleTime = new WaitForSeconds(3f);
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
    

    // Hp값 변화 메소드
    public void ChangesHpByAmount(float amount)
    {
        PlayerData.HP = Mathf.Clamp(PlayerData.HP + amount, 0, _maxHp);
    }
    
    public IEnumerator Invincible()
    {
        // 무적상태 진입
        _playerData.isInvincible = true;

        _spriteRenderer.color = _invincibleColor;

        // 3초 뒤 무적상태 해제
        yield return _escapeInvincibleTime;
        
        // 바뀌었던 색을 원래대로 되돌린다.
        _spriteRenderer.color = _originalColor;
        
        _playerData.isInvincible = false;
    }

    public IEnumerator LightSpeedInvincible()
    {
        _playerData.isInvincible = true;

        _playerAnimController.SetAnimSpeed(_playerData.lightSpeed);
        
        yield return _escapeInvincibleTime;
        
        // LightSpeed 상태에서 빨라졌던 플레이어의 애니메이션을 되돌린다.
        _playerAnimController.SetAnimSpeed(_playerData.nomalSpeed);
        // GameSpeed를 원래대로 되돌린다.
        GameManager.SetDefaultGameSpeed();

        // dashEffect 비활성화
        ActivateDashEffect(false);
        
        _playerData.isLightSpeed = false;
        
        _playerData.isInvincible = false;
    }

    public void SetActiveCoroutine(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }
}
