using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CybersecurityAwarenessBotGUI
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();

        public MainWindow()
        {
            InitializeComponent();
            ChatHistory.ItemsSource = Messages;

            Messages.Add(ChatMessage.SystemMessage("[ Welcome to the Cybersecurity Awareness Bot ]"));
            Messages.Add(ChatMessage.BotMessage("Hello! What is your name?"));
        }

        private void SendButton_Click(object sender, RoutedEventArgs e) => ProcessInput();

        private void UserInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) ProcessInput();
        }

        private void UserInputBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            PlaceholderText.Visibility = string.IsNullOrEmpty(UserInputBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void ProcessInput()
        {
            string input = UserInputBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            Messages.Add(ChatMessage.UserMessage(input));
            UserInputBox.Clear();

            Messages.Add(ChatMessage.BotMessage("(response logic coming in Commit 2)"));

            ChatScrollViewer.ScrollToBottom();
        }
    }
}
