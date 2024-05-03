<<<<<<< Updated upstream
namespace DungeonGenerator;
=======
namespace DungeonGenerator.GeneratorFiles;
>>>>>>> Stashed changes

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
            (cave.Floors[0], x, y) = ChooseDirection(currentFloor, x, y, RandomDirection());
        }
        return cave;
    }


    public (int x, int y) SetStartTile(int rows, int columns, Floor currentFloor)
    {
        //selecting random tile
        int x = Random.Shared.Next(0, rows);
        int y = Random.Shared.Next(0, columns);
        
        return (x, y);
    }

    private void SetTileToFloor(Floor currentFloor, int x, int y)
    {
        //converting empty to floor tile
        if (currentFloor.Tiles[y, x].Type != TileType.Floor)
        {
            currentFloor.Tiles[y, x].Type = TileType.Floor;
        }
    }

    private int RandomDirection()
    {
        int directionIndex = Random.Shared.Next(0, 4);
        return directionIndex;
    }

    public (Floor currentFloor, int x, int y) ChooseDirection(Floor currentFloor, int x, int y, int directionIndex)
    {
        switch (directionIndex)
        {
            case 0:
                if (y <= 1)
                {
                    y = 1;
                }
                SetTileToFloor(currentFloor, x, y--);
                
                break;
            case 1:
                if (y >= 18)
                {
                    y = 18;
                }
                SetTileToFloor(currentFloor, x, y++);
                
                break;
            case 2:
                if (x <= 1)
                {
                    x = 1;
                }
                SetTileToFloor(currentFloor, x--, y);
                
                break;
            case 3:
                if (x >= 18)
                {
                    x = 18;
                }
                SetTileToFloor(currentFloor, x++, y);
                
                break;
        }
        return (currentFloor, x, y);
    }
}