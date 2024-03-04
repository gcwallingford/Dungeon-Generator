namespace DungeonGenerator.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Dungeon dungeon = new Dungeon(1);         
        dungeon.MakeFloors();
        var currentFloor = dungeon.Floors[0];  

        var tile = currentFloor.Tiles[0, 0];      
        Assert.Equal(TileType.Empty, Tile.Type);                                    
    }
}