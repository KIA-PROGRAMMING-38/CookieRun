using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Transform _reponeTransform;
    
    private Transform _moveBackground;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Background"))
        {
            col.gameObject.transform.position = _reponeTransform.position;
        }
    }
}
