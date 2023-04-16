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

    public static float HP = 100f;
}
