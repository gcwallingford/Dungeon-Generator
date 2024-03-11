namespace DungeonGenerator.Tests;

public class CaveTests
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
    public void TestUpLimit()
    {
        CaveGenerator generator = new CaveGenerator();
        var currentFloor = new Floor(20, 20);
        currentFloor.SetEmptyTiles();

        var (_, _, y) = generator.ChooseDirection(currentFloor, 0, 0, 0);
        Assert.Equal(0,y);
    }
    
    [Fact]
    public void TestDownLimit()
    {
        CaveGenerator generator = new CaveGenerator();
        var currentFloor = new Floor(20, 20);
        currentFloor.SetEmptyTiles();

        var (_, _, y) = generator.ChooseDirection(currentFloor, 0, 19, 1);
        Assert.Equal(19,y);
    }
    
    [Fact]
    public void TestLeftLimit()
    {
        CaveGenerator generator = new CaveGenerator();
        var currentFloor = new Floor(20, 20);
        currentFloor.SetEmptyTiles();

        var (_, x, _) = generator.ChooseDirection(currentFloor, 0, 0, 2);
        Assert.Equal(0,x);
    }
    
    [Fact]
    public void TestRightLimit()
    {
        CaveGenerator generator = new CaveGenerator();
        var currentFloor = new Floor(20, 20);
        currentFloor.SetEmptyTiles();

        var (_, x, _) = generator.ChooseDirection(currentFloor, 19, 0, 0);
        Assert.Equal(19,x);
    }
}