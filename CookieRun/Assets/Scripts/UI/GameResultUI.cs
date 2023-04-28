using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] private float _waitSeconds = 3f;
    private Image _image;
    private IEnumerator _showUICoroutine;
    private WaitForSeconds _waitForSeconds;
    
    private void Awake()
    {
        GameManager.OnGameEnd -= Ativate;
        GameManager.OnGameEnd += Ativate;
        _image = GetComponentInChildren<Image>();
        _waitForSeconds = new WaitForSeconds(_waitSeconds);
    }

    private void Start()
    {
        _image.enabled = false;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (_showUICoroutine != null)
        {
            StopCoroutine(_showUICoroutine);
        }

        _showUICoroutine = ShowUI();
        StartCoroutine(_showUICoroutine);
    }

    IEnumerator ShowUI()
    {
        yield return _waitForSeconds;
        _image.enabled = true;
    }
    private void Ativate()
    {
        gameObject.SetActive(true);
    }
}
