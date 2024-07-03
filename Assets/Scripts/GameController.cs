using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int rows = 5;
    [SerializeField] int columns = 6;
    [SerializeField] Sprite[] blockSprites;

    public Block nodePrefab;
    private RectTransform _rectTransform;
    private Block[,] _blocks;
    private Block _selectedBlock;


    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        CreateNodes();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                Block clickedBlock = hit.collider.GetComponent<Block>();

                if (clickedBlock != null)
                {
                    if (_selectedBlock == null)
                    {
                        SelectBlock(clickedBlock);
                    }

                    else if (_selectedBlock == clickedBlock)
                    {
                        DeselectBlock();
                    }

                    else
                    {
                        DeselectBlock();
                        SelectBlock(clickedBlock);
                    }
                }
            }
        }
    }

    void CreateNodes()
    {
        _blocks = new Block[rows, columns];

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
                _blocks[i, j] = block;
            }
        }
    }

    void SelectBlock(Block block)
    {
        _selectedBlock = block;
        block.Highlight(true);
    }

    void DeselectBlock()
    {
        if (_selectedBlock != null)
        {
            _selectedBlock.Highlight(false);
            _selectedBlock = null;
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
            if (_blocks[row, col - 1]?.GetSprite() == sprite && _blocks[row, col - 2]?.GetSprite() == sprite)
            {
                return true;
            }
        }

        if (row >= 2)
        {
            if (_blocks[row - 1, col]?.GetSprite() == sprite && _blocks[row - 2, col]?.GetSprite() == sprite)
            {
                return true;
            }
        }

        return false;
    }
}