using System;
using TMPro;
using UnityEngine;

public class TabManager : MonoSingleton<TabManager>
{
    [Serializable]
    public struct Tab
    {
        public TabType tabType;
        public GameObject gameObject;
        public TextMeshProUGUI titleText;
    }

    [SerializeField] Tab[] tabs;

    public void SetTab(int tab) => SetTab((TabType)tab);
    public void SetTab(TabType tabType)
    {
        foreach (Tab tab in tabs)
        {
            bool active = tab.tabType == tabType;
            if (active)
            {
                EnableUnderLine(tab.titleText);
            }
            else
            {
                DisableUnderLine(tab.titleText);
            }
            tab.gameObject.SetActive(active);
        }

        return;

        void EnableUnderLine(TextMeshProUGUI text) => text.fontStyle |= FontStyles.Underline;
        void DisableUnderLine(TextMeshProUGUI text) => text.fontStyle &= ~FontStyles.Underline;
    }

    void Start()
    {
        SetTab(TabType.Guild);
    }
}

[Serializable]
public enum TabType
{
    Guild,
    Player,
    Quest,
}
