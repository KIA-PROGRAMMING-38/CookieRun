using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Literal;

public class MagneticEffect : MonoBehaviour
{
    public float Duration = 3f;
    // 끌어당기는 속도
    public float pullingSpeed = 15f;
    
    private float _startTime;

    private Transform _playerTransform;
    
    private Vector3 _targetPosition;
    
    private AudioSource _audioSource;
    private AudioClip _magnetAudioClip;

    private void Awake()
    {
        _audioSource = GetComponentInParent<AudioSource>();
        _magnetAudioClip = DataManager.LoadAudioClip(AudioClipName.MAGNET);
    }

    private void Start()
    {
        _playerTransform = transform.parent;
    }

    private void OnEnable()
    {
        // 시작 시간 설정
        _startTime = Time.time;
        _audioSource.volume = 0.8f;
        _audioSource.PlayOneShot(_magnetAudioClip);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 경과시간이 지속시간을 넘으면
        if (Time.fixedTime >= _startTime + Duration)
        {
            _audioSource.volume = 0.5f;
            // 컴포넌트 비활성화
            gameObject.SetActive(false);
        }

        _targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y -1f, _playerTransform.position.z);

        other.transform.position = Vector3.MoveTowards(other.transform.position, _targetPosition, Time.deltaTime * pullingSpeed);
    }
}