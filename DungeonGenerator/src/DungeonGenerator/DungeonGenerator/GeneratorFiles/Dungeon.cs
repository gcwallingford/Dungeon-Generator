namespace DungeonGenerator;

public class Dungeon(int numberOfFloors)
{
    private int _numberOfFloors = numberOfFloors;
    public int Floors = numberOfFloors;
    private Floor[] _floors = new Floor[numberOfFloors];

    private void MakeFloors()
    {
        for (int i = 0; i < numberOfFloors; i++)
        {
            Floor floor = new(20, 20);
            floor.setEmptyTiles();
            _floors[i] = floor;
        }
    }
}