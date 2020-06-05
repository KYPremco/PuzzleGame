using AutoUpdaterDotNET;
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
using System.Xml;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<GameObject> gameObjectList = new List<GameObject>();

        public MainWindow()
        {
            AutoUpdater.RunUpdateAsAdmin = false;
            AutoUpdater.AppTitle = "Puzzle game";
            AutoUpdater.Start("http://puzzle.runotrack.com/autoupdater/autoupdater.xml");

            InitializeComponent();
            DataContext = PageController.Instance;

            PageController.Route(Pages.Menu);


            gameObjectList.Clear(); //Maakt de listview leeg
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\development\PuzzleGame\old\Images\sokoban_spritesheet.xml"); //laad xmlbestand in xmlDoc
            XmlNodeList imageNodes = xmlDoc.SelectNodes("//TextureAtlas/SubTexture"); //Zoek nodes
            foreach (XmlNode image in imageNodes)
            {
                GameObject imageEntity = new GameObject() { name = image.Attributes["name"].Value, x = int.Parse(image.Attributes["x"].Value), y = int.Parse(image.Attributes["y"].Value), height = int.Parse(image.Attributes["width"].Value), width = int.Parse(image.Attributes["height"].Value) };
                gameObjectList.Add(imageEntity);
            }

            foreach(GameObject gameObject in gameObjectList) 
            {
                //lvAllItems.Items.Add(new DisplayClass { name = gameObject.name, image = getImageFromSprite(gameObject.name.ToEnum<GameObjects>()), x = gameObject.x, y = gameObject.y, height = gameObject.height, width = gameObject.width });
            }
        }

        public CroppedBitmap getImageFromSprite(GameObjects objectID)
        {
            GameObject gameObject = gameObjectList[(int)objectID];
            return new CroppedBitmap(new BitmapImage(new Uri(@"pack://application:,,,/old/Images/sokoban_spritesheet.png")), new Int32Rect(gameObject.x, gameObject.y, gameObject.height, gameObject.width));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //new GameDebug().Show();
        }

        private void HandleNavigating(Object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Forward)
            {
                e.Cancel = true;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PageController.Route(Pages.NewUser);
        }

        private void FramePageViewer_Navigated(object sender, NavigationEventArgs e)
        {
            framePageViewer.NavigationService.RemoveBackEntry();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                PageController.RouteBack();
            }
        }
    }
}
