using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    [SerializeField] QuestInfo questInfo;
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI text;

    public void OnPress()
    {
        print("button pressed");
        EventManager<QuestInfo>.TriggerEvent(Event.QuestStart, questInfo);
        EventManager.TriggerEvent(Event.QuestStart);
    }

    void OnValidate()
    {
        if (questInfo && text)
        {
            text.text = questInfo.title;
        }
        else
        {
            text.text = "Assign QuestInfo";
        }
    }
}
