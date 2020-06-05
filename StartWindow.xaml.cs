using System.Windows;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            new LevelSelectorWindow().Show();
        }

        private void BtnEditLevel_Click(object sender, RoutedEventArgs e)
        {
            new LevelEditor().Show();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSpirtes_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
