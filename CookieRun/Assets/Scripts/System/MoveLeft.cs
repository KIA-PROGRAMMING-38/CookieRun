using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveLeft : MonoBehaviour
{
    public float moveLeftSpeed;
    private Vector2 _moveleft = Vector2.left;

    private void Start()
    {
        //GameManager.OnGameEnd -= 
    }

    void Update()
    {
        if (!GameManager.GameOver)
        {
            transform.Translate(_moveleft * Time.deltaTime * moveLeftSpeed * GameManager.GameSpeed);
        }
    }

    // void StopMove() =>
}