using System;

namespace PuzzleGame
{
    public static class Floors
    {
        public static readonly Type STONE_FLOOR = typeof(StoneFloor);
        public static readonly Type WOODEN_FLOOR = typeof(WoodFloor);
        public static readonly Type EMPTY_FLOOR = typeof(EmptyFloor);
    }
}
