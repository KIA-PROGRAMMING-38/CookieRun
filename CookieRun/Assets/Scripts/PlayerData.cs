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
    public bool isInvincible = false;

    // test hp = 50 -> 100으로 변경 예정.
    public static float HP = 50f;

    public bool jumping = false;

    private void Start()
    {
        Debug.Log(HP);
    }
}
