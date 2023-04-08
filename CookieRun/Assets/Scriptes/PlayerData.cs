using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float JumpSpeed = 8f;
    public float JumpCount { get; set; }

    private void Awake()
    {
        JumpCount = 0;
    }
}
