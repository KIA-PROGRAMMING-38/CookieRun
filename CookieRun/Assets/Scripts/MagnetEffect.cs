using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetEffect : MonoBehaviour
{
    public float Duration = 3f;

    private float _startTime;

    private void OnEnable()
    {
        // 시작 시간 설정
        _startTime = Time.time;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 경과시간이 지속시간을 넘으면
        if (Time.fixedTime >= _startTime + Duration)
        {
            // 컴포넌트 비활성화
            enabled = false;
        }

        // 끌어오게 한다.
        Debug.Log("젤리 끌어오는 중");
    }
}