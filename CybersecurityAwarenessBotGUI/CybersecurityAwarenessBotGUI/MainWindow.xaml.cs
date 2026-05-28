using System.Collections.ObjectModel;
using System.Media;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace CybersecurityAwarenessBotGUI
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();
        private UserSession _session = new UserSession();

        public MainWindow()
        {
            InitializeComponent();
            ChatHistory.ItemsSource = Messages;

            PlayVoiceGreeting();

            Messages.Add(ChatMessage.SystemMessage("[ Welcome to the Cybersecurity Awareness Bot ]"));
            Messages.Add(ChatMessage.BotMessage("Hello! Before we begin, what is your name?"));
        }

        private void PlayVoiceGreeting()
        {
            string audioPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
            if (File.Exists(audioPath))
            {
                SoundPlayer player = new SoundPlayer(audioPath);
                player.Load();
                player.Play();
            }
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

            // First collect the user's name
            if (!_session.NameCollected)
            {
                _session.UserName = input;
                _session.NameCollected = true;
                Messages.Add(ChatMessage.BotMessage($"Nice to meet you, {_session.UserName}! I am here to help you stay safe online."));
                Messages.Add(ChatMessage.BotMessage("Type 'help' to see what you can ask me about."));
            }
            else
            {
                // Check for exit
                if (input.ToLower() == "exit")
                {
                    Messages.Add(ChatMessage.BotMessage($"Goodbye {_session.UserName}! Stay safe online!"));
                    return;
                }

                string response = ResponseSystem.GetResponse(input);
                Messages.Add(ChatMessage.BotMessage(response));
            }

            ChatScrollViewer.ScrollToBottom();
        }
    }
}