using System;
using System.Windows.Media.Imaging;

namespace PuzzleGame
{
    public struct BuilderItemStruct
    {
        public Type type { get; }
        public string name { get; }
        public CroppedBitmap image { get; }

        public BuilderItemStruct(Type type, string name, CroppedBitmap image)
        {
            this.type = type;
            this.name = name;
            this.image = image;
        }
    }
}