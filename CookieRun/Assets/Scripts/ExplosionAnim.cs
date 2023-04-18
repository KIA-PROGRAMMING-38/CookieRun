using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnim : MonoBehaviour
{
    private Transform explosionPosition;

    private void Awake()
    {
        // 최상위 부모 오브젝트 접근
        //_playerData = transform.root.GetComponent<PlayerData>();
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
