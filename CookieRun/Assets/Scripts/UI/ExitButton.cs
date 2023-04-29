using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ExitGame);
    }

    public void ExitGame()
    {
// 코드가 에티터 내에서 컴파일되면 실행
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

        // 플레이어를 빌드하면 Unity_Editor는 거짓. 아래의 구문이 실행
#else
    Application.Quit();
    
#endif
    }
}
