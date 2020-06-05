using PuzzleGame.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for LevelSelectorPage.xaml
    /// </summary>
    public partial class LevelSelectorPage : Page
    {
        public LevelSelectorPage()
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
                btn.Margin = new Thickness(0, 0, 0, 10);
                btn.Click += startLevel;
                btn.Content = level;
                spLevels.Children.Add(btn);
            }
        }

        private void startLevel(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            PageController.Route(Pages.Game, btn.Content.ToString());
        }
    }
}
