using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Pool;

public class SectionPool : MonoBehaviour
{
    private WaitForSeconds _spawnCoolTime = new WaitForSeconds(1f);

    private IObjectPool<Section> _pool;

    public Section sectionPrefab;

    private void Awake()
    {
        _pool = new ObjectPool<Section>(
            CreateSection, OnGetSection, OnReleaseSection, OnDestroySection, 
            defaultCapacity: 2, maxSize: 5);
    }
    

    // 게임이 끝날때까지 Section을 생성해야 한다.
    public Section SpawnSection()
    {
        Section section = _pool.Get();

        return section;
    }

    private Section CreateSection()
    {
        Section section = Instantiate(sectionPrefab).GetComponent<Section>();
        section.SetManagedPool(_pool);
        return section;
    }

    void OnGetSection(Section section)
    {
        section.gameObject.SetActive(true);
    }

    void OnReleaseSection(Section section)
    {
        section.gameObject.SetActive(false);
    }

    private void OnDestroySection(Section section)
    {
        Destroy(section.gameObject);
    }
}
