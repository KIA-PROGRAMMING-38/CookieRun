using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Cookie Data", menuName = "Scriptable Object/Cookie Data", order = int.MaxValue )]
public class CookieData : ScriptableObject
{
    [SerializeField]
    private string _cookieName;
    public string CookieName { get { return _cookieName; } }

    [SerializeField]
    private float _maxHp;
    public float MaxHp { get { return _maxHp; } }

    [SerializeField]
    private float _lightSpeed;
    public float LightSpeed { get { return _lightSpeed; } }

    [SerializeField]
    private float _takenDamage;
    public float TakenDamage { get { return _takenDamage; } }

}
