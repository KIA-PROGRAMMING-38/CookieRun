using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using PlayerAnimationID;
using Model;

public class PlayerAnimController : MonoBehaviour
{
    private Animator _animator;
    private PlayerData _playerData;
    private PlayerController _playerController;
    private IEnumerator _normalInvicible;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerData = GetComponent<PlayerData>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        JumpButton.OnClickJumpButton -= PerformJump;
        JumpButton.OnClickJumpButton += PerformJump;
    }

    private void Update()
    {
        // 어느 상태던지 hp가 0이면 Die상태가 된다.
        if (CookieUIModel.Hp <= 0)
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
        if (col.CompareTag("Enemy") && !PlayerData.isInvincible)
        {
            if (!GameManager.GameOver)
            {
                _animator.SetTrigger(PlayerAnimID.IS_HURT);
                _playerData.isHurt = true;


                if (_normalInvicible != null)
                {
                    StopCoroutine(_normalInvicible);
                }
                
                _normalInvicible = _playerController.Invincible();
                _playerController.SetActiveCoroutine(_normalInvicible);
            }
        }
    }
    
    // Animation Event 호출 함수
    public void Run()
    {
        _animator.SetTrigger(PlayerAnimID.IS_RUN);
    }
    
    // GameSpeed가 바뀌는 순간에 animation의 프레임을 바꿔야 한다.
    public void SetAnimSpeed(float speed)
    {
        _animator.speed = speed;
    }

    void PerformJump()
    {
        if (_playerData.jumping)
        {
            _animator.SetTrigger(PlayerAnimID.IS_DOUBLEJUMPING);
        }

        else
        {
            _animator.SetBool(PlayerAnimID.IS_JUMPING, true);
        }
    }

    private void OnDestroy()
    {
        JumpButton.OnClickJumpButton -= PerformJump;
    }
}
