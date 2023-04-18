using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public PlayerData playerData;

    public Vector3 ActionPosition;

    // public ExplisionController explisionEffect;

    // public TestController testEffect;

    void TestFunction(Vector3 collisionPosition)
    {
        ActionPosition = collisionPosition;
    }
}
