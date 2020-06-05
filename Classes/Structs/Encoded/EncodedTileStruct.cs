using System;

namespace PuzzleGame.Encoded
{
    public struct EncodedTileStruct
    {
        public string floor { get; set; }
        public string environmentObject { get; set; }
        public string gameObject { get; set; }

        public EncodedTileStruct(string floor, string environmentObject, string gameObject)
        {
            this.floor = floor;
            this.environmentObject = environmentObject;
            this.gameObject = gameObject;
        }
    }
}