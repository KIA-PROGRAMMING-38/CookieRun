using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    private static float score;
    
    private void Awake()
    {
        gameOver = false;
    }

    // 점수를 추가하는 메소드
    public static void UpdateScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }
}
