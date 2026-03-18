using UnityEngine;

public class QuestProgressWindow : MonoSingleton<QuestProgressWindow>
{
    [SerializeField] QuestImage questImage;
    [SerializeField] QuestProgressBar progressBar;

    public void Show(QuestInfo info)
    {
        questImage.SetImage(info.sprite);
        gameObject.SetActive(true);
        progressBar.StartAnimation(info);
    }
}
