using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject nodePrefab;

    private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        CreateNodes();
    }

    void CreateNodes()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Instantiate(nodePrefab, this.transform)
                    .GetComponent<RectTransform>().anchoredPosition = new Vector2(i * 200, j * -200);
            }
        }
    }
}