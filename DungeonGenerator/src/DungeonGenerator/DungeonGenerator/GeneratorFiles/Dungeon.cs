<<<<<<< Updated upstream
using System.Drawing;

namespace DungeonGenerator;
=======
namespace DungeonGenerator.GeneratorFiles;
>>>>>>> Stashed changes

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
        if (inputFloor.Tiles[startingFloorRow,startingFloorColumn].Type == TileType.Wall || inputFloor.Tiles[startingFloorRow,startingFloorColumn].Type == TileType.Floor)
        {
            int randomHeight = Random.Shared.Next(1, 6);
            int randomWidth = Random.Shared.Next(1, 6);
            int randomColumn = Random.Shared.Next(1, 19);
            int randomRow = Random.Shared.Next(1, 19);
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
<<<<<<< Updated upstream
}
=======

    public Tuple<int, int> MoveToNextTile(Floor inputFloor ,int inputHeight, int inputWidth, Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                if (inputHeight > 1)
                {
                    --inputHeight;
                    SetTileToFloor(inputFloor.Tiles[inputHeight, inputWidth]);
                    --inputHeight;
                }
                else
                {
                    inputHeight = 1;
                }

                break;
            case Direction.Down:
                if (inputHeight < 18)
                {
                    ++inputHeight;
                    SetTileToFloor(inputFloor.Tiles[inputHeight, inputWidth]);
                    ++inputHeight;
                }
                else
                {
                    inputHeight = 18;
                }

                break;
            case Direction.Left:
                if (inputWidth > 1)
                {
                    --inputWidth;
                    SetTileToFloor(inputFloor.Tiles[inputHeight, inputWidth]);
                    --inputWidth;
                }
                else
                {
                    inputWidth = 1;
                }

                break;
            case Direction.Right:
                if (inputWidth < 18)
                {
                    ++inputWidth;
                    SetTileToFloor(inputFloor.Tiles[inputHeight, inputWidth]);
                    ++inputWidth;
                }
                else
                {
                    inputWidth = 18;
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
        for (int i = 0; i < 20; i++)
        {
            (int x, int y) tileCoords  = MazeBuilder(inputFloor, x, y);
            x = tileCoords.x;
            y = tileCoords.y;
        }
    }

    public (int x, int y) MazeBuilder(Floor inputFloor, int x, int y)
    {
        int intDirection = Random.Shared.Next(4);
        (y,x) = MoveToNextTile(inputFloor,y, x, IntToDirections(intDirection));
        var inputTile = inputFloor.Tiles[y, x];
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

    public Direction IntToDirections(int intDirection)
    {
        Direction direction = Direction.Up;
        switch (intDirection)
        {
            case 0:
                direction = Direction.Up;
                break;
            case 1:
                direction = Direction.Down;
                break;
            case 2:
                direction = Direction.Left;
                break;
            case 3:
                direction = Direction.Right;
                break;
        }

        return direction;
    }
}
>>>>>>> Stashed changes
