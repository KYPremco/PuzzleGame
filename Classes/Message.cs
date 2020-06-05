namespace PuzzleGame
{
    static class Message
    {
        public static void Warning(string message)
        {
            new MessageWindow(message).ShowDialog();
        }
        
        public static bool SelectionMessage(string message, string btnAcceptText = "Accept", string btnDeclineText = "Decline")
        {
            return new MessageWindow(message, true, false, btnAcceptText, btnDeclineText).ShowDialog() ?? false;
        }

        public static string InputMessage(string message, string btnAcceptText = "Accept", string btnDeclineText = "Decline")
        {
            MessageWindow messageWindow = new MessageWindow(message, true, true, btnAcceptText, btnDeclineText);
            return messageWindow.ShowDialog() ?? false ? messageWindow._inputMessage : null;          
        }
    }
}
