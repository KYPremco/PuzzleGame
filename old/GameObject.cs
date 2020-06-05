using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    class GameObject
    {
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int height { get; set; }
        public int width { get; set; }

        public GameObject() { }

        public GameObject(string name, int x, int y, int height, int width)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }
    }
}
