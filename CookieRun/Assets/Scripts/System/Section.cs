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

    private void OnEnable()
    {
        Activate();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
    }

    // public void SetManagedPool(IObjectPool<Section> pool)
    // {
    //     _managedPool = pool;
    // }
    //
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LeftBound"))
        {
            gameObject.SetActive(false);
        }
    }
    //
    // // LeftBound에 충돌하면 호출할 메소드
    // public void DestroySection()
    // {
    //     _managedPool.Release(this);
    // }
}
