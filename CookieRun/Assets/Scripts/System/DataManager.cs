using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Rendering;
using UnityEngine;

public enum SectionType
{
    Easy,
    Normal,
    TypeCount
}

public static class DataManager
{
    private static Section[][] s_sections = new Section[(int)SectionType.TypeCount][];
    public static Section[][] Sections => s_sections;

    private static List<Jelly> s_jellies;
    public static List<Jelly> Jellies => s_jellies;

    private static List<Obstacle> s_enemies;
    public static List<Obstacle> Enemies => s_enemies;

    static DataManager()
    {
        Init();
    }
    
    public static void Init()
    {
        Section[] easySections = Resources.LoadAll<Section>("Sections/Easy");
        Section[] normalSections = Resources.LoadAll<Section>("Sections/Normal");

        s_sections[(int)SectionType.Easy] = easySections;
        s_sections[(int)SectionType.Normal] = normalSections;
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
        filePath = filePath.Replace("\r", "");
        
        return Resources.Load<RuntimeAnimatorController>(filePath);
    }

    private const string SOUND_FILE_ROOT_DIRECTORY = "Sound";
    public static AudioClip LoadAudioClip(string filename)
    {
        string filePath = Path.Combine(SOUND_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<AudioClip>(filePath);
    }
}
