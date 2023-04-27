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

    public GameObject jellyBean;
    public GameObject bearBig;
    

    private void OnEnable()
    {
        SetActiveRecursively(gameObject.transform, true);


        
        _rootJellybean = GetComponentInChildren<RootJellyBean>();
        _rootBearPink = GetComponentInChildren<RootBearPink>();

        if (_rootJellybean != null)
        {
        }
        
        if (_rootBearPink != null)
        {
        }
        
    }

    public void SetActiveRecursively(Transform parent, bool active)
    {
        parent.gameObject.SetActive(active);

        foreach (Transform child in parent)
        {
            SetActiveRecursively(child, active);
        }
    }

    private void ActivateChildren(Transform root)
    {
        foreach (Transform child in root)
        {
            JellyController jellyController = child.GetComponent<JellyController>();
            
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
