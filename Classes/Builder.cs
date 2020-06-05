using System;

namespace PuzzleGame
{
    public static class TileBuilder
    {
        public static TileStruct Create(Type floor, Type enivornmentObj, Type obj)
        {
            return new TileStruct(
                BaseObjectFacotry.Create(floor),
                BaseObjectFacotry.Create(enivornmentObj),
                BaseObjectFacotry.Create(obj)
                );
        }
    }
}
