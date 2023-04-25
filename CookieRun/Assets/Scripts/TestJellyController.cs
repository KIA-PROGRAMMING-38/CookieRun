using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJellyController : MonoBehaviour
{
    private Jelly _jellyData;

    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();
        
        Activate(JellyKind.BearPink);
    }

    public void Activate(JellyKind jellyKind)
    {
        // if (gameObject.activeSelf)
        // {
        //     return;
        // }
        
        _jellyData = DataManager.Jellies[(int)jellyKind];
        BindData();
    }

    private void BindData()
    {
        string spriteName = $"jelly_{_jellyData.SpriteName}";
        _spriteRenderer.sprite = DataManager.LoadSprite(spriteName);
        
        ResizeCollider();
    }

    private void ResizeCollider()
    {
        float spriteRadius = _spriteRenderer.bounds.extents.x;
        _circleCollider.radius = spriteRadius;
    }
    
    private static string PLAYER_TAG = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            GameManager.UpdateScore(_jellyData.Score);
            gameObject.SetActive(false);
        }
    }
}
