public class PlayerManager : MonoSingleton<PlayerManager>
{
    PlayerStat stat;

    void Awake()
    {
        stat = SaveSystem.CurSaveData.Stat;
    }

    void Start()
    {
        EventManager<int>.StartListening(Event.GainExp, AddExp);
    }

    void AddExp(int exp)
    {
        stat.Exp += exp;
        MyLogger.Log($"add {exp} exp, exp: {stat.Exp}", LogType.Info);
    }
}
