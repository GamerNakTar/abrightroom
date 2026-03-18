using System.Collections;
using UnityEngine;

public class QuestProgressBar : MonoBehaviour
{
    [SerializeField] RectTransform fillRect;
    [SerializeField] RectTransform backgroundRect;

    Coroutine progressRoutine;
    EscapableWindow escapableWindow;

    void Awake()
    {
        escapableWindow = GetComponentInParent<EscapableWindow>();
    }

    public void StartAnimation(QuestInfo info)
    {
        fillRect.sizeDelta = new Vector2(0, backgroundRect.rect.height);
        progressRoutine ??= StartCoroutine(Progress(info));
    }

    IEnumerator Progress(QuestInfo info)
    {
        escapableWindow.Busy = true;
        float duration = info.duration;
        float progress = 0;
        while (progress < duration)
        {
            progress += Time.deltaTime;
            fillRect.sizeDelta = new Vector2(progress / duration * backgroundRect.rect.width, backgroundRect.rect.height);
            yield return null;
        }
        progressRoutine = null;
        EventManager<QuestInfo>.TriggerEvent(Event.QuestComplete, info);
        EventManager.TriggerEvent(Event.QuestComplete);
        escapableWindow.Busy = false;
    }
}
