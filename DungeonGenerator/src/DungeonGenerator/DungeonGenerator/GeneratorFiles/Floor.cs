namespace DungeonGenerator;

public class Floor(int height, int width)
{
    private int _height = height;
    private int _width = width;
    private Tile[,] _floorTiles = new Tile[height, width];

    internal void setEmptyTiles()
    {
        foreach (Tile tile in _floorTiles)
        {
            tile.Type = TileType.Empty;
        }
    }
}