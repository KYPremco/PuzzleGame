using PuzzleGame.Encoded;
using System;

namespace PuzzleGame.Converters
{
    public static class EncodeHelper
    {
        /// <summary>
        /// Turn GridStruct to EncodedGridStruct
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static EncodedGridStruct Encode(this GridStruct grid)
        {
            EncodedGridStruct encodedGrid = new EncodedGridStruct(grid.width, grid.height);

            for (int x = 0; x < grid.width; x++)
            {
                for (int y = 0; y < grid.height; y++)
                {
                    encodedGrid.grid[x, y] = new EncodedTileStruct(ObjectToString(grid.grid[x, y].floor), ObjectToString(grid.grid[x, y].environmentObject), ObjectToString(grid.grid[x, y].gameObject));
                }
            }

            return encodedGrid;
        }

        /// <summary>
        /// Turn EncodedGridStruct to GridStruct
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static GridStruct DecodeGrid(this EncodedGridStruct grid)
        {
            GridStruct DecodedGrid = new GridStruct(grid.width, grid.height);

            for (int x = 0; x < grid.width; x++)
            {
                for (int y = 0; y < grid.height; y++)
                {
                    DecodedGrid.grid[x, y] = TileBuilder.Create(Type.GetType(grid.grid[x, y].floor), Type.GetType(grid.grid[x, y].environmentObject), Type.GetType(grid.grid[x, y].gameObject));
                }
            }

            return DecodedGrid;
        }

        private static string ObjectToString(BaseObject obj)
        {
            return obj.GetType().ToString();
        }
    }
}
