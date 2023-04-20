using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private SectionPool[] _sectionPools;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _spawnCoolTime = 3f;

    private int _sectionPoolIndex;
    private int _firstIndex = 0;
    private int _lastIndex;
    private WaitForSeconds _waitForSeconds;
    private IEnumerator _spawnCoroutine;
    private int _currentIndex;
    private int _previousIndex;
    
    private void Start()
    {
        _lastIndex = _sectionPools.Length;
        _spawnCoroutine = SpawnCoroutineHelper();
        _waitForSeconds = new WaitForSeconds(_spawnCoolTime);
        
        StartCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnCoroutineHelper()
    {
        while (!GameManager.gameOver)
        {
            _currentIndex = Random.Range(_firstIndex, _lastIndex);

            // 이전인덱스가 현재 인덱스가 아닐때까지
            while (_currentIndex == _previousIndex)
            {
                _currentIndex = Random.Range(_firstIndex, _lastIndex);
            }

            _previousIndex = _currentIndex;

            Section section = _sectionPools[_currentIndex].SpawnSection();
            section.transform.position = _spawnPosition.position;
            
            Debug.Log($"{_currentIndex}번째 {_sectionPools[_currentIndex].name} 실행됨");
            yield return _waitForSeconds;
        }
    }
}
