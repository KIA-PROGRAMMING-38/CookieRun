using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;

public class MoveLeft : MonoBehaviour
{
    public float moveLeftSpeed;
    private Vector2 _moveleft = Vector2.left;

    private void Start()
    {
        GameManager.OnGameEnd -= StopMove;
        GameManager.OnGameEnd += StopMove;
    }

    void Update()
    {
        transform.Translate(_moveleft * Time.deltaTime * moveLeftSpeed * GameManager.GameSpeed);
    }

    void StopMove() => GameManager.GameSpeed = 0f;

    private void OnDestroy()
    {
        GameManager.OnGameEnd -= StopMove;
    }
}