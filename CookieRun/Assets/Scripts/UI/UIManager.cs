using System;
using UnityEngine;
using Model;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _hpbar;
    private float _nomalizeCurrentHp;

    private void Start()
    {
        CookieUIModel.OnChangeHp -= ShowCurrentHp;
        CookieUIModel.OnChangeHp += ShowCurrentHp;
    }

    private void ShowCurrentHp()
    {
        // 0에서 maxHp사이에서 Hp가 속하는 위치를 나타낸다.
        _nomalizeCurrentHp = Mathf.InverseLerp(
            0f, CookieUIModel.MaxHp, CookieUIModel.Hp);

        _hpbar.fillAmount = _nomalizeCurrentHp;
    }
}
