using UnityEngine;

public class EscapableWindow : MonoBehaviour
{
    public bool Busy { get; set; }

    void OnEnable()
    {
        WindowManager.Instance.Push(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        WindowManager.Instance.Push(this);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
