using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerData : MonoBehaviour
{
    public float jumpForce;
    // 중력에 적용할 힘
    public float gravityModifier;
    // 무적 상태 체크
    private static bool _isInvincible;

    public static bool IsInvincible
    {
        get => _isInvincible;

        set
        {
            _isInvincible = value;
        }
    }
    
    public float maxHp;

    private bool _isJumping;

    public bool IsJumping
    {
        get => _isJumping;

        set
        {
            _isJumping = value;
        }
    }

    private bool _isHurt;

    public bool IsHurt
    {
        get => _isHurt;

        set
        {
            _isHurt = value;
        }
    }

    private static bool _isLightSpeed;

    public static bool IsLightSpeed
    {
        get => _isLightSpeed;

        set
        {
            _isLightSpeed = value;
        }
    }

    public float lightSpeed = 2f;

    public float nomalSpeed = 1f;
}
