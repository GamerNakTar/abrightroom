using UnityEngine;
using UnityEngine.UI;

public class QuestImage : MonoBehaviour
{
    [SerializeField] Image image;

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
