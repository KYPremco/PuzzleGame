using System;

namespace PuzzleGame
{
    public static class GridHelper
    {
        /// <summary>
        /// Return TileStruct from grid
        /// </summary>
        /// <param name="gridStruct"></param>
        /// <param name="x">Location X</param>
        /// <param name="y">Location Y</param>
        /// <returns></returns>
        public static TileStruct GetTile(this GridStruct gridStruct, int x, int y)
        {
            return gridStruct.grid[x, y];
        }

        /// <summary>
        /// Set a TileStruct in grid at given location
        /// </summary>
        /// <param name="gridStruct"></param>
        /// <param name="x">Location X</param>
        /// <param name="y">Location Y</param>
        /// <param name="floor">Floor type</param>
        /// <param name="obj">Object type</param>
        public static void SetTile(this GridStruct gridStruct, int x, int y, Type floor, Type environmentObj, Type obj)
        {
            gridStruct.grid[x, y] = TileBuilder.Create(floor, environmentObj, obj);
        }

        public static Pos MoveObject(this GridStruct grid, int x, int y, Move direction)
        {
            Pos newPos = GetNewLocation(x, y, direction);
            grid.GetTile(newPos.x, newPos.y).gameObject = grid.GetTile(x, y).gameObject;
            grid.GetTile(x, y).gameObject = BaseObjectFacotry.Create(Blocks.EMPTY);
            return newPos;
        }

        public static bool CanMove(this GridStruct grid, int x, int y, Move direction)
        {
            Pos newPos = GetNewLocation(x, y, direction);
            if (newPos.IsInGrid(grid) && grid.GetTile(newPos.x, newPos.y).gameObject.GetType() == Blocks.EMPTY)
                return true;
            return false;
        }

        public static bool CanMove(this GridStruct grid, Pos pos)
        {
            if (pos.IsInGrid(grid) && grid.GetTile(pos.x, pos.y).gameObject.GetType() == Blocks.EMPTY)
                return true;
            return false;
        }

        public static bool IsInGrid(this Pos pos, GridStruct grid)
        {
            if (pos.x >= 0 && pos.x <= grid.width - 1 && pos.y >= 0 && pos.y <= grid.height - 1)
                return true;
            return false;
        }

        public static Pos GetNewLocation(int x, int y, Move direction)
        {
            Pos pos = new Pos(x, y);
            switch(direction)
            {
                case Move.LEFT:
                    pos.x -= 1;
                    break;
                case Move.UP:
                    pos.y -= 1;
                    break;
                case Move.RIGHT:
                    pos.x += 1;
                    break;
                case Move.DOWN:
                    pos.y += 1;
                    break;
            }

            return pos;
        }

        public static PlayerEntity FindPlayer(this GridStruct grid)
        {
            for (int x = 0; x < grid.grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.grid.GetLength(1); y++)
                {
                    if (Entitys.PLAYER.Equals(grid.GetTile(x, y).gameObject.GetType()))
                    {
                        PlayerEntity player = (PlayerEntity)grid.GetTile(x, y).gameObject;
                        player.x = x;
                        player.y = y;
                        return player;
                    }
                }
            }
            return null;
        }

        public static Pos FindTilePosition(this GridStruct grid, TileStruct tile)
        {
            for (int x = 0; x < grid.grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.grid.GetLength(1); y++)
                {
                    if (grid.GetTile(x, y).Equals(tile))
                    {
                        Pos pos = new Pos(x, y);
                        return pos;
                    }
                }
            }
            return null;
        }

        public static GridStruct Copy(this GridStruct grid)
        {
            GridStruct newGrid = new GridStruct(grid.width, grid.height);
            for (int x = 0; x < grid.width; x++)
            {
                for (int y = 0; y < grid.height; y++)
                {
                    TileStruct tile = grid.GetTile(x, y);
                    newGrid.SetTile(x, y, tile.floor.GetType(), tile.environmentObject.GetType(), tile.gameObject.GetType());
                }
            }
            return newGrid;
        }
    }
}
