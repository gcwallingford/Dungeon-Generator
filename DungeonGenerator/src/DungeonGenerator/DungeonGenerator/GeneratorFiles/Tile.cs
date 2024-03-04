namespace DungeonGenerator;

public class Tile(TileType tileType = TileType.Empty)
{
    public TileType Type
    {
        get => tileType;
        set => tileType = value;
    }
}