using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerData _playerData;
    private void OnTriggerEnter2D(Collider2D col)
    {
        _playerData = col.GetComponent<PlayerData>();

        if (_playerData != null && _playerData.isLightSpeed)
        {
            gameObject.SetActive(false);
        }
    }
}
