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

    private const string SOUND_FILE_ROOT_DIRECTORY = "Sound";
    public static AudioClip LoadAudioClip(string filename)
    {
        string filePath = Path.Combine(SOUND_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<AudioClip>(filePath);
    }
}
