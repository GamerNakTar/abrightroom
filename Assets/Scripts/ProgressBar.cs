using System.Collections;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] RectTransform FillRect;
    [SerializeField] RectTransform BackgroundRect;

    Coroutine progressRoutine;

    public void StartAnimation(float duration)
    {
        FillRect.sizeDelta = new Vector2(0, BackgroundRect.rect.height);
        progressRoutine ??= StartCoroutine(Progress(duration));
    }

    IEnumerator Progress(float duration)
    {
        float progress = 0;
        while (progress < duration)
        {
            progress += Time.deltaTime;
            FillRect.sizeDelta = new Vector2(progress / duration * BackgroundRect.rect.width, BackgroundRect.rect.height);
            yield return null;
        }
        progressRoutine = null;
    }
}
