using System.Collections;
using UnityEngine;
using Literal;
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
        SlideButton.SlideButtonDown -= StartSlide;
        SlideButton.SlideButtonDown += StartSlide;
        SlideButton.SlideButtonUp -= StopSlide;
        SlideButton.SlideButtonUp += StopSlide;
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
        if (col.CompareTag("Enemy") && !PlayerData.IsInvincible)
        {
            if (!GameManager.GameOver)
            {
                _animator.SetTrigger(PlayerAnimID.IS_HURT);
                _playerData.IsHurt = true;


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
        if (_playerData.IsJumping)
        {
            _animator.SetTrigger(PlayerAnimID.IS_DOUBLEJUMPING);
        }

        else
        {
            _animator.SetBool(PlayerAnimID.IS_JUMPING, true);
        }
    }

    void StartSlide()
    {
        _animator.SetBool(PlayerAnimID.IS_SLIDE, true);
    }

    void StopSlide()
    {
        _animator.SetBool(PlayerAnimID.IS_SLIDE, false);
    }

    private void OnDestroy()
    {
        JumpButton.OnClickJumpButton -= PerformJump;
        SlideButton.SlideButtonDown -= StartSlide;
        SlideButton.SlideButtonUp -= StopSlide;
    }
}
