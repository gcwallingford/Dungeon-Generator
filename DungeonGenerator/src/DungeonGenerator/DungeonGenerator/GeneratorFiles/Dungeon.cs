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
    
    public Floor GenerateFloorMaze(Floor inputFloor, int inputWidth, int inputHeight)
    {
        InitializeMaze(inputFloor, inputWidth, inputHeight);
        int X = Random.Shared.Next(inputFloor.Tiles.GetLength(0));
        int Y = Random.Shared.Next(inputFloor.Tiles.GetLength(1));

        return inputFloor;
    }

    public void MoveToTile(int inputHeight, int inputWidth)
    {
        int direction = Random.Shared.Next(4);
        switch (direction)
        {
            case 0:
                --inputHeight;
                break;
            case 1:
                ++inputHeight;
                break;
            case 2:
                --inputWidth;
                break;
            case 3:
                ++inputWidth;
                break;
        }

        return;
    }

    public bool DetectVisitedTile(Tile inputTile)
    {
        bool tileVisited = inputTile.Type == TileType.Floor;
        return tileVisited;
    }
    
    public void SetTileToFloor(Tile inputTile)
    {
        inputTile.Type = TileType.Floor;
    }

    public void InitializeMaze(Floor mazeFloor, int mazeWidth, int mazeHeight)
    {
        for (int i = 0; i < mazeWidth; i++)
        {
            for (int j = 0; j < mazeHeight; j++)
            {
                if (mazeFloor.Tiles[i, j].Type == TileType.Empty)
                {
                    mazeFloor.Tiles[i, j].Type = TileType.Wall;
                }
            }
        }
    }
}