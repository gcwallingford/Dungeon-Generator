<<<<<<< Updated upstream
namespace DungeonGenerator;
=======
namespace DungeonGenerator.GeneratorFiles;
>>>>>>> Stashed changes

public class BuildingGenerator
{
    public Dungeon Building { get; }
    public BuildingGenerator(int numberOfRooms)
    {
        int randomHeight = Random.Shared.Next(1, 6);
        int randomWidth = Random.Shared.Next(1, 6);
        int randomColumn = Random.Shared.Next(1, 19);
        int randomRow = Random.Shared.Next(1, 19);
        
<<<<<<< Updated upstream
        building = CreateBaseDungeon(1);

        for (int i = 0; i < numberOfRooms; i++)
        {
            building.MakeRoomInFloor(building.Floors[0], randomHeight, randomWidth, randomColumn, randomRow);
=======
        Building = CreateBaseDungeon(2);

        for (int i = 0; i < numberOfRooms; i++)
        {
            Building.Floors[0] = Building.MakeRoomInFloor(Building.Floors[0], randomHeight, randomWidth, randomColumn, randomRow);
            Building.Floors[0] = Building.GenerateFloorMaze(Building.Floors[0]);
>>>>>>> Stashed changes
        }
        
    }
    
    Dungeon CreateBaseDungeon(int numberOfFloors)
    {
        Dungeon building = new Dungeon(numberOfFloors);
        building.InitializeFloors();

        return building;
    }
    
}