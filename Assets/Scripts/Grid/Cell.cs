using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private static Color VALID_COLOR = new Color32(0, 255, 0, 50);
    private static Color REMOVABLE_COLOR = new Color32(255, 0, 0, 50);

    private CellType cellType;
    //private ZodiacEntity entity;

    public RectTransform m_RectTransform;
    public Image m_Image;

    public void ResetColor()
    {
        m_Image.enabled = false;
    }

    public void ShowIfValid()
    {
        if (IsValid())
        {
            m_Image.color = VALID_COLOR;
            m_Image.enabled = true;
        }
        else ResetColor();
    }

    public void ShowIfRemovable()
    {
        if(IsRemovable()) {
            m_Image.color = REMOVABLE_COLOR;
            m_Image.enabled = true;
        }
        else ResetColor();
    }

    public void SetPosition(Vector2 position)
    {
        m_RectTransform.anchoredPosition = position;
    }

    public void SetCellType(CellType cellType)
    {
        this.cellType = cellType;
    }

    public bool TrySetEntity(/*ZodiacSign sign*/)
    {
        if(IsValid())
        {
            // TODO: Create new ZodiacEntity
            return true;
        }
        return false;
    }

    public bool TryRemoveEntity()
    {
        if(IsRemovable())
        {
            this.entity = null;
            return true;
        }
        return false;
    }

    public bool IsRemovable()
    {
        return IsEditable() && IsOccupied();
    }

    public bool IsValid()
    {
        return IsEditable() && !IsOccupied();
    }

    private bool IsOccupied()
    {
        return this.entity != null;
    }

    private bool IsEditable()
    {
        return CellType.NORMAL.Equals(this.cellType);
    }
}
