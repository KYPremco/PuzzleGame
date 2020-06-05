using PuzzleGame.Converters;
using System;
using System.IO;
using System.Windows;

namespace PuzzleGame
{
    public class Game
    {
        private PlayerEntity player;
        public GridStruct originalGrid { get; private set; }

        public static GridStruct grid;

        private int plateCounter;

        public Game()
        {
            grid = GridConverter.DeserializeGrid(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"PuzzleGame\level.json")));
            LoadPlayer();
            CountPlates();
        }

        public Game(string name)
        {
            grid = GridConverter.DeserializeGrid(WebApi.GetLevelByName(name));
            LoadPlayer();
            CountPlates();
        }

        public Game(GridStruct EditorGrid)
        {
            grid = EditorGrid;
            LoadPlayer();
            CountPlates();
            originalGrid = EditorGrid.Copy();
        }

        private void LoadPlayer()
        {
            PlayerEntity player = grid.FindPlayer();
            if (player == null)
                MessageBox.Show("Can't find player");
            else
                this.player = player;
        }

        private void CountPlates()
        {
            foreach (TileStruct tile in grid.grid)
            {
                if (typeof(IEnvironmentPlate).IsAssignableFrom(tile.environmentObject.GetType()))
                {
                    plateCounter++;
                }
            }
        }

        public void MovePlayer(Move direction)
        {
            switch (direction)
            {
                case Move.DOWN:
                    if (player.Move(Move.DOWN))
                        grid.user.steps++;
                    break;
                case Move.UP:
                    if (player.Move(Move.UP))
                        grid.user.steps++;
                    break;
                case Move.LEFT:
                    if (player.Move(Move.LEFT))
                        grid.user.steps++;
                    break;
                case Move.RIGHT:
                    if (player.Move(Move.RIGHT))
                        grid.user.steps++;
                    break;
            }
        }

        public bool IsGameCompleted()
        {
            int x = 0;
            foreach(TileStruct tile in grid.grid)
            {
                if (typeof(IEnvironmentPlate).IsAssignableFrom(tile.environmentObject.GetType()))
                {
                    if (((BaseEnvironment)tile.environmentObject).IsPressed)
                    {
                        x++;
                        if(plateCounter == x)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }
    }
}