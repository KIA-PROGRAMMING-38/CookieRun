using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpeedItem : MonoBehaviour
{
    public float lightSpeed = 2f;
    private PlayerController _playerController;
    private PlayerData _playerData;
    private IEnumerator _invincible;
    private PlayerAnimController _playerAnimController;

    // Player랑만 충돌검사를 하게 레이어 구성을 했다.
    private void OnTriggerEnter2D(Collider2D col)
    {
        _playerData = col.GetComponent<PlayerData>();
        _playerController = col.GetComponent<PlayerController>();
        _playerAnimController = col.GetComponent<PlayerAnimController>();
        
        if (_playerController != null)
        {
            _playerController.ActiveInvincibleCoroutine();
            _playerController.ActivateDashEffect(true);
            _playerData.isLightSpeed = true;
        }
        
        // GameSpeed를 2배로 올린다.
        GameManager.GameSpeed *= lightSpeed;

        gameObject.SetActive(false);
    }
}