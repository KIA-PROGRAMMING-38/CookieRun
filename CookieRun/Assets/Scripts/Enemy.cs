using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerData _playerData;
    private PlayerAnimController _playerAnimController;
    private void OnTriggerEnter2D(Collider2D col)
    {
        _playerData = col.GetComponent<PlayerData>();
        _playerAnimController = col.GetComponent<PlayerAnimController>();

        if (_playerData != null && _playerData.isLightSpeed)
        {
            gameObject.SetActive(false);
            _playerAnimController.animationAction();
        }
    }
}
