public class SaveData
{
    public readonly PlayerStat Stat;

    public SaveData(PlayerStat stat)
    {
        Stat = stat;
    }

    public SaveData()
    {
        Stat = new PlayerStat();
    }
}
