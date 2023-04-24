using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.Pool;

public class Section : MonoBehaviour
{
    private IObjectPool<Section> _managedPool;
    private Transform[] _allChildren;

    private void Awake()
    {
        _allChildren = GetComponentsInChildren<Transform>();
    }

    private void OnEnable()
    {
        foreach (Transform child in _allChildren)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void SetManagedPool(IObjectPool<Section> pool)
    {
        _managedPool = pool;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LeftBound"))
        {
            DestroySection();
        }
    }

    // LeftBound에 충돌하면 호출할 메소드
    public void DestroySection()
    {
        _managedPool.Release(this);
    }
}
