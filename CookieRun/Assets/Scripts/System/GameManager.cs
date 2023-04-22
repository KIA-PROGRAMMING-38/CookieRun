using System;
using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    private static float _score;
    private float _elapsedTime;

    private void Awake()
    {
        gameOver = false;
        GameSpeed = 1f;
    }

    private void Update()
    {
        if (!PlayerData.isInvincible && !gameOver)
        {
            
            _elapsedTime += Time.deltaTime;
            PlayerData.HP -= _elapsedTime * 0.005f;
            Debug.Log($"현재 플레이어 HP : {PlayerData.HP}");    
        }
    }
    
    // 점수를 추가하는 메소드
    public static void UpdateScore(float scoreToAdd)
    {
        _score += scoreToAdd;
    }

    public static float GameSpeed { get; set; }

    public static void SetDefaultGameSpeed()
    {
        GameSpeed = 1f;
    }
}
