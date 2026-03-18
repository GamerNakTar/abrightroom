public class QuestManager : MonoSingleton<QuestManager>
{
    void Start()
    {
        EventManager<QuestInfo>.StartListening(Event.QuestStart, OnQuestStart);
        EventManager<QuestInfo>.StartListening(Event.QuestComplete, OnQuestComplete);
    }

    void OnQuestStart(QuestInfo info)
    {
    }

    void OnQuestComplete(QuestInfo info)
    {
        EventManager<int>.TriggerEvent(Event.GainExp, info.exp);
        EventManager<int>.TriggerEvent(Event.GainGuildExp, info.guildExp);
    }
}
