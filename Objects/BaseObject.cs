using Newtonsoft.Json;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PuzzleGame
{
    public class BaseObject
    {
        private string spriteName { get; set; }
        protected TextureStruct texture { private get; set; }

        public string name { get; set; }
        public ObjectType type { get; set; }

        public BaseObject(string spriteName, TextureStruct texture, ObjectType type, string name)
        {
            this.spriteName = spriteName;
            this.texture = texture;
            this.name = name;
            this.type = type;
        }

        public CroppedBitmap GetTexure()
        {
            return new CroppedBitmap(new BitmapImage(new Uri(@"pack://application:,,,/Sprites/" + spriteName)), new Int32Rect(texture.x, texture.y, texture.height, texture.width));
        }
    }
}
