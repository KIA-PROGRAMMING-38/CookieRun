using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] private float _waitSeconds = 3f;

    private IEnumerator _showUICoroutine;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        GameManager.OnGameEnd -= Activate;
        GameManager.OnGameEnd += Activate;
        
        _waitForSeconds = new WaitForSeconds(_waitSeconds);
        
        Debug.Log("hiiiiiii");
        
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
    
    private void Activate()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.OnGameEnd -= Activate;
    }
}
