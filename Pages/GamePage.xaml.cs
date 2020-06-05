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
using System.Windows.Threading;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for GameDebug.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private Game game;
        private bool inEditorMode;

        private DispatcherTimer timer;
        private StackPanel spRows = new StackPanel();
        private Window win;

        public GamePage(dynamic name, bool EditorMode)
        {
            InitializeComponent();
            inEditorMode = EditorMode;
            game = new Game(name);
            SetTimer();
            UpdateGridTiles();

            userGrid.DataContext = Game.grid.user;
            Game.grid.user.score++;
        }

        private void SetTimer()
        {
            timer = new DispatcherTimer(DispatcherPriority.Normal);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Game.grid.user.time++;
        }

        private void Game_Loaded(object sender, RoutedEventArgs e)
        {
            win = Window.GetWindow(this);
            win.KeyDown += KeyDownHandler;
        }

        public void KeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    game.MovePlayer(Move.DOWN);
                    break;
                case Key.Up:
                    game.MovePlayer(Move.UP);
                    break;
                case Key.Left:
                    game.MovePlayer(Move.LEFT);
                    break;
                case Key.Right:
                    game.MovePlayer(Move.RIGHT);
                    break;
            }

            if ((e.Key == Key.Down || e.Key == Key.Up || e.Key == Key.Left || e.Key == Key.Right) && game.IsGameCompleted())
            {
                GameCompleted();
            }
            else if (!inEditorMode &&  e.Key == Key.Escape)
            {
               //PageController.ChangePage(Pages.NewUser);
            }
        }

        private void GameCompleted()
        {
            if(!inEditorMode)
            {
                timer.Stop();
                Message.Warning("YOU FINISHED THE GAME WOOP WOOP");
                PageController.Route(Pages.LevelSelector);
            }
            else
            {
                timer.Stop();
                Message.Warning("You're level has been aproved");
                PageController.Route(Pages.LevelEditor, game.originalGrid, true);
            }

        }

        private void UpdateGridTiles()
        {
            gameGrid.Children.Clear();
            spRows.Orientation = Orientation.Horizontal;

            for (int x = 0; x < Game.grid.width; x++)
            {
                StackPanel spCols = new StackPanel();
                spCols.Orientation = Orientation.Vertical;

                for (int y = 0; y < Game.grid.height; y++)
                {
                    Label btnTile = new Label();
                    TileStruct tile = Game.grid.GetTile(x, y);

                    btnTile.Style = Application.Current.FindResource("Tile") as Style;

                    btnTile.DataContext = tile;

                    spCols.Children.Add(btnTile);
                }
                spRows.Children.Add(spCols);
            }
            gameGrid.Children.Add(spRows);
        }

        public void Close()
        {
            if (!inEditorMode && Message.SelectionMessage("Are you sure you want to quit the level?", "Leave!", "Cancel"))
            {
                PageController.Route(Pages.LevelSelector);
            }
            else if (inEditorMode && Message.SelectionMessage("Are you sure you want to go back to the editor?", "Go back", "Cancel"))
            {
                PageController.Route(Pages.LevelEditor, game.originalGrid);
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            win.KeyDown -= KeyDownHandler;
            timer.Tick -= Timer_Tick;
        }
    }
}