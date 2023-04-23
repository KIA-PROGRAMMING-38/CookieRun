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
    
    private int _firstIndex = 0;
    private int _lastIndexOfEasySection = 2;
    private int normalSectionStartIndex = 3;
    private int _normalSectionIndex;
    private int _sectionIndex;
    private WaitForSeconds _waitForSeconds;
    private IEnumerator _spawnCoroutine;

    enum SectionSet
    {
        Default = 0,
        EasySection,
        NomalSection
    }

    private SectionSet _section;
    
    private void Start()
    {
        _section = SectionSet.Default;
        _normalSectionIndex = normalSectionStartIndex;
        
        _spawnCoroutine = SpawnCoroutineHelper();
        _waitForSeconds = new WaitForSeconds(_spawnCoolTime);
        
        StartCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnCoroutineHelper()
    {
        while (!GameManager.gameOver)
        {
            // EasySection을 뽑는다.
            if (_section == SectionSet.Default)
            {
                _sectionIndex = Random.Range(_firstIndex, _lastIndexOfEasySection + 1);
                _section = SectionSet.EasySection;
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
                    _section = SectionSet.Default;
                }
                
                else
                {
                    _section = SectionSet.NomalSection;
                }
            }
            
            Section section = _sectionPools[_sectionIndex].SpawnSection();
            section.transform.position = _spawnPosition.position;
            
            Debug.Log($"{_sectionIndex}번째 {_sectionPools[_sectionIndex].name} 실행됨");
            yield return _waitForSeconds;
        }
    }
}
