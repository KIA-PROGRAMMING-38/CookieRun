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
            _sectionPoolIndex = Random.Range(_firstIndex, _lastIndex);

            Section section = _sectionPools[_sectionPoolIndex].SpawnSection();
            section.transform.position = _spawnPosition.position;
            
            Debug.Log($"{_sectionPoolIndex}번째 {_sectionPools[_sectionPoolIndex].name} 실행됨");
            yield return _waitForSeconds;
        }
    }
}
