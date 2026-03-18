using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfo", menuName = "Quests/QuestInfo")]
public class QuestInfo : ScriptableObject
{
    public string title;
    public string description;
    public float duration;
    public int exp;
    public int guildExp;

    public Sprite sprite;
}
