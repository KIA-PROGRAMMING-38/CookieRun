using System;
using System.Collections;
using UnityEngine;
using Model;


public class GameManager : MonoBehaviour
{
    public static event Action OnGameEnd;

    private static bool _gameOver;
    public static bool GameOver
    {
        get => _gameOver;

        set
        {
            _gameOver = value;
            if (value == true)
            {
                OnGameEnd?.Invoke();
            }
        }
    }
    // private static float _score;
    private float _elapsedTime;

    private void Awake()
    {
        GameOver = false;
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
