namespace DungeonGenerator;

public class Floor(int height, int width)
{
    private int _height = height;
    private int _width = width;
    private Tile[,] _floorTiles = new Tile[height, width];
    public Tile[,] Tiles => _floorTiles;


   public void SetEmptyTiles()
   {
       int numberOfRows = Tiles.GetLength(0);
       int numberOfColumns = Tiles.GetLength(1);

       for (int row = 0; row < numberOfRows; row++)
       {
           for (int column = 0; column < numberOfColumns; column++)
           {
               _floorTiles[row, column] = new Tile();
               _floorTiles[row, column].Type = TileType.Empty;
           }
       }
   }
}