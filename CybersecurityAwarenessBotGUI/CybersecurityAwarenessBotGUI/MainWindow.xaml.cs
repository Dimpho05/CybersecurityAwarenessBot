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
        private MemorySystem _memory = new MemorySystem();

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

            // Step 1: Collect name
            if (!_session.NameCollected)
            {
                _session.UserName = input;
                _session.NameCollected = true;
                _memory.Remember("name", input);
                Messages.Add(ChatMessage.BotMessage($"Nice to meet you, {_session.UserName}! I am here to help you stay safe online."));
                Messages.Add(ChatMessage.BotMessage("Type 'help' to see what you can ask me about."));
                ChatScrollViewer.ScrollToBottom();
                return;
            }

            string lowerInput = input.ToLower();

            // Check for exit
            if (lowerInput == "exit")
            {
                Messages.Add(ChatMessage.BotMessage($"Goodbye {_session.UserName}! Stay safe online!"));
                ChatScrollViewer.ScrollToBottom();
                return;
            }

            // Memory: detect if user mentions a favourite topic
            if (lowerInput.Contains("i am interested in") || lowerInput.Contains("i'm interested in"))
            {
                string topic = ExtractTopic(lowerInput);
                if (topic != null)
                {
                    _memory.Remember("favourite_topic", topic);
                    Messages.Add(ChatMessage.BotMessage($"Great! I'll remember that you're interested in {topic}. It's a crucial part of staying safe online."));
                    ChatScrollViewer.ScrollToBottom();
                    return;
                }
            }

            // Memory: recall favourite topic in response
            string response = ResponseSystem.GetResponse(input);

            // Personalise response using memory
            if (_memory.Has("favourite_topic"))
            {
                string fav = _memory.Recall("favourite_topic");
                if (!lowerInput.Contains(fav))
                {
                    response += $"\n\nAs someone interested in {fav}, you might also want to review your security settings regularly.";
                }
            }

            Messages.Add(ChatMessage.BotMessage(response));
            ChatScrollViewer.ScrollToBottom();
        }

        private string ExtractTopic(string input)
        {
            if (input.Contains("password")) return "password safety";
            if (input.Contains("phishing")) return "phishing";
            if (input.Contains("privacy")) return "privacy";
            if (input.Contains("browsing")) return "safe browsing";
            if (input.Contains("malware")) return "malware";
            if (input.Contains("2fa") || input.Contains("two factor")) return "two-factor authentication";
            return null;
        }
    }
}