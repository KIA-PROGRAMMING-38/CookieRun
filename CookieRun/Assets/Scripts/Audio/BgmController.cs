using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private float _fadeDuration = 2f;
    private float _initialVolume;
    private IEnumerator _fadeOutSound;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.OnGameEnd -= StopBgm;
        GameManager.OnGameEnd += StopBgm;

        _initialVolume = _audioSource.volume;
        _fadeOutSound = FadeSound();
    }

    void StopBgm()
    {
        StartCoroutine(_fadeOutSound);
    }

    IEnumerator FadeSound()
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            
            _audioSource.volume = Mathf.Lerp(_initialVolume, 0f, elapsedTime / _fadeDuration);
            
            yield return null;
        }
        
        _audioSource.volume = 0f;
    }

    private void OnDestroy()
    {
        GameManager.OnGameEnd -= StopBgm;
    }
}
