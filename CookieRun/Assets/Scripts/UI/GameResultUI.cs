using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] private float _waitSeconds = 3f;
    private Transform _backgroundUI;
    
    private IEnumerator _showUICoroutine;
    private WaitForSeconds _waitForSeconds;
    
    private void Awake()
    {
        GameManager.OnGameEnd -= Ativate;
        GameManager.OnGameEnd += Ativate;
        _backgroundUI = transform.GetChild(0);
        _waitForSeconds = new WaitForSeconds(_waitSeconds);
        
        gameObject.SetActive(false);
    }

    private IEnumerator Start()
    {
        yield return _waitForSeconds;
        
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
    }
    
    private void Ativate()
    {
        gameObject.SetActive(true);
    }

    // private void OnEnable()
    // {
    //     if (_showUICoroutine != null)
    //     {
    //         StopCoroutine(_showUICoroutine);
    //     }
    //
    //     _showUICoroutine = ShowUI();
    //     StartCoroutine(_showUICoroutine);
    // }
    //
    // IEnumerator ShowUI()
    // {
    //     yield return _waitForSeconds;
    //     //_image.enabled = true;
    // }
    
}
