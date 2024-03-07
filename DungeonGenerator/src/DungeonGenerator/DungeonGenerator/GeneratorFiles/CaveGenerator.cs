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
        (int x, int y) = SetStartTile(rows, columns, currentFloor);
        
            
        //moves in random direction, sets tile to floor
        for (int i = 0; i < 100; i++)
        {
            (cave.Floors[0], x, y) = ChooseDirection(currentFloor, x, y);
        }
        return cave;
    }


    private (int x, int y) SetStartTile(int rows, int columns, Floor currentFloor)
    {
        //selecting random tile
        int x = Random.Shared.Next(0, rows);
        int y = Random.Shared.Next(0, columns);
        
        return (x, y);
    }

    private Floor SetTileToFloor(Floor currentFloor, int x, int y)
    {
        //converting empty to floor tile
        if (currentFloor.Tiles[y, x].Type != TileType.Floor)
        {
            currentFloor.Tiles[y, x].Type = TileType.Floor;
        }
        return currentFloor;
    }

    private (Floor currentFloor, int x, int y) ChooseDirection(Floor currentFloor, int x, int y)
    {
        //choosing direction from start tile
        int directionIndex = Random.Shared.Next(0, 4);
        Console.WriteLine(directionIndex);
        //moving one tile in direction, sets tile to floor
        switch (directionIndex)
        {
            case 0:
                SetTileToFloor(currentFloor, x, y--);
                if (y < 0)
                {
                    y = 0;
                }
                break;
            case 1:
                SetTileToFloor(currentFloor, x, y++);
                if (y > 20)
                {
                    y = 20;
                }
                break;
            case 2:
                SetTileToFloor(currentFloor, x--, y);
                if (x < 0)
                {
                    x = 0;
                }
                break;
            case 3:
                SetTileToFloor(currentFloor, x++, y);
                if (x > 20)
                {
                    x = 20;
                }
                break;
        }
        
        

        
        return (currentFloor, x, y);
    }
}