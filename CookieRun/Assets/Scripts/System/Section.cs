using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.Pool;

public class Section : MonoBehaviour
{
    private RootJellyBean _rootJellybean;
    private RootBearPink _rootBearPink;
    
    private IObjectPool<Section> _managedPool;

    private void OnEnable()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
        
        _rootJellybean = GetComponentInChildren<RootJellyBean>();
        _rootBearPink = GetComponentInChildren<RootBearPink>();

        ActivateJellyChildren(_rootJellybean.gameObject.transform, JellyKind.JellyBean);
        ActivateJellyChildren(_rootBearPink.gameObject.transform, JellyKind.BearPink);
    }

    private void ActivateJellyChildren(Transform root, JellyKind jellyKind)
    {
        foreach (Transform child in root)
        {
            TestJellyController jellyController = child.GetComponent<TestJellyController>();
            jellyController.Activate(jellyKind);
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
