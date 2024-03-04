namespace DungeonGenerator;

public class CaveGenerator
{
    CaveGenerator()
    {
        Dungeon cave = new Dungeon(1);         
        cave.MakeFloors();
        var currentFloor = cave.Floors[0];

        var rows = currentFloor.Tiles.GetLength(0);
        var columns = currentFloor.Tiles.GetLength(1);
        Random random = new Random();

        int randomRow = random.Next(0, rows);
        int randomColumn = random.Next(0, columns);

        Tile startTile = currentFloor.Tiles[randomRow, randomColumn];
    }
}