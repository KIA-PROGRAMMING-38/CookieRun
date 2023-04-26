using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Rendering;
using UnityEngine;

public static class DataManager
{
    private static List<Jelly> s_jellies;
    public static List<Jelly> Jellies => s_jellies;

    private static List<Enemy> s_enemies;
    public static List<Enemy> Enemies => s_enemies;

    static DataManager()
    {
        Init();
    }

    public static void Init()
    {
        TextAsset jellyCsvFile = LoadFile<TextAsset>("Jelly");
        s_jellies = CsvParser.Parse<Jelly>(jellyCsvFile);

        TextAsset enemyCsvFile = LoadFile<TextAsset>("Enemy");
        s_enemies = CsvParser.Parse<Enemy>(enemyCsvFile);
    }
    
    const string DATA_FILE_ROOT_DIRECTORY = "Data";
    private static T LoadFile<T>(string filename) where T : UnityEngine.Object
    {
        string filePath = Path.Combine(DATA_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<T>(filePath);
    }
    
    const string SPRITE_FILE_ROOT_DIRECTORY = "Sprites";
    const string JELLY_DIRECTORY = "Jelly";
    public static Sprite LoadJellySprite(string filename)
    {
        string filePath = Path.Combine(SPRITE_FILE_ROOT_DIRECTORY, JELLY_DIRECTORY, filename);
        
        return Resources.Load<Sprite>(filePath);
    }

    private const string ENEMY_DIRECTORY = "Enemy";
    public static Sprite LoadEnemySprite(string filename)
    {
        string filePath = Path.Combine(SPRITE_FILE_ROOT_DIRECTORY, ENEMY_DIRECTORY, filename);
        
        return Resources.Load<Sprite>(filePath);
    }

    private const string ANIMATOR_FILE_ROOT_DIRECTORY = "AnimatorOverride";
    public static RuntimeAnimatorController LoadAnimatorController(string filename)
    {
        string filePath = Path.Combine(ANIMATOR_FILE_ROOT_DIRECTORY, ENEMY_DIRECTORY, filename);
        
        return Resources.Load<RuntimeAnimatorController>(filePath);
    }
}