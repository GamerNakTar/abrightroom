using System;
using TMPro;
using UnityEngine;

public class TabManager : MonoSingleton<TabManager>
{
    [Serializable]
    public struct TabMapping
    {
        public TabType tabType;
        public GameObject gameObject;
        public TextMeshProUGUI tabText;
    }

    [SerializeField] TabMapping[] tabMappings;

    public void SetTab(int tab) => SetTab((TabType)tab);
    public void SetTab(TabType tabType)
    {
        foreach (TabMapping mapping in tabMappings)
        {
            bool active = mapping.tabType == tabType;
            if (active)
            {
                EnableUnderLine(mapping.tabText);
            }
            else
            {
                DisableUnderLine(mapping.tabText);
            }
            mapping.gameObject.SetActive(active);
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
