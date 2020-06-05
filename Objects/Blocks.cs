using System;

namespace PuzzleGame
{
    public static class Blocks
    {
        public static readonly Type EMPTY = typeof(EmptyObject);

        public static readonly Type WOOD_BOX = typeof(WoodBox);
        public static readonly Type STEEL_BOX = typeof(SteelBox);
        public static readonly Type COBALT_BOX = typeof(CobaltBox);
        public static readonly Type EMERALD_BOX = typeof(EmeraldBox);

        public static readonly Type WOOD_WALL = typeof(WoodWall);
        public static readonly Type STONE_WALL = typeof(StoneWall);
        public static readonly Type STEEL_WALL = typeof(SteelWall);
    }
}