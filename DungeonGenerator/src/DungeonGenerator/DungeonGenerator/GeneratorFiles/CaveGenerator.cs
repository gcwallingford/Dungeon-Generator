namespace DungeonGenerator;

public class CaveGenerator
{
    public Dungeon Cave { get; }

    public CaveGenerator()
    {
        Cave = CreateBaseDungeon();
    }

    private Dungeon CreateBaseDungeon()
    {
        //creating dungeon object
        Dungeon cave = new Dungeon(1);
        cave.InitializeFloors();
        var currentFloor = cave.Floors[0];
        
        //finding max for both dimensions
        var rows = currentFloor.Tiles.GetLength(0);
        var columns = currentFloor.Tiles.GetLength(1);
        
        //sets start tile
        var currentTile = SetStartTile(rows, columns, currentFloor);
        int x = 10;
        int y = 10;
            
        //moves in random direction, sets tile to floor
        for (int i = 0; i < 100; i++)
        {
            SetTileToFloor(MoveDirection(currentTile, currentFloor, x, y));
        }
        return cave;
    }

    private Tile SetStartTile(int rows, int columns, Floor currentFloor)
    {
        //selecting random tile
        int randomRow = Random.Shared.Next(0, rows);
        int randomColumn = Random.Shared.Next(0, columns);
        
        //initial tile setup
        int x = randomColumn;
        int y = randomRow;
        Tile startTile = currentFloor.Tiles[y, x];
        startTile.Type = TileType.Start;
        return startTile;
    }

    private Tile SetTileToFloor(Tile currentTile)
    {
        //converting empty to floor tile
        if (currentTile.Type == TileType.Empty)
        {
            currentTile.Type = TileType.Floor;
        }
        return currentTile;
    }

    private Tile MoveDirection(Tile currentTile, Floor currentFloor, int x, int y)
    {
        //choosing direction from start tile
        int directionIndex = Random.Shared.Next(0, 3);
        
        //moving one tile in direction, records position of current tile
        switch (directionIndex)
        {
            case 0:
                currentTile = currentFloor.Tiles[y--, x];
                break;
            case 1:
                currentTile = currentFloor.Tiles[y++, x];
                break;
            case 2:
                currentTile = currentFloor.Tiles[y, x--];
                break;
            case 3:
                currentTile = currentFloor.Tiles[y, x++];
                break;
        }
        return currentTile;
    }
}