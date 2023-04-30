using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LightSpeedItem : MonoBehaviour
{

    [SerializeField] private float _lightSpeed = 2f;
    private PlayerController _playerController;
    private IEnumerator _lightSpeedCoroutine;

    // Player랑만 충돌검사를 하게 레이어 구성을 했다.
    private void OnTriggerEnter2D(Collider2D col)
    {
        _playerController = col.GetComponent<PlayerController>();
        _lightSpeedCoroutine = _playerController.LightSpeedInvincible();

        if (_playerController != null)
        {
            _playerController.SetActiveCoroutine(_lightSpeedCoroutine);
            _playerController.ActivateDashEffect(true);
            PlayerData.IsLightSpeed = true;
            // SetAcitveLightSpeedTimeTrue?.Invoke();
            // GameSpeed를 2배로 올린다.
            GameManager.GameSpeed = _lightSpeed;
        }

        gameObject.SetActive(false);
    }
}