using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticEffect : MonoBehaviour
{
    public float Duration = 3f;
    // 끌어당기는 속도
    public float pullingSpeed = 15f;
    
    private float _startTime;

    private Transform _playerTransform;
    
    private Vector3 _targetPosition;
    
    private void Start()
    {
        _playerTransform = transform.parent;
    }

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
            gameObject.SetActive(false);
        }

        _targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y -1f, _playerTransform.position.z);

        other.transform.position = Vector3.MoveTowards(other.transform.position, _targetPosition, Time.deltaTime * pullingSpeed);
    }
}