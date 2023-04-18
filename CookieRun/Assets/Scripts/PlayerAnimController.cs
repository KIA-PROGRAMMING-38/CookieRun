using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimController : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    // GameSpeed가 바뀌는 순간에 animation의 프레임을 바꿔야 한다.
    public void SetAnimSpeed(float speed)
    {
        _animator.speed = speed;
    }
}
