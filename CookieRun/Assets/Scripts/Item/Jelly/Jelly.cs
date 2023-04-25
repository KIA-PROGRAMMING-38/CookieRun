using System.Collections;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using UnityEngine;

public class Jelly
{
    [Index(0)]
    public int Id { get; set; }
    [Index(1)]
    public string Name { get; set; }
    [Index(2)]
    public string SpriteName { get; set; }
    [Index(3)]
    public int Score { get; set; }
}

public enum JellyKind
{
    JellyBean,
    BearPink,
    BearYellow,
    BearBig
}
