using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlideButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static event Action SlideButtonDown;
    public static event Action SlideButtonUp;

    private Button _slideButton;

    private void Awake()
    {
        _slideButton = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SlideButtonDown?.Invoke();
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        SlideButtonUp?.Invoke();
    }
}
