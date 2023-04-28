using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _spawnCoolTime = 4f;
    
    
    private WaitForSeconds _waitForSeconds;
    private IEnumerator _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = SpawnSection(); 
        _waitForSeconds = new WaitForSeconds(_spawnCoolTime);

        // Instantiate한 Section을 담기 위한 배열
        _sectionInstance = new Section[(int)SectionType.TypeCount][];
        _sectionInstance[(int)SectionType.Easy] = new Section[DataManager.Sections[(int)SectionType.Easy].Length];
        _sectionInstance[(int)SectionType.Normal] = new Section[DataManager.Sections[(int)SectionType.Normal].Length];
        _normalSectionsMaxCount = DataManager.Sections[(int)SectionType.Normal].Length;
        
        StartCoroutine(_spawnCoroutine);
        
        GameManager.OnGameEnd -= StopSpawnSection;
        GameManager.OnGameEnd += StopSpawnSection;
    }
    
    private void StopSpawnSection()
    {
        StopCoroutine(_spawnCoroutine);
    }

    private Section[][] _sectionInstance;
    
    private int _sectionType;
    IEnumerator SpawnSection()
    {
        while (true)
        {
            GetSection();

            Section sectionPrefab = DataManager.Sections[_sectionType][_sectionIndex];

            if (_sectionInstance[_sectionType][_sectionIndex] == null)
            {
                _sectionInstance[_sectionType][_sectionIndex] = Instantiate(sectionPrefab);
            }

            else
            {
                _sectionInstance[_sectionType][_sectionIndex].Activate();
            }

            _sectionInstance[_sectionType][_sectionIndex].transform.position = _spawnPosition.position;
            
            yield return _waitForSeconds;
        }
    }
    
    private int _normalSectionsMaxCount;
    private bool _isNormal = false;
    private int _easyIndex;
    private int _normalIndex;
    // Easy,Normal중에서 Get해야 한다.

    private int _sectionIndex;
    private void GetSection()
    {
        if (_isNormal == false)
        {
            _isNormal = true;
            _sectionType = (int)SectionType.Easy;
            _sectionIndex = Random.Range(0, DataManager.Sections[(int)SectionType.Easy].Length);

            return;
        }

        _sectionIndex = _normalIndex;

        ++_normalIndex;
        _sectionType = (int)SectionType.Normal;
        
        if (_sectionIndex == _normalSectionsMaxCount - 1)
        {
            _isNormal = false;
            _normalIndex = 0;
        }
    }
}
