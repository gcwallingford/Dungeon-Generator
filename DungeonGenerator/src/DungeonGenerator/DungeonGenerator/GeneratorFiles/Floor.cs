namespace DungeonGenerator;

public class Floor(int height, int width)
{
    private int _height = height;
    private int _width = width;
    private Tile[,] _floorTiles = new Tile[height, width];
    public Tile[,] Tiles => _floorTiles;


   public void SetEmptyTiles()
   {
       int rows = Tiles.GetLength(0);
       int columns = Tiles.GetLength(1);

       for (int i = 0; i < rows; i++)
       {
           for (int j = 0; j < columns; j++)
           {
               Tile.Type = TileType.Empty;
           }
       }
   }
}