using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] Sprite[] blockSprites;

    public Block nodePrefab;
    private RectTransform _rectTransform;
    private Block[,] blocks;


    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        CreateNodes();
    }

    void CreateNodes()
    {
        int rows = 5;
        int columns = 6;
        blocks = new Block[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Block block = Instantiate(nodePrefab, this.transform);
                block.SetPosition(i * 200, j * -200);

                Sprite randomSprite;
                do
                {
                    randomSprite = GetRandomSprites();
                } while (IsMatch(i, j, randomSprite));

                block.SetSprite(randomSprite);
                blocks[i, j] = block;
            }
        }
    }

    Sprite GetRandomSprites()
    {
        return blockSprites[Random.Range(0, blockSprites.Length)];
    }

    bool IsMatch(int row, int col, Sprite sprite)
    {
        if (col >= 2)
        {
            if (blocks[row, col - 1]?.GetSprite() == sprite && blocks[row, col - 2]?.GetSprite() == sprite)
            {
                return true;
            }
        }

        if (row >= 2)
        {
            if (blocks[row - 1, col]?.GetSprite() == sprite && blocks[row - 2, col]?.GetSprite() == sprite)
            {
                return true;
            }
        }

        return false;
    }
}