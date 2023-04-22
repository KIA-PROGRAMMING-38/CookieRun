using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    [SerializeField]
    private CookieData _cookieData;

    public CookieData CookieData { set { _cookieData = value; } }

    private float _maxHp;

    private void Awake()
    {
        _maxHp = _cookieData.MaxHp;
    }
}
