using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

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

    public Floor MakeRoomInFloor(Floor inputFloor, int roomHeight, int roomWidth, int startingFloorColumn,
        int startingFloorRow)
    {
        if (inputFloor.Tiles[startingFloorRow, startingFloorColumn].Type == TileType.Wall
            || inputFloor.Tiles[startingFloorRow, startingFloorColumn].Type == TileType.Floor
            || inputFloor.Tiles[startingFloorRow + roomHeight, startingFloorColumn + roomWidth].Type == TileType.Wall
            || inputFloor.Tiles[startingFloorRow + roomHeight, startingFloorColumn + roomWidth].Type == TileType.Floor)
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

    public Floor GenerateFloorMaze(Floor inputFloor)
    {
        int x = 10;
        int y = 10;

        InitializeMaze(inputFloor);
        MazeBuilderLoop(inputFloor, x, y);
        
        return inputFloor;
    }

    public Tuple<int, int> MoveToNextTile(int inputHeight, int inputWidth)
    {
        int direction = Random.Shared.Next(4);
        switch (direction)
        {
            case 0:
                if (inputHeight > 0)
                {
                    --inputHeight;
                }
                else
                {
                    inputHeight = 0;
                }

                break;
            case 1:
                if (inputHeight < 19)
                {
                    ++inputHeight;
                }
                else
                {
                    inputHeight = 19;
                }

                break;
            case 2:
                if (inputWidth > 0)
                {
                    --inputWidth;
                }
                else
                {
                    inputWidth = 0;
                }

                break;
            case 3:
                if (inputWidth < 19)
                {
                    ++inputWidth;
                }
                else
                {
                    inputWidth = 19;
                }

                break;
        }

        return new Tuple<int, int>(inputHeight, inputWidth);
    }

    public bool DetectVisitedTile(Tile inputTile)
    {
        bool tileVisited;
        if (inputTile.Type == TileType.Floor)
        {
            tileVisited = true;
        }
        else
        {
            tileVisited = false;
        }
        return tileVisited;
    }

    public void SetTileToFloor(Tile inputTile)
    {
        inputTile.Type = TileType.Floor;
    }

    public void InitializeMaze(Floor mazeFloor)
    {
        for (int i = 0; i < mazeFloor.Tiles.GetLength(0); i++)
        {
            for (int j = 0; j < mazeFloor.Tiles.GetLength(1); j++)
            {
                if (mazeFloor.Tiles[i, j].Type == TileType.Empty)
                {
                    mazeFloor.Tiles[i, j].Type = TileType.Wall;
                }
            }
        }
    }

    public void MazeBuilderLoop(Floor inputFloor, int x, int y)
    {
        inputFloor.Tiles[y, x].Type = TileType.Floor;
        for (int i = 0; i < 69; i++)
        {
            (int x, int y) tileCoords  = MazeBuilder(inputFloor, x, y);
            x = tileCoords.x;
            y = tileCoords.y;
        }
    }

    public (int x, int y) MazeBuilder(Floor inputFloor, int x, int y)
    {
        Tuple<int, int> nextTile = MoveToNextTile(y, x);
        y = nextTile.Item1;
        x = nextTile.Item2;
        var inputTile = inputFloor.Tiles[y, x];
        var inputTileType = inputTile.Type;//debug variable,serves no purpose outside of debug visuals
        bool tileVisited = DetectVisitedTile(inputTile);
            
        if (tileVisited == false)
        {
            SetTileToFloor(inputFloor.Tiles[y,x]);
        }
        else
        {
            (x, y) = MazeBuilder(inputFloor, x, y);
        }

        return (x, y);
    }
}
