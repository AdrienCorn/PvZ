using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviourSingleton<GridManager>
{
    public int ROWS = 5;
    public int COLUMNS = 9;

    public float WIDTH = 880f;
    public float HEIGHT = 416f;

    public Vector2 LEFT_BOTTOM = new(0, 0);

    private Cell[,] cells;

    public GameObject cellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instance.InitGrid();
    }

    void FixedUpdate()
    {
        Instance.DebugGrid();

        Instance.ShowValid();
    }

    private void InitGrid()
    {
        cells = new Cell[ROWS, COLUMNS];

        for (int i = 0; i < ROWS; i++)
        {
            for(int j = 0; j < COLUMNS; j++)
            {
                Cell cell = Instantiate(cellPrefab, transform).GetComponent<Cell>();
                cell.SetPosition(new Vector2(LEFT_BOTTOM.x + WIDTH / COLUMNS * j, LEFT_BOTTOM.y + HEIGHT / ROWS * i));
                cells[i, j] = cell;
            }
        }
    }

    public void ShowValidCells()
    {
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                cells[i, j].ShowIfValid();
            }
        }
    }

    public void ShowRemovableCells()
    {
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                cells[i, j].ShowIfRemovable();
            }
        }
    }

    public bool TryDrop(Vector2 mousePos/*, ZodiacSign sign*/)
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

    public void ShowValid()
    {

    }

    private Cell FindCell(Vector2 mousePos)
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
