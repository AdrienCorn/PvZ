using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviourSingleton<GridManager>
{
    public int ROWS = 5;
    public int COLUMNS = 9;

    public float WIDTH = 17f;
    public float HEIGHT = 8f;

    public Vector2 LEFT_BOTTOM = new(-8.5f, - 5f);

    private Cell[,] cells;

    // Start is called before the first frame update
    void Start()
    {
        Instance.InitGrid();
    }

    void FixedUpdate()
    {
        Instance.DebugGrid();
    }

    private void InitGrid()
    {
        cells = new Cell[ROWS, COLUMNS];

        for (int i = 0; i < ROWS; i++)
        {
            for(int j = 0; j < COLUMNS; j++)
            {
                cells[i, j] = new Cell(CellType.NORMAL);
            }
        }
    }

    public bool TryDrop(Vector2 mousePos, ZodiacSign sign)
    {
        Cell cell = FindCell(mousePos);

        if (cell == null)
        {
            return false;
        }

        return cell.TrySetEntity(/*sign*/);
    }

    public bool TryRemove(Vector2 mousePos)
    {
        Cell cell = FindCell(mousePos);

        if (cell == null)
        {
            return false;
        }

        return cell.TryRemoveEntity();
    }

    public Cell FindCell(Vector2 mousePos)
    {
        Vector2 absolutePos = MouseToGrid(mousePos);

        // Check out of bounds
        if (absolutePos.x < 0 || absolutePos.x > WIDTH || absolutePos.y < 0 || absolutePos.y > HEIGHT)
        {
            return null;
        }

        int x = Mathf.FloorToInt(absolutePos.x / (WIDTH / COLUMNS));
        int y = Mathf.FloorToInt(absolutePos.y / (HEIGHT / ROWS));

        return cells[x, y];
    }

    private Vector2 MouseToGrid(Vector2 mousePos)
    {
        return mousePos - LEFT_BOTTOM;
    }

    private void DebugGrid()
    {
        float y;
        for (int i = 0; i < ROWS + 1; i++)
        {
            y = LEFT_BOTTOM.y + HEIGHT / ROWS * i;
            Debug.DrawLine(new Vector2(LEFT_BOTTOM.x, y), new Vector2(LEFT_BOTTOM.x + WIDTH, y), Color.red);
        }
        float x;
        for (int j = 0; j < COLUMNS + 1; j++)
        {
            x = LEFT_BOTTOM.x + WIDTH / COLUMNS * j;
            Debug.DrawLine(new Vector2(x, LEFT_BOTTOM.y), new Vector2(x, LEFT_BOTTOM.y + HEIGHT), Color.red);
        }
    }
}
