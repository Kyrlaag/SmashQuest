using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Block nodePrefab;

    private RectTransform _rectTransform;

    [SerializeField] Sprite[] blockSprites;

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
                Block block = Instantiate(nodePrefab, this.transform);
                block.SetPosition(i * 200, j * -200);
                block.SetSprite(GetRandomSprites());
            }
        }
    }

    Sprite GetRandomSprites()
    {
        return blockSprites[Random.Range(0, blockSprites.Length)];
    }
}