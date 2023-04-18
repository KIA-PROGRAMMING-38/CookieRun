using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    private static float _score;

    private void Awake()
    {
        gameOver = false;
    }

    // 점수를 추가하는 메소드
    public static void UpdateScore(float scoreToAdd)
    {
        _score += scoreToAdd;
    }

    public static float GameSpeed { get; set; }

    public static void SetDefaultGameSpeed()
    {
        GameSpeed /= 2f;
    }
}
