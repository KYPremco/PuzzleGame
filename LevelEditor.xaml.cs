using PuzzleGame.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for GameDebug.xaml
    /// </summary>
    public partial class LevelEditor : Window
    {
        private GridStruct grid = new GridStruct(12, 12);
        private StackPanel spRows = new StackPanel();

        private List<Type> objectList = new List<Type>();

        public LevelEditor()
        {
            InitializeComponent();

            for (int x = 0; x < grid.width; x++)
            {
                for (int y = 0; y < grid.height; y++)
                {
                    grid.SetTile(x, y, Floors.EMPTY_FLOOR, Blocks.EMPTY);
                }
            }
            UpdateGridTiles();
            LoadBlocks();
            InitBlocksGui();
        }

        private void InitBlocksGui()
        {
            foreach(Type type in objectList)
            {
                lvAllItems.Items.Add(createItem(type));
            }
        }

        private BuilderItemStruct createItem(Type item)
        {
            BaseObject obj = BaseObjectFacotry.Create(item);
            return new BuilderItemStruct(item, obj.name, obj.GetTexure());
        }

        private void LoadBlocks()
        {
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in a.GetTypes())
                {
                    if(type.IsSubclassOf(typeof(BaseObject)) && type != typeof(BaseFloor) && type != typeof(BaseEntity) && type != typeof(BaseBlock) && type != typeof(MoveableBaseBlock))
                    {
                        objectList.Add(type);
                    }
                }
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
                    btnTile.Height = 64;
                    btnTile.Width = 64;
                    btnTile.DataContext = tile;
                    btnTile.MouseDown += TileClicked;
                    btnTile.MouseEnter += TileClicked;

                    spCols.Children.Add(btnTile);
                }
                spRows.Children.Add(spCols);
                StackPanel spCols1 = (StackPanel)spRows.Children[0];
            }
            game.Children.Add(spRows);
        }

        private int GetTileSize()
        {
            int maxSize = (grid.width * 0.55) > grid.height ? (int)Math.Round(grid.width * 0.55) : grid.height;
            // kleiner dan 15 = 64x64
            if(maxSize <= 15)
            {
                
            }
            
            return 1;
        }

        private void TileClicked(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (lvAllItems.SelectedItem != null)
                {
                    BuilderItemStruct item = (BuilderItemStruct)lvAllItems.SelectedItem;
                    TileStruct tile = (TileStruct)((Label)sender).DataContext;

                    if (item.type.BaseType == typeof(BaseFloor))
                    {
                        tile.UpdateFloor(item.type);
                    }
                    else
                    {
                        tile.UpdateObject(item.type);
                    }
                }
                else
                {
                    MessageBox.Show("Kies een item");
                }
            }
            else if(Mouse.RightButton == MouseButtonState.Pressed)
            {
                TileStruct tile = (TileStruct)((Label)sender).DataContext;
                if(tile.gameObject.GetType() != Blocks.EMPTY)
                {
                    tile.UpdateObject(Blocks.EMPTY);
                }
                else if(tile.gameObject.GetType() != Floors.EMPTY_FLOOR)
                {
                    tile.UpdateFloor(Floors.EMPTY_FLOOR);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbSaveName.Text))
            {
                WebApi.AddNewLevel(tbSaveName.Text, GridConverter.Serialize(grid));

                //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), string.Format(@"PuzzleGame\{0}.json", tbSaveName.Text));
                //string root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"PuzzleGame\");

                //if (!Directory.Exists(root))
                //{
                //    Directory.CreateDirectory(root);
                //}

                //// Delete the file if it exists.
                //if (File.Exists(path))
                //{
                //    //File.Delete(path);
                //    MessageBox.Show("Naam is al bezet kies een ander.");
                //}
                //else
                //{
                //    //Create the file.
                //    File.WriteAllText(path, grid.Serialize());
                //}
            }
        }
    }
}
