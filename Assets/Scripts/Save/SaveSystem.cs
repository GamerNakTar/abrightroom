using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static SaveData CurSaveData { get; set; }

    const string FolderName = "Save";
    const string FileName = "SaveData.abr";

    static string SavePath => Path.Combine(Application.dataPath, FolderName);
    static string FilePath => Path.Combine(SavePath, FileName);

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        MyLogger.Log("Initializing SaveSystem", LogType.Info);
        Load();
    }

    public static void Save(SaveData saveData = null)
    {
        saveData ??= CurSaveData;

        if (!Directory.Exists(SavePath)) Directory.CreateDirectory(SavePath);

        File.WriteAllText(FilePath, JsonUtility.ToJson(saveData, true));
    }

    public static SaveData Load()
    {
        if (!File.Exists(FilePath))
        {
            CurSaveData = new SaveData();
            Save(CurSaveData);
            return CurSaveData;
        }

        try
        {
            string json = File.ReadAllText(FilePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurSaveData = data ?? new SaveData();
            return CurSaveData;
        }
        catch (Exception e)
        {
            MyLogger.Log($"Load failed: {e.Message}", LogType.Error);
            return new SaveData();
        }
    }
}
