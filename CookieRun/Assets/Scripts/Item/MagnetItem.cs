using System;
using System.Collections;
using System.Collections.Generic;
using Literal;
using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    private PlayerController _playerController;

    private void OnTriggerEnter2D(Collider2D col)
    {
        _playerController = col.GetComponent<PlayerController>();

        if (_playerController != null)
        {
            _playerController.ActivateMagneticEffect();
            gameObject.SetActive(false);
        }
    }
}
