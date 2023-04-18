using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveLeft : MonoBehaviour
{
    public float moveLeftSpeed;

    private void Start()
    {
        GameManager.GameSpeed = moveLeftSpeed;
    }

    void Update()
    {
        if (!GameManager.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * GameManager.GameSpeed);
        }
    }
}
