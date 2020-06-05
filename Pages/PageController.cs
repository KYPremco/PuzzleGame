using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PuzzleGame
{
#pragma warning disable 414, CS0067
    public class PageController : INotifyPropertyChanged
    {
        public static PageController Instance = new PageController();

        public event PropertyChangedEventHandler PropertyChanged;
        public Page CurrentPage { get; set; } = new NewUserPage();

        public static Pages CurrentPageId { get; set; } = Pages.NewUser;

        public static void Route(Pages page, dynamic parameter = null, bool mode = false)
        {
            switch(page)
            {
                case Pages.NewUser:
                    Instance.CurrentPage = new NewUserPage();
                    break;
                case Pages.Menu:
                    Instance.CurrentPage = new MenuPage();
                    break;
                case Pages.LevelSelector:
                    Instance.CurrentPage = new LevelSelectorPage();
                    break;
                case Pages.LevelEditor:
                    Instance.CurrentPage = new LevelEditorPage(parameter, mode);
                    break;
                case Pages.Game:
                    if (!ReferenceEquals(null, parameter))
                        Instance.CurrentPage = new GamePage(parameter, mode);
                    break;
            }
            CurrentPageId = page;
        }

        public static void RouteBack()
        {
            switch (CurrentPageId)
            {
                case Pages.NewUser:
                case Pages.Menu:
                    if (Message.SelectionMessage("Are you sure you want to quit ??", "Quit", "Cancel"))
                        Application.Current.Shutdown();
                    break;
                case Pages.LevelSelector:
                    Route(Pages.Menu);
                    break;
                case Pages.LevelEditor:
                    if (Message.SelectionMessage("Are you sure you want to exit the editor all progress will be lost", "Leave!", "Stay!"))
                        Route(Pages.Menu);
                    break;
                case Pages.Game:
                    ((GamePage)Instance.CurrentPage).Close();
                    break;
                default:
                    Route(--CurrentPageId);
                    break;
            }
        }
    }
}
