namespace DungeonGenerator.GeneratorFiles;

public class Dungeon(int numberOfFloors)
{
    private Floor[] _floors = new Floor[numberOfFloors];
    public Floor[] Floors => _floors;

    public void InitializeFloors()
    {
        for (int i = 0; i < numberOfFloors; i++)
        {
            Floor floor = new(20, 20);
            floor.SetEmptyTiles();
            _floors[i] = floor;
        }
    }
    
    public void InitializeRoom(Tile[,] inputArray)
    {
        var numRows = inputArray.GetLength(0);
        var numColumns = inputArray.GetLength(1);
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numColumns; j++)
            {
                if (i == 0 || i == numRows - 1)
                {
                    inputArray[i, j].Type = TileType.Wall;
                }
                else if (j == 0 || j == numColumns - 1)
                {
                    inputArray[i, j].Type = TileType.Wall;
                }
                else
                {
                    inputArray[i, j].Type = TileType.Floor;
                }
            }
        }
    }

    public Floor MakeRoomInFloor(Floor inputFloor, int roomHeight, int roomWidth, int startingFloorColumn, int startingFloorRow)
    {
        if (inputFloor.Tiles[startingFloorRow,startingFloorColumn].Type == TileType.Wall
            || inputFloor.Tiles[startingFloorRow,startingFloorColumn].Type == TileType.Floor
            || inputFloor.Tiles[startingFloorRow + roomHeight,startingFloorColumn + roomWidth].Type == TileType.Wall 
            || inputFloor.Tiles[startingFloorRow + roomHeight,startingFloorColumn + roomWidth].Type == TileType.Floor)
        {
            int randomHeight = Random.Shared.Next(1, 6);
            int randomWidth = Random.Shared.Next(1, 6);
            int randomColumn = Random.Shared.Next(1, 19 - randomHeight);
            int randomRow = Random.Shared.Next(1, 19 - randomWidth);
            
            MakeRoomInFloor(inputFloor, randomHeight, randomWidth, randomColumn, randomRow);
        }
        else
        {
            for (int column = startingFloorColumn; column < (startingFloorColumn + roomWidth); column++)
            {
            
                for (int row = startingFloorRow; row < (startingFloorRow + roomHeight); row++)
                {
                    if (column == startingFloorColumn || column == startingFloorColumn + roomWidth - 1)
                    {
                        inputFloor.Tiles[row, column].Type = TileType.Wall;
                    }
                    else
                    {
                        if (row == startingFloorRow || row == startingFloorRow + roomHeight - 1)
                        {
                            inputFloor.Tiles[row, column].Type = TileType.Wall;
                        }
                        else
                        {
                            inputFloor.Tiles[row, column].Type = TileType.Floor;
                        }
                    }
                }
            }
        }
        return inputFloor;
    }
    
    public Floor GenerateFloorHallway(Floor inputFloor, int inputWidth, int inputHeight)
    {
        int directionInput = Random.Shared.Next(0,4);
        if (inputFloor.Tiles[inputWidth,inputHeight].Type == TileType.Empty)
        {
            inputFloor.Tiles[inputWidth, inputHeight].Type = TileType.Floor;
            switch (directionInput)
            {
                //up
                case 0:
                    inputHeight--;
                    GenerateFloorHallway(inputFloor, inputWidth, inputHeight);
                    break;
                //down
                case 1:
                    inputHeight++;
                    GenerateFloorHallway(inputFloor, inputWidth, inputHeight);
                    break;
                //left
                case 2:
                    inputWidth--;
                    GenerateFloorHallway(inputFloor, inputWidth, inputHeight);
                    break;
                //right
                case 3:
                    inputWidth++;
                    GenerateFloorHallway(inputFloor, inputWidth, inputHeight);
                    break;
            }
        }
        
        return inputFloor;
    }
}