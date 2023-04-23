using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float jumpForce;
    // 중력에 적용할 힘
    public float gravityModifier;
    // 무적 상태 체크
    public static bool isInvincible = false;

    // test hp = 50 -> 100으로 변경 예정.
    public float maxHp;

    public bool jumping = false;

    public bool isHurt;

    public bool isLightSpeed;

    public float lightSpeed = 2f;

    public float nomalSpeed = 1f;

}
