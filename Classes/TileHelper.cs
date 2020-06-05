using System;

namespace PuzzleGame
{
    public static class TileHelper
    {
        public static bool Contains(this TileStruct tile, Type item)
        {
            return item.Equals(tile.floor) || item.Equals(tile.gameObject) || item.Equals(tile.environmentObject);
        }

        public static void Update(this TileStruct tile, Type floor, Type obj)
        {
            tile.UpdateFloor(floor);
            tile.UpdateObject(obj);
        }

        public static void Update(this TileStruct tile, Type item)
        {
            if (item.BaseType == typeof(BaseEnvironment))
            {
                tile.UpdateEnvironment(item);
            }
            else if (item.BaseType == typeof(BaseFloor))
            {
                tile.UpdateFloor(item);
            }
            else
            {
                tile.UpdateObject(item);
            }
        }

        private static void UpdateFloor(this TileStruct tile, Type floor)
        {
            tile.floor = BaseObjectFacotry.Create(floor);
        }

        private static void UpdateObject(this TileStruct tile, Type obj)
        {
            tile.gameObject = BaseObjectFacotry.Create(obj);
        }

        public static void UpdateEnvironment(this TileStruct tile, Type EnvironmentObj)
        {
            tile.environmentObject = BaseObjectFacotry.Create(EnvironmentObj);
        }
    }
}
