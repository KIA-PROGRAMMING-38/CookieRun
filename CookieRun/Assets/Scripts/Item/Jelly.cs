using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public float jellyScore;

    private Vector2 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = _initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Player에게 닿으면 점수 획득, 아이템은 비활성화
        if (col.CompareTag("Player"))
        {
            GameManager.UpdateScore(jellyScore);

            gameObject.SetActive(false);
        }
        
        if (col.CompareTag("LeftBound"))
        {
            gameObject.SetActive(false);
        }
    }
}
