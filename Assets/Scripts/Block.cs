using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] RectTransform rectTransform;


    public void SetPosition(float x, float y)
    {
        rectTransform.anchoredPosition = new Vector2(x, y);
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public Sprite GetSprite()
    {
        return image.sprite;
    }

    public void Highlight(bool highlight)
    {
        image.color = highlight ? Color.yellow : Color.red;
    }
}
