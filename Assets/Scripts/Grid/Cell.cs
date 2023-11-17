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

    public bool IsValid()
    {
        return CellType.NORMAL.Equals(this.cellType) && this.entity == null;
    }
}
