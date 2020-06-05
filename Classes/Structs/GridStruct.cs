namespace PuzzleGame
{
    public struct GridStruct
    {
        public UserStruct user { get; set; }

        public int height { get; set; }
        public int width { get; set; }

        public TileStruct[,] grid { get; set; }

        public GridStruct(int width, int height)
        {
            this.height = height;
            this.width = width;
            
            user = new UserStruct() { score = 0, steps = 0, time = 0 };
            grid = new TileStruct[width, height];
        }
    }
}