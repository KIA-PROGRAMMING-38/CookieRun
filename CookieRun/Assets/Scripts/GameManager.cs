using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static float score;
    
    private void Awake()
    {
        gameOver = false;
    }

    public static void UpdateScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }
}
