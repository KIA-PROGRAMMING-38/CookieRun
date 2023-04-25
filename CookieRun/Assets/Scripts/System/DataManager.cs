using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Rendering;
using UnityEngine;

public static class DataManager
{
    private static List<Jelly> s_jellies;
    public static List<Jelly> Jellies => s_jellies;

    static DataManager()
    {
        Init();
    }

    public static void Init()
    {
        TextAsset jellyCsvFile = LoadFile<TextAsset>("Jelly");
        s_jellies = CsvParser.Parse<Jelly>(jellyCsvFile);
    }
    
    const string DATA_FILE_ROOT_DIRECTORY = "Data";
    private static T LoadFile<T>(string filename) where T : UnityEngine.Object
    {
        string filePath = Path.Combine(DATA_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<T>(filePath);
    }
    
    const string SPRITE_FILE_ROOT_DIRECTORY = "Sprites";
    const string JELLY_DIRECTORY = "Jelly";
    public static Sprite LoadSprite(string filename)
    {
        string filePath = Path.Combine(SPRITE_FILE_ROOT_DIRECTORY, JELLY_DIRECTORY, filename);

        Debug.Log(Resources.Load<Sprite>(filePath));
        return Resources.Load<Sprite>(filePath);
    }
}
