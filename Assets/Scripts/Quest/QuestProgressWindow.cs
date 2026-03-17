using UnityEngine;

public class QuestProgressWindow : MonoSingleton<QuestProgressWindow>
{
    [SerializeField] QuestProgressBar progressBar;

    public void Show(QuestInfo info)
    {
        gameObject.SetActive(true);
        progressBar.StartAnimation(info);
    }
}
