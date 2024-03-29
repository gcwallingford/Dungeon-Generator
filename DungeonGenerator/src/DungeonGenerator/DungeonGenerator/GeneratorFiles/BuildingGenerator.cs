namespace DungeonGenerator;

public class BuildingGenerator
{
    public Dungeon building { get; }
    public BuildingGenerator(int numberOfRooms)
    {
        int randomHeight = Random.Shared.Next(1, 6);
        int randomWidth = Random.Shared.Next(1, 6);
        int randomColumn = Random.Shared.Next(1, 19);
        int randomRow = Random.Shared.Next(1, 19);
        
        building = CreateBaseDungeon(1);

        for (int i = 0; i < numberOfRooms; i++)
        {
            building.MakeRoomInFloor(building.Floors[0], randomHeight, randomWidth, randomColumn, randomRow);
        }
        
    }
    
    Dungeon CreateBaseDungeon(int numberOfFloors)
    {
        Dungeon building = new Dungeon(numberOfFloors);
        building.InitializeFloors();
        var currentFloor = building.Floors[0];

        var rows = currentFloor.Tiles.GetLength(0);
        var columns = currentFloor.Tiles.GetLength(1);

        return building;
    }
    
}