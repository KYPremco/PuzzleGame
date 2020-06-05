using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace PuzzleGame
{
    #pragma warning disable 414, CS0067
    public class TileStruct : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseFloor floor { get; set; }

        [JsonIgnore]
        public CroppedBitmap floorTexture { get { return floor.GetTexure(); } }

        public BaseObject environmentObject { get; set; }

        [JsonIgnore]
        public CroppedBitmap environmentObjectTexture { get { return environmentObject.GetTexure(); } }

        public BaseObject gameObject { get; set; }

        [JsonIgnore]
        public CroppedBitmap gameObjectTexture { get { return gameObject.GetTexure(); } }

        public TileStruct(BaseFloor floor, BaseObject environmentObj, BaseObject gameObject)
        {
            this.floor = floor;
            this.environmentObject = environmentObj;
            this.gameObject = gameObject;
        }
    }
}