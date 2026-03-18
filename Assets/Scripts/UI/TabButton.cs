using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TabButton : MonoBehaviour
{
    [SerializeField] TabType tabType;
    TextMeshProUGUI text;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        text = GetComponent<TextMeshProUGUI>();
    }

    void OnClick()
    {
        TabManager.Instance.SetTab(tabType);
    }
}
