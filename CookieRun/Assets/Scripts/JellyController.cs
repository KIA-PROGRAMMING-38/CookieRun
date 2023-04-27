using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JellyController : MonoBehaviour
{
    [SerializeField] private Jelly _jellyData;

    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider;
    
    private Vector2 _initialPosition;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();
        
        _initialPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = _initialPosition;
    }

    private void Start()
    {
        _spriteRenderer.sprite = _jellyData.Sprite;
        
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
