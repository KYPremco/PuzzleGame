using PuzzleGame.Converters;
using System.Windows;
using System.Windows.Controls;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for LevelSelectorWindow.xaml
    /// </summary>
    public partial class LevelSelectorWindow : Window
    {
        public LevelSelectorWindow()
        {
            InitializeComponent();
            LoadLevels();
        }

        private void LoadLevels()
        {
            foreach (string level in Converter.DeserializeLevelList(WebApi.GetAllLevels()))
            {
                Button btn = new Button();
                btn.Style = (Style)Application.Current.Resources["blueWideButton"];
                btn.Width = 300;
                btn.FontSize = 25;
                btn.Margin = new Thickness(0,0,0,10);
                btn.Click += startLevel;
                btn.Content = level;
                spLevels.Children.Add(btn);
            }
        }

        private void startLevel(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            new GameDebug(GridConverter.DeserializeGrid(WebApi.GetLevelByName(btn.Content.ToString()))).Show();
        }
    }
}
