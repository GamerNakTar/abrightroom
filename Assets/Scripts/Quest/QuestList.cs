using UnityEngine;

public class QuestList : MonoBehaviour
{
    void Start()
    {
        EventManager.StartListening(Event.QuestStart, () => gameObject.SetActive(false));
        EventManager.StartListening(Event.QuestComplete, () => gameObject.SetActive(true));
    }
}
