public class Cell
{
    private readonly CellType cellType;
    private ZodiacEntity entity;

    public Cell(CellType cellType)
    {
        this.cellType = cellType;
    }

    void setEntity(ZodiacEntity entity)
    {
        this.entity = entity;
    }

    bool isValid()
    {
        return CellType.NORMAL.Equals(this.cellType) && this.entity == null;
    }
}
