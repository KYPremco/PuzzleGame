using PuzzleGame.Converters;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for GameDebug.xaml
    /// </summary>
    public partial class GameDebug : Window
    {
        private PlayerEntity player;
        public static GridStruct grid;

        private StackPanel spRows = new StackPanel();

        public GameDebug()
        {
            InitializeComponent();
            grid = GridConverter.DeserializeGrid(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"PuzzleGame\level.json")));
            LoadPlayer();
            UpdateGridTiles();
        }

        public GameDebug(GridStruct grid)
        {
            InitializeComponent();
            GameDebug.grid = grid;
            LoadPlayer();
            UpdateGridTiles();
        }

        private void LoadPlayer()
        {
            PlayerEntity player = grid.FindPlayer();
            if (player == null)
                MessageBox.Show("Can't find player");
            else
                this.player = player;
        }

        private void Game_Loaded(object sender, RoutedEventArgs e)
        {
            KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            KeyUp += new KeyEventHandler(MainWindow_KeyUp);
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    player.Move(Move.DOWN);
                    break;
                case Key.Up:
                    player.Move(Move.UP);
                    break;
                case Key.Left:
                    player.Move(Move.LEFT);
                    break;
                case Key.Right:
                    player.Move(Move.RIGHT);
                    break;
            }
        }

        private void UpdateGridTiles()
        {
            game.Children.Clear();
            spRows.Orientation = Orientation.Horizontal;

            for (int x = 0; x < grid.width; x++)
            {
                StackPanel spCols = new StackPanel();
                spCols.Orientation = Orientation.Vertical;

                for (int y = 0; y < grid.height; y++)
                {
                    Label btnTile = new Label();
                    TileStruct tile = grid.GetTile(x, y);

                    btnTile.Style = Application.Current.FindResource("Tile") as Style;

                    btnTile.DataContext = tile;

                    spCols.Children.Add(btnTile);
                }
                spRows.Children.Add(spCols);
                StackPanel spCols1 = (StackPanel)spRows.Children[0];
            }
            game.Children.Add(spRows);
        }
    }
}