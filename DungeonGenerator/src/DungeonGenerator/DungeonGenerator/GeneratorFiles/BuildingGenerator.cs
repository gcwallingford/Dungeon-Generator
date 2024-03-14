namespace DungeonGenerator;

public class BuildingGenerator
{
    public Dungeon building { get; }
    public BuildingGenerator()
    {
        building = CreateBaseDungeon(1);
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