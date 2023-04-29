using System;
using UnityEngine;
using Model;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Image _hpbar;
    private float _normalizeCurrentHp;

    [SerializeField] private Text _scoreText;

    [SerializeField] private Image _hpEffect;

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
        _effectRight = _hpEffect.rectTransform.position;
    }

    private void ShowCurrentHp()
    {
        // 0에서 maxHp사이에서 Hp가 속하는 위치를 나타낸다.
        _normalizeCurrentHp = Mathf.InverseLerp(
            0f, CookieUIModel.MaxHp, CookieUIModel.Hp);
        
        _hpbar.fillAmount = _normalizeCurrentHp;
        
        _hpEffect.rectTransform.position = Vector2.Lerp(_effectLeft,_effectRight, _normalizeCurrentHp);

    }

    private void ShowScore()
    {
        _scoreText.text = $"{CookieUIModel.Score : #,0}";
    }
    
    private void OnDestroy()
    {
        CookieUIModel.OnChangeHp -= ShowCurrentHp;
        CookieUIModel.OnChangeScore -= ShowScore;
    }
}
