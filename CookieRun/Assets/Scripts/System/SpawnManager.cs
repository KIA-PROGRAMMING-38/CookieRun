using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private SectionPool[] _sectionPools;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _spawnCoolTime = 4f;
    
    
    private WaitForSeconds _waitForSeconds;
    private IEnumerator _spawnCoroutine;

    

    private void Start()
    {
        _sectionSet = SectionSet.Default;
        _normalSectionIndex = normalSectionStartIndex;

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
    private int _easyIndex = (int)SectionType.Easy;
    private int _normalIndex = (int)SectionType.Normal;
    private int _sectionType;
    IEnumerator SpawnSection()
    {
        while (true)
        {
            _sectionType = GetSectionType();
            int randomIndex = Random.Range(0, 2);
            Section sectionPrefab = DataManager.Sections[_sectionType][randomIndex];

            if (_sectionInstance[_sectionType][randomIndex] == null)
            {
                _sectionInstance[_sectionType][randomIndex] = Instantiate(sectionPrefab);
            }

            else
            {
                _sectionInstance[_sectionType][randomIndex].Activate();
            }

            _sectionInstance[_sectionType][randomIndex].transform.position = _spawnPosition.position;
            
            yield return _waitForSeconds;
        }
    }

    enum SectionSet
    {
        Default = 0,
        Easy,
        Normal
    }

    private SectionSet _sectionSet;
    int normalCount = 0;
    
    private int _sectionIndex;
    private int _firstIndex = 0;
    private int _lastIndexOfEasySection = 2;
    private int normalSectionStartIndex = 3;
    private int _normalSectionIndex;
    private int _previousIndex;
    private int _normalSectionsMaxCount;

    // Easy,Normal중에서 Get해야 한다.
    private int GetSectionType()
    {
        int sectionType;
        
        
        if (_sectionSet == SectionSet.Default)
        {
            sectionType = _easyIndex;
            _sectionSet = SectionSet.Easy;
        }

        else
        {
            ++normalCount;
            sectionType = _normalIndex;
            if (normalCount == _normalSectionsMaxCount)
            {
                normalCount = 0;
                _sectionSet = SectionSet.Default;    
            }
        }

        return sectionType;
    }
    private int GetRandomIndex()
    {
        // EasySection을 뽑는다.
        if (_sectionSet == SectionSet.Default)
        {
            _sectionIndex = Random.Range(_firstIndex, _lastIndexOfEasySection + 1);
                
            while (_sectionIndex == _previousIndex)
            {
                _sectionIndex = Random.Range(_firstIndex, _lastIndexOfEasySection + 1);    
            }

            _previousIndex = _sectionIndex;
                
            _sectionSet = SectionSet.Easy;
        }

        // normalSection을 차례대로 실행한다.
        else
        {
            _sectionIndex = _normalSectionIndex;
            ++_normalSectionIndex;

            // 순서대로 다 실행했다면 normalSectionIndex를 초기화 시키고 다시 EasySection을 뽑을 수 있게 section을 설정한다.
            if (_normalSectionIndex >= _sectionPools.Length)
            {
                _normalSectionIndex = normalSectionStartIndex;
                _sectionSet = SectionSet.Default;
            }
                
            else
            {
                _sectionSet = SectionSet.Normal;
            }
        }

        return _sectionIndex;
    }
}
