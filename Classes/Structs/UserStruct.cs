using System.ComponentModel;

namespace PuzzleGame
{
#pragma warning disable 414, CS0067
    public class UserStruct : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int score { get; set; }
        public int time { get; set; }
        public int steps { get; set; }

    }
}
