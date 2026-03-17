using UnityEngine;

public class GuildManager : MonoSingleton<GuildManager>
{
    int exp;

    void Start()
    {
        EventManager<int>.StartListening(Event.GainGuildExp, AddExp);
    }

    void AddExp(int amount)
    {
        exp += amount;
        MyLogger.Log($"AddGuildExp: {amount}, GuildExp: {exp}", LogType.Info);
    }
}
