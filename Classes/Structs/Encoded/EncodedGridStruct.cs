namespace PuzzleGame.Encoded
{
    public struct EncodedGridStruct
    {
        public int height { get; set; }
        public int width { get; set; }

        public EncodedTileStruct[,] grid { get; set; }

        public EncodedGridStruct(int width, int height)
        {
            this.height = height;
            this.width = width;

            grid = new EncodedTileStruct[width, height];
        }
    }
}