using System;
using System.Collections;
using UnityEngine;
using Model;


public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    // private static float _score;
    private float _elapsedTime;

    private void Awake()
    {
        gameOver = false;
        GameSpeed = 1f;
    }
    

    // 점수를 추가하는 메소드
    public static void UpdateScore(float scoreToAdd)
    {
        CookieUIModel.Score += scoreToAdd;
    }

    public static float GameSpeed { get; set; }

    public static void SetDefaultGameSpeed()
    {
        GameSpeed = 1f;
    }

  
}
