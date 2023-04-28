using System.Collections;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Jelly", menuName = "ScriptableObjects/JellyScriptableObject", order = 1)]
public class Jelly : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public int Score;
}
