namespace DungeonGenerator;

public class Tile
{
    private static TileType _type;
    public static TileType Type
    {
        get => _type;
        set => _type = value;
    }
}