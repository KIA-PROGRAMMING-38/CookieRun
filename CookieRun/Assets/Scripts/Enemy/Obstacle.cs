
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "ScriptableObjects/ObstacleScriptableObject", order = 2)]
public class Obstacle : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public AnimatorOverrideController Animator;
}
