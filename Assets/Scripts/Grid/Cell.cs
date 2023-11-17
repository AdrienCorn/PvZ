public class Cell
{
    private readonly CellType cellType;
    private ZodiacEntity entity;

    public Cell(CellType cellType)
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
