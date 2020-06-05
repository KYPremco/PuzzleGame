using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PuzzleGame
{
    public class DisplayClass
    {
        public string name { get; set; }
        public CroppedBitmap image { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }
}
