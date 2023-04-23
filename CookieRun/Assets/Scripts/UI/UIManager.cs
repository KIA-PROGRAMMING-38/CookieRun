using System;
using UnityEngine;
using Model;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _hpbar;
    private float _nomalizeCurrentHp;

    [SerializeField] private Text _scoreText;

    [SerializeField] private Image _HpEffect;

    [SerializeField] private RectTransform _leftPoint;

    private Vector2 _effectLeft;
    private Vector2 _effectRight;

    private void Start()
    {
        // Model의 Hp가 변할때를 구독한다
        CookieUIModel.OnChangeHp -= ShowCurrentHp;
        CookieUIModel.OnChangeHp += ShowCurrentHp;

        // Model의 Score가 변할때를 구독한다.
        CookieUIModel.OnChangeScore -= ShowScore;
        CookieUIModel.OnChangeScore += ShowScore;

        _effectLeft = _leftPoint.position;
        _effectRight = _HpEffect.rectTransform.position;
    }

    private void ShowCurrentHp()
    {
        // 0에서 maxHp사이에서 Hp가 속하는 위치를 나타낸다.
        _nomalizeCurrentHp = Mathf.InverseLerp(
            0f, CookieUIModel.MaxHp, CookieUIModel.Hp);
        
        _hpbar.fillAmount = _nomalizeCurrentHp;
        
        _HpEffect.rectTransform.position = Vector2.Lerp(_effectLeft,_effectRight, _nomalizeCurrentHp);

    }

    private void ShowScore()
    {
        _scoreText.text = $"{CookieUIModel.Score : #,0}";
    }
}
