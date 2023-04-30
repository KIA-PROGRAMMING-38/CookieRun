using System;
using System.Collections;
using System.Collections.Generic;
using Literal;
using Model;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData;
    private SpriteRenderer _spriteRenderer;
    private PlayerAnimController _playerAnimController;
    private Rigidbody2D _rigid;
    
    // Audio
    private AudioSource _audioSource;
    private AudioClip _dashAudioClip;
    private AudioClip _getHpAudioClip;
    private AudioClip _getJellyAudioClip;
    
    private Color _invincibleColor = new Color(1, 1, 1, 0.5f);
    private Color _originalColor = new Color(1,1,1,1);
    private WaitForSeconds _escapeInvincibleTime;

    private float _deltaTime;

    // 자석에 닿았을시 켜지는 센서
    public GameObject magnetSensor;
    
    public ParticleSystem dashParticle;
    public GameObject dashSprite;

    private void Awake()
    {
        _playerData = GetComponent<PlayerData>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerAnimController = GetComponent<PlayerAnimController>();
        _rigid = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();

        
        // 중력 적용
        _rigid.gravityScale *= _playerData.gravityModifier;
        
        _escapeInvincibleTime = new WaitForSeconds(3f);
        
        GameManager.SetGameStartUIModel -= UIModelInitialize;
        GameManager.SetGameStartUIModel += UIModelInitialize;
    }

    private void Start()
    {
        _dashAudioClip = DataManager.LoadAudioClip(AudioClipName.DASH);
        _getHpAudioClip = DataManager.LoadAudioClip(AudioClipName.GET_HP);
        _getJellyAudioClip = DataManager.LoadAudioClip(AudioClipName.GET_Jelly);

        JellyController.OnGetJelly -= PlaySoundOnGetJelly;
        JellyController.OnGetJelly += PlaySoundOnGetJelly;
    }

    private void UIModelInitialize()
    {
        CookieUIModel.MaxHp = _playerData.maxHp;
        CookieUIModel.Hp = _playerData.maxHp;
        CookieUIModel.Score = 0;
    }

    private void Update()
    {
        _deltaTime = Time.deltaTime;
        
        if (!PlayerData.isInvincible && !GameManager.GameOver)
        {
            CookieUIModel.Hp -= _deltaTime;
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
    

    // Hp값 변화 메소드
    public void ChangesHpByAmount(float amount)
    {
        CookieUIModel.Hp = Mathf.Clamp(CookieUIModel.Hp + amount, 0, CookieUIModel.MaxHp);
    }
    
    public IEnumerator Invincible()
    {
        // 무적상태 진입
        PlayerData.isInvincible = true;

        _spriteRenderer.color = _invincibleColor;

        // 3초 뒤 무적상태 해제
        yield return _escapeInvincibleTime;
        
        // 바뀌었던 색을 원래대로 되돌린다.
        _spriteRenderer.color = _originalColor;
        
        PlayerData.isInvincible = false;
    }

    
    public IEnumerator LightSpeedInvincible()
    {
        PlayerData.isInvincible = true;
        _audioSource.PlayOneShot(_dashAudioClip);

        _playerAnimController.SetAnimSpeed(_playerData.lightSpeed);
        
        yield return _escapeInvincibleTime;
        
        // LightSpeed 상태에서 빨라졌던 플레이어의 애니메이션을 되돌린다.
        _playerAnimController.SetAnimSpeed(_playerData.nomalSpeed);
        // GameSpeed를 원래대로 되돌린다.
        GameManager.SetDefaultGameSpeed();

        // dashEffect 비활성화
        ActivateDashEffect(false);
        
        PlayerData.isLightSpeed = false;

        PlayerData.isInvincible = false;
    }

    public void SetActiveCoroutine(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }

    public void PlaySoundOnGetHp()
    {
        _audioSource.PlayOneShot(_getHpAudioClip);
    }

    public void PlaySoundOnGetJelly()
    {
        _audioSource.PlayOneShot(_getJellyAudioClip);
    }

    private void OnDestroy()
    {
        GameManager.SetGameStartUIModel -= UIModelInitialize;
        JellyController.OnGetJelly -= PlaySoundOnGetJelly;
    }
}
