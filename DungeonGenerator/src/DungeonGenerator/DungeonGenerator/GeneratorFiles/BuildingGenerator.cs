namespace DungeonGenerator.GeneratorFiles;

public class BuildingGenerator
{
    public Dungeon Building { get; }
    public BuildingGenerator(int numberOfRooms)
    {
        int randomHeight = Random.Shared.Next(1, 6);
        int randomWidth = Random.Shared.Next(1, 6);
        int randomColumn = Random.Shared.Next(1, 19);
        int randomRow = Random.Shared.Next(1, 19);
        
        Building = CreateBaseDungeon(2);

        for (int i = 0; i < numberOfRooms; i++)
        {
            Building.Floors[0] = Building.MakeRoomInFloor(Building.Floors[0], randomHeight, randomWidth, randomColumn, randomRow);
            Building.Floors[0] = Building.GenerateFloorMaze(Building.Floors[0]);
        }
        
    }
    
    Dungeon CreateBaseDungeon(int numberOfFloors)
    {
        Dungeon building = new Dungeon(numberOfFloors);
        building.InitializeFloors();

        return building;
    }
    
}