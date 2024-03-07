namespace DungeonGenerator.Tests;

public class UnitTest1
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
    public void TestLeftLimit()
    {
        Dungeon dungeon = new Dungeon(1);
        dungeon.InitializeFloors();
        
    }
}