namespace DungeonGenerator.Tests;

public class BuildingTests
{
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
    public void TestMakeRoom()
    {
        BuildingGenerator generator = new BuildingGenerator();
        var currentFloor = new Floor(20, 20);
        currentFloor.SetEmptyTiles();
        var wallTile = currentFloor.Tiles[0, 0];
        var floorTile = currentFloor.Tiles[1, 1];

        generator.MakeRoom(currentFloor.Tiles);
        
        Assert.Equal(TileType.Wall, wallTile.Type);
        Assert.Equal(TileType.Floor,  floorTile.Type);
    }
}