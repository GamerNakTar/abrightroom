using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoSingleton<DialogManager>
{
    static readonly Queue<TextMeshProUGUI> dialogQueue = new();
    const int DialogSize = 20;

    [SerializeField] TextMeshProUGUI dialogPrefab;
    [SerializeField] Transform dialogContainer;
    static TextMeshProUGUI[] dialogPool = new TextMeshProUGUI[DialogSize];

    const int AlphaStep = 10;

    void Start()
    {
        CreatePool();
    }

    public void EnqueueDialog(string text)
    {
        TextMeshProUGUI dialog = dialogQueue.Dequeue();

        dialog.text = text;
        dialog.transform.SetAsFirstSibling();

        dialogQueue.Enqueue(dialog);

        DrawDialog();
    }

    void DrawDialog()
    {
        int alpha = 255;

        for (int i = 0; i < dialogContainer.childCount; i++)
        {
            TextMeshProUGUI dialog = dialogContainer.GetChild(i).GetComponent<TextMeshProUGUI>();
            if (dialog == null) continue;

            dialog.alpha = alpha / 255f;
            alpha -= AlphaStep;
        }
    }

    void CreatePool()
    {
        for (int i = 0; i < DialogSize; i++)
        {
            TextMeshProUGUI dialog = Instantiate(dialogPrefab, dialogContainer);
            dialog.text = " ";
            dialogQueue.Enqueue(dialog);
        }
    }
}
