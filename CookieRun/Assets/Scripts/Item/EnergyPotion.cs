using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPotion : MonoBehaviour
{
    private PlayerController _playerController;
    public float hpRecoveryValue = 10f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // 플레이어의 컴포넌트를 가져온다.
            _playerController = col.GetComponent<PlayerController>();
            
            // hp 회복
            _playerController.ChangesHpByAmount(hpRecoveryValue);
            _playerController.PlaySoundOnGetHp();

            gameObject.SetActive(false);
        }
    }
}
