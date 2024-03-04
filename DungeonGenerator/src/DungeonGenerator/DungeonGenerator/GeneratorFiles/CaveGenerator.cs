namespace DungeonGenerator;

public class CaveGenerator
{
    CaveGenerator()
    {
        //creating dungeon object
        Dungeon cave = new Dungeon(1);
        cave.InitializeFloors();
        var currentFloor = cave.Floors[0];

        //finding max for both dimensions
        var rows = currentFloor.Tiles.GetLength(0);
        var columns = currentFloor.Tiles.GetLength(1);

        //selecting random tile
        int randomRow = Random.Shared.Next(0, rows);
        int randomColumn = Random.Shared.Next(0, columns);

        //initial tile setup
        int x = randomColumn;
        int y = randomRow;
        Tile startTile = currentFloor.Tiles[y, x];
        startTile.Type = TileType.Start;
        Tile currentTile = startTile;
        
        currentTile = startTile;
        
        //cave tile generation
        int directionIndex = Random.Shared.Next(0, 3);
        
        
        switch (directionIndex)
        {
            case 0:
                currentTile = currentFloor.Tiles[y++, x];
                break;
        }
        
        if (currentTile.Type == TileType.Empty)
        {
            currentTile.Type = TileType.Floor;
        }
    }
}