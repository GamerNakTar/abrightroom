using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskButton : MonoBehaviour
{
    [SerializeField] Image background;
    [SerializeField] int duration;

    Button button;
    Image outline;
    TextMeshProUGUI text;
    readonly Color defaultColor = new Color32(245, 245, 245, 255);

    protected void Awake()
    {
        button = GetComponent<Button>();
        outline = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        Disable();
        float travel = 0f;
        float originalWidth = background.rectTransform.rect.width;
        while (travel < duration)
        {
            travel += Time.deltaTime;
            background.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (1 - travel / duration) * originalWidth);
            yield return null;
        }
        background.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalWidth);
        Enable();
    }

    void Disable()
    {
        button.interactable = false;
        outline.color = Color.darkGray;
        text.color = Color.darkGray;
    }

    void Enable()
    {
        button.interactable = true;
        outline.color = defaultColor;
        text.color = defaultColor;
    }
}
