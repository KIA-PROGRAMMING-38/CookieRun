using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour
{
    public static event Action OnClickJumpButton;

    public void JumpClick()
    {
        OnClickJumpButton?.Invoke();
    }
}
