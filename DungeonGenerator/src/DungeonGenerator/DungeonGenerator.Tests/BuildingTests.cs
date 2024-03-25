using DungeonGenerator.GeneratorFiles;
using Xunit.Abstractions;

namespace DungeonGenerator.Tests;

public class BuildingTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public BuildingTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void TestEmptyFloor()
    {
        Dungeon dungeon = new Dungeon(1);         
        dungeon.InitializeFloors();
        var currentFloor = dungeon.Floors[0];  

        var tile = currentFloor.Tiles[0, 0];      
        Assert.Equal(TileType.Empty, tile.Type);      
    }

    [Fact]
    public void TestInitializeRoom()
    {
        BuildingGenerator generator = new BuildingGenerator(1);
        var currentFloor = new Floor(20, 20);
        currentFloor.SetEmptyTiles();
        var wallTile = currentFloor.Tiles[0, 0];
        var floorTile = currentFloor.Tiles[1, 1];

        generator.building.InitializeRoom(currentFloor.Tiles);
        
        Assert.Equal(TileType.Wall, wallTile.Type);
        Assert.Equal(TileType.Floor,  floorTile.Type);
    }

    [Fact]
    public void TestMakeRoom()
    {
        BuildingGenerator generator = new BuildingGenerator(1);
        var currentFloor = new Floor(20, 20);
        currentFloor.SetEmptyTiles();
        var wallTile1 = currentFloor.Tiles[2, 2];
        var wallTile2 = currentFloor.Tiles[4, 4];
        var floorTile = currentFloor.Tiles[3, 3];

        generator.building.MakeRoomInFloor(currentFloor, 3, 3, 2, 2);

        _testOutputHelper.WriteLine(currentFloor.Tiles[2, 2].Type + ", " + currentFloor.Tiles[2, 3].Type + ", " + currentFloor.Tiles[2, 4].Type);
        _testOutputHelper.WriteLine(currentFloor.Tiles[3, 2].Type + ", " + currentFloor.Tiles[3, 3].Type + ", " + currentFloor.Tiles[3, 4].Type);
        _testOutputHelper.WriteLine(currentFloor.Tiles[4, 2].Type + ", " + currentFloor.Tiles[4, 3].Type + ", " + currentFloor.Tiles[4, 4].Type);
        
        Assert.Equal(TileType.Wall, wallTile1.Type);
        Assert.Equal(TileType.Wall, wallTile2.Type);
        Assert.Equal(TileType.Floor, floorTile.Type);
    }

    [Fact]
    public void TestHallwayGenerator()
    {
        BuildingGenerator buildingGenerator = new(1);
        Floor currentFloor = new Floor(20, 20);
        currentFloor.SetEmptyTiles();
        var wallTile = currentFloor.Tiles[1, 0];
        var floorTile = currentFloor.Tiles[1, 1];
        var wallTile2 = currentFloor.Tiles[1, 2];
        var wallTile3 = currentFloor.Tiles[0, 1];
        var floorTile2 = currentFloor.Tiles[2, 1];

        buildingGenerator.building.GenerateFloorHallway(currentFloor, 1, 1);
        
        Assert.Equal(wallTile.Type,TileType.Wall);
        Assert.Equal(floorTile.Type, TileType.Floor);
        Assert.Equal(wallTile2.Type, TileType.Wall);
        Assert.Equal(wallTile3.Type, TileType.Wall);
        Assert.Equal(floorTile2.Type, TileType.Floor);
    }
}