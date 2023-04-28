using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] private float _waitSeconds = 3f;

    private float _startTime;
    private void Awake()
    {
        GameManager.OnGameEnd -= Ativate;
        GameManager.OnGameEnd += Ativate;
        
        _startTime = Time.time;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Ativate()
    {
        if (Time.fixedTime >= _startTime + _waitSeconds)
        {
            gameObject.SetActive(true);
        }
    }
}
