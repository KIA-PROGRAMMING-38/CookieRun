using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    private Text _totalScoreText;
    private IEnumerator _raiseScore;

    private void Awake()
    {
        _totalScoreText = GetComponent<Text>();
    }

    private int index;

    private void Start()
    {
        // _totalScoreText.text = $"{CookieUIModel.Score : #,0}";

        // Debug.Log($"CookieUIScore : {CookieUIModel.Score}");
        StartCoroutine(CountingScore(CookieUIModel.Score, 0));
        
        
    }

    IEnumerator CountingScore(float maxScore, float initialScore)
    {
        float duration = 0.9f;
        float offset = maxScore / duration;

        ++index;
        // Debug.Log($"index : {index}");
            
        while (initialScore < maxScore)
        {
            // Debug.Log($"intialScore : {maxScore}");
            
            initialScore += offset * Time.deltaTime;
            _totalScoreText.text = $"{initialScore: #,0}";
            yield return null;
        }

        initialScore = maxScore;
        _totalScoreText.text = $"{initialScore: #,0}";
    }
}
