using System.Windows;

namespace PuzzleGame
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public string _inputMessage { get; private set; }

        public MessageWindow(string message, bool selection = false, bool inputMessage = false, string btnAcceptText = "", string btnDeclineText = "")
        {
            InitializeComponent();

            if(selection)
            {
                spContinue.Visibility = Visibility.Hidden;
                spSelection.Visibility = Visibility.Visible;

                btnAccept.Content = btnAcceptText;
                btnDecline.Content = btnDeclineText;
            }

            if(inputMessage)
            {
                tbInputMessage.Visibility = Visibility.Visible;
            }

            tbMessage.Text = message;
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnDecline_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void TbInputMessage_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            _inputMessage = tbInputMessage.Text;
        }
    }
}
