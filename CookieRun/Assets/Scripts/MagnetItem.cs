using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    private Vector2 _playerPosition;
    private IEnumerator _onBuffCoroutine;

    // 지속시간을 표현하기위한 변수들
    private float _elapsedTime;
    public float duration = 3f;
    
    // 젤리가 끌어당겨질 방향
    private Vector2 _lookDirection;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _onBuffCoroutine = OnBuffCoroutineHelper(duration);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            // // 젤리가 끌어당겨질 방향 구함.
            // _lookDirection = (col.transform.position - transform.position).normalized;
            //
            // // sprite를 없애줌으로써 Item을 획득한 것처럼 보이게 한다.
            // _spriteRenderer.sprite = null;
            //
            // // 플레이어의 y좌표로 Item을 끌어당기기 위해 플레이어의 좌표를 저장
            // _playerPosition = col.transform.position;
            //
            // // buff시작
            // StartCoroutine(_onBuffCoroutine);
        }
    }

    private IEnumerator OnBuffCoroutineHelper(float duration)
    {
        while (_elapsedTime <= duration)
        {
            _elapsedTime += Time.deltaTime;
            
            Debug.Log("젤리 끌어당기는 중");
            // if (jelly.transform.position.y >= _playerPosition.y)
            // {
            //     // jelly.gameobject.Translate(0, _lookDirection.y, 0);    
            // }

            yield return null;
        }   
        
        gameObject.SetActive(false);
    }
}
