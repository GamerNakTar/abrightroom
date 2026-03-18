using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class MyLogger
{
    const string MenuPath = "Tools/Logger/";
    static LogType logLevel = GetInitialLogLevel();

    static LogType GetInitialLogLevel()
    {
#if UNITY_EDITOR
        return (LogType)EditorPrefs.GetInt(MenuPath, (int)LogType.Info);
#else
        return LogType.Info; // 빌드된 게임에서는 기본적으로 Info 레벨
#endif
    }

#if UNITY_EDITOR
    [MenuItem(MenuPath + "Info", false, 1)]
    static void SetLogInfo() => SetLogLevel(LogType.Info);

    [MenuItem(MenuPath + "Warning", false, 2)]
    static void SetLogWarning() => SetLogLevel(LogType.Warning);

    [MenuItem(MenuPath + "Error", false, 3)]
    static void SetLogError() => SetLogLevel(LogType.Error);

    [MenuItem(MenuPath + "Info", true)]
    static bool ValidateInfo() => CheckLogLevel(LogType.Info);

    [MenuItem(MenuPath + "Warning", true)]
    static bool ValidateWarning() => CheckLogLevel(LogType.Warning);

    [MenuItem(MenuPath + "Error", true)]
    static bool ValidateError() => CheckLogLevel(LogType.Error);

    static void SetLogLevel(LogType level)
    {
        logLevel = level;
        EditorPrefs.SetInt(MenuPath, (int)logLevel);
    }

    static bool CheckLogLevel(LogType level)
    {
        Menu.SetChecked(MenuPath + level, logLevel == level);
        return true;
    }
#endif

    public static void Log(string msg, LogType type)
    {
        if (type < logLevel) return;

        switch (type)
        {
            case LogType.Info:
                Debug.Log(msg);
                break;
            case LogType.Warning:
                Debug.LogWarning(msg);
                break;
            case LogType.Error:
                Debug.LogError(msg);
                break;
        }
    }
}

public enum LogType
{
    Info,
    Warning,
    Error
}
