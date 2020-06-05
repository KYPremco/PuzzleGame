using PuzzleGame.Converters;
using PuzzleGame.Editor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for LevelEditorPage.xaml
    /// </summary>
    public partial class LevelEditorPage : Page
    {
        private LevelEditor levelEditor;
        private StackPanel spRows = new StackPanel();
        private bool HandleSelection = true;

        private ListView ActiveListView;

        private Pos firstPlacePosition;

        public LevelEditorPage(dynamic levelOption, bool saveMode)
        {
            InitializeComponent();

            levelEditor = new LevelEditor(levelOption);
            UpdateGridTiles();
            InitBlocksGui();
            if (saveMode)
                SaveLevel();

            KeyUp += LevelEditorPage_KeyUp;
        }

        private void LevelEditorPage_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Keyboard.IsKeyDown(Key.RightShift) || !Keyboard.IsKeyDown(Key.RightAlt))
                firstPlacePosition = null;
        }

        private void InitBlocksGui()
        {
            foreach (Type type in levelEditor.objectList)
            {
                if (type.IsSubclassOf(typeof(BaseBlock)) || type.Equals(typeof(EmptyObject)))
                {
                    lvBlocks.Items.Add(createItem(type));
                }
                else if (type.IsSubclassOf(typeof(BaseEntity)))
                {
                    lvEntitiys.Items.Add(createItem(type));
                }
                else if (type.IsSubclassOf(typeof(BaseFloor)))
                {
                    lvFloors.Items.Add(createItem(type));
                }
                else if (type.IsSubclassOf(typeof(BaseEnvironment)))
                {
                    lvEnvironments.Items.Add(createItem(type));
                }
                else if (type.IsSubclassOf(typeof(BaseItem)))
                {
                    lvItems.Items.Add(createItem(type));
                }
                else
                {
                    MessageBox.Show("Missed item type: " + type);
                }
            }
        }

        private BuilderItemStruct createItem(Type item)
        {
            BaseObject obj = BaseObjectFacotry.Create(item);
            return new BuilderItemStruct(item, obj.name, obj.GetTexure());
        }

        private void UpdateGridTiles()
        {
            game.Children.Clear();
            spRows.Orientation = Orientation.Horizontal;

            for (int x = 0; x < levelEditor.grid.width; x++)
            {
                StackPanel spCols = new StackPanel();
                spCols.Orientation = Orientation.Vertical;

                for (int y = 0; y < levelEditor.grid.height; y++)
                {
                    Label btnTile = new Label();
                    TileStruct tile = levelEditor.grid.GetTile(x, y);

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

        private void TileClicked(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (ActiveListView != null && ActiveListView.SelectedItem != null)
                {
                    BuilderItemStruct item = (BuilderItemStruct)ActiveListView.SelectedItem;
                    TileStruct tile = (TileStruct)((Label)sender).DataContext;
                    tile.Update(item.type);

                    if(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        FillArea(levelEditor.grid.FindTilePosition(tile), item.type);

                    if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
                        FillAreaSquared(levelEditor.grid.FindTilePosition(tile), item.type);
                }
                else
                {
                    MessageBox.Show("Kies een item");
                }
            }
            else if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                TileStruct tile = (TileStruct)((Label)sender).DataContext;
                RemoveObjectFromTile(tile);
            }
        }

        private void RemoveObjectFromTile(TileStruct tile)
        {
            if (tile.gameObject.GetType() != Blocks.EMPTY)
            {
                tile.Update(Blocks.EMPTY);
            }
            else if (tile.environmentObject.GetType() != Blocks.EMPTY)
            {
                tile.UpdateEnvironment(Blocks.EMPTY);
            }
            else if (tile.gameObject.GetType() != Floors.EMPTY_FLOOR)
            {
                tile.Update(Floors.EMPTY_FLOOR);
            }
        }

        private void FillArea(Pos ClickedPos, Type item)
        {
            if (firstPlacePosition != null)
            {
                int[] PosX = StartFillCorrection(firstPlacePosition.x, ClickedPos.x);
                int[] PosY = StartFillCorrection(firstPlacePosition.y, ClickedPos.y);

                if (Mouse.RightButton == MouseButtonState.Pressed)
                {
                    ClearRow(PosX[0], PosX[1], ClickedPos.y);
                    ClearColumn(PosY[0], PosY[1], ClickedPos.x);
                }
                else
                {
                    FillRow(PosX[0], PosX[1], ClickedPos.y, item);
                    FillColumn(PosY[0], PosY[1], ClickedPos.x, item);
                }
            }
            else
            {
                firstPlacePosition = ClickedPos;
            }
        }

        private void FillRow(int start, int end, int row, Type item)
        {
            for (int x = start; x <= end; x++)
            {
                levelEditor.grid.GetTile(x, row).Update(item);
            }
        }

        private void FillColumn(int start, int end, int column, Type item)
        {
            for (int y = start; y <= end; y++)
            {
                levelEditor.grid.GetTile(column, y).Update(item);
            }
        }

        private void ClearRow(int start, int end, int row)
        {
            for (int x = start; x <= end; x++)
            {
                RemoveObjectFromTile(levelEditor.grid.GetTile(x, row));
            }
        }

        private void ClearColumn(int start, int end, int column)
        {
            for (int y = start; y <= end; y++)
            {
                RemoveObjectFromTile(levelEditor.grid.GetTile(column, y));
            }
        }

        private void FillAreaSquared(Pos ClickedPos, Type item)
        {
            if (firstPlacePosition != null)
            {
                int[] PosX = StartFillCorrection(firstPlacePosition.x, ClickedPos.x);
                int[] PosY = StartFillCorrection(firstPlacePosition.y, ClickedPos.y);

                for (int x = PosX[0]; x <= PosX[1]; x++)
                {
                    levelEditor.grid.GetTile(x, ClickedPos.y).Update(item);
                }
                for (int y = PosY[0]; y <= PosY[1]; y++)
                {
                    levelEditor.grid.GetTile(ClickedPos.x, y).Update(item);
                }
            }
            else
            {
                firstPlacePosition = ClickedPos;
            }
        }

        private int[] StartFillCorrection(int first, int second)
        {
            if(first > second)
            {
                return new int[] { second, first};
            }
            else
            {
                return new int[] { first, second };
            }
        }

        private void CloseAllLists()
        {
            lvBlocks.Visibility = Visibility.Hidden;
            lvEntitiys.Visibility = Visibility.Hidden;
            lvEnvironments.Visibility = Visibility.Hidden;
            lvFloors.Visibility = Visibility.Hidden;
            lvItems.Visibility = Visibility.Hidden;
        }

        private void ButtonHandler(object sender, RoutedEventArgs e)
        {
            Button button = ((Button)sender);
            CloseAllLists();

            switch (button.Name)
            {
                case "btnBlocks":
                    if(ButtonActivationHandler(button))
                        lvBlocks.Visibility = Visibility.Visible;
                    break;
                case "btnEntitys":
                    if (ButtonActivationHandler(button))
                        lvEntitiys.Visibility = Visibility.Visible;
                    break;
                case "btnFloors":
                    if (ButtonActivationHandler(button))
                        lvFloors.Visibility = Visibility.Visible;
                    break;
                case "btnEnvironments":
                    if (ButtonActivationHandler(button))
                        lvEnvironments.Visibility = Visibility.Visible;
                    break;
                case "btnItems":
                    if (ButtonActivationHandler(button))
                        lvItems.Visibility = Visibility.Visible;
                    break;
            }
        }

        private bool ButtonActivationHandler(Button button)
        {
            bool returnValue = false;

            if(button.Tag == null || button.Tag.Equals(false))
            {
                returnValue = true;
            }

            btnBlocks.Tag = false;
            btnEntitys.Tag = false;
            btnEnvironments.Tag = false;
            btnFloors.Tag = false;
            btnItems.Tag = false;

            if (returnValue)
            {
                button.Tag = true;
                return true;
            }
                
            return false;
        }

        private void Object_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HandleSelection)
            {
                HandleSelection = false;
                int SelectedIndex = ((ListView)sender).SelectedIndex;
                ClearAllSelectedIndex();

                ((ListView)sender).SelectedIndex = SelectedIndex;
                ActiveListView = (ListView)sender;
            }
            if (((ListView)sender).SelectedIndex != -1)
                HandleSelection = true;
        }

        private void ClearAllSelectedIndex()
        {
            lvBlocks.SelectedIndex = -1;
            lvEntitiys.SelectedIndex = -1;
            lvEnvironments.SelectedIndex = -1;
            lvFloors.SelectedIndex = -1;
            lvItems.SelectedIndex = -1;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            levelEditor.DestroyGrid();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            PageController.RouteBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            PageController.Route(Pages.Game, levelEditor.grid, true);
            //string levelName = Message.InputMessage("Test message met input");
            //if (!string.IsNullOrWhiteSpace(levelName))
            //{
            //    WebApi.AddNewLevel(levelName, GridConverter.Serialize(levelEditor.grid));

            //    //Message.Warning("Level successfully uploaded");

            //    //PageController.Route(Pages.Menu);

            //    //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), string.Format(@"PuzzleGame\{0}.json", tbSaveName.Text));
            //    //string root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"PuzzleGame\");

            //    //if (!Directory.Exists(root))
            //    //{
            //    //    Directory.CreateDirectory(root);
            //    //}

            //    //// Delete the file if it exists.
            //    //if (File.Exists(path))
            //    //{
            //    //    //File.Delete(path);
            //    //    MessageBox.Show("Naam is al bezet kies een ander.");
            //    //}
            //    //else
            //    //{
            //    //    //Create the file.
            //    //    File.WriteAllText(path, grid.Serialize());
            //    //}
            //}
        }

        private void SaveLevel()
        {
            string levelName = Message.InputMessage("Give youre level a name", "Save", "Cancel");
            if (!string.IsNullOrWhiteSpace(levelName))
            {
                WebApi.AddNewLevel(levelName, GridConverter.Serialize(levelEditor.grid));
            }
        }
    }
}
