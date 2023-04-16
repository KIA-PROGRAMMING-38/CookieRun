using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    public float jellyScore;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.UpdateScore(jellyScore);
            Debug.Log(GameManager.score);
            gameObject.SetActive(false);
        }
    }
}
