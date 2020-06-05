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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            PageController.Route(Pages.LevelSelector);
        }

        private void BtnEditLevel_Click(object sender, RoutedEventArgs e)
        {
            PageController.Route(Pages.LevelEditor, new Pos(int.Parse(tbRangeX.Text), int.Parse(tbRangeY.Text)));
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSpirtes_Click(object sender, RoutedEventArgs e)
        {
            //new MainWindow().Show();
        }
    }
}
