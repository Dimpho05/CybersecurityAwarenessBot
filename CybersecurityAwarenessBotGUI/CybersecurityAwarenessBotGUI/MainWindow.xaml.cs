using System.Collections.ObjectModel;
using System.Media;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace CybersecurityAwarenessBotGUI
{
    // Main window code-behind. Handles UI interaction, coordinates between
    // all system classes and manages the conversation flow.
    public partial class MainWindow : Window
    {
        // Observable collection so the UI updates automatically when messages are added
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();

        // Core systems
        private UserSession _session = new UserSession();
        private MemorySystem _memory = new MemorySystem();

        public MainWindow()
        {
            InitializeComponent();
            ChatHistory.ItemsSource = Messages;

            // Play voice greeting on startup
            PlayVoiceGreeting();

            // Initial bot messages
            Messages.Add(ChatMessage.SystemMessage("[ Welcome to the Cybersecurity Awareness Bot ]"));
            Messages.Add(ChatMessage.BotMessage("Hello! Before we begin, what is your name?"));
        }

        // Plays the WAV voice greeting if the file exists.
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

        // Shows or hides the placeholder text based on input box content.
        private void UserInputBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            PlaceholderText.Visibility = string.IsNullOrEmpty(UserInputBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        
        //Core method that processes user input and coordinates responses from the sentiment detector, memory system and response system.
       
        private void ProcessInput()
        {
            string input = UserInputBox.Text.Trim();

            // Validate input
            if (string.IsNullOrWhiteSpace(input)) return;

            Messages.Add(ChatMessage.UserMessage(input));
            UserInputBox.Clear();

            // Step 1: Collect the user's name first
            if (!_session.NameCollected)
            {
                _session.UserName = input;
                _session.NameCollected = true;
                _memory.Remember("name", input);
                Messages.Add(ChatMessage.BotMessage($"Nice to meet you, {_session.UserName}! I am here to help you stay safe online."));
                Messages.Add(ChatMessage.BotMessage("Type 'help' to see what you can ask me about."));
                Messages.Add(ChatMessage.BotMessage("Type 'exit' to leave the chat at any time."));
                ChatScrollViewer.ScrollToBottom();
                return;
            }

            string lowerInput = input.ToLower();

            // Step 2: Check for exit command
            if (lowerInput == "exit")
            {
                Messages.Add(ChatMessage.BotMessage($"Goodbye {_session.UserName}! Stay safe online!"));
                ChatScrollViewer.ScrollToBottom();
                return;
            }

            // Step 3: Detect and respond to sentiment
            var sentiment = SentimentDetector.Detect(input);
            string sentimentResponse = SentimentDetector.GetSentimentResponse(sentiment, _session.UserName);
            if (sentimentResponse != null)
                Messages.Add(ChatMessage.BotMessage(sentimentResponse));

            // Step 4: Check if user is sharing a favourite topic for memory
            if (lowerInput.Contains("i am interested in") || lowerInput.Contains("i'm interested in") || lowerInput.Contains("im interested in"))
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

            // Step 5: Get response from ResponseSystem
            // If only sentiment words with no cybersecurity keyword, use last topic as fallback
            bool hasCyberKeyword = input.ToLower().Contains("password") || input.ToLower().Contains("phishing") ||
                                   input.ToLower().Contains("privacy") || input.ToLower().Contains("malware") ||
                                   input.ToLower().Contains("browsing") || input.ToLower().Contains("scam") ||
                                   input.ToLower().Contains("2fa") || input.ToLower().Contains("two factor") ||
                                   input.ToLower().Contains("help") || input.ToLower().Contains("how are you");

            string response;
            if (!hasCyberKeyword && sentiment != SentimentDetector.Sentiment.Neutral && ResponseSystem.LastTopic != "")
                response = ResponseSystem.GetFollowUpResponse();
            else
                response = ResponseSystem.GetResponse(input);

            // Step 6: Personalise response using memory if a favourite topic is stored
            if (_memory.Has("favourite_topic"))
            {
                string fav = _memory.Recall("favourite_topic");
                if (!lowerInput.Contains(fav))
                    response += $"\n\nAs someone interested in {fav}, you might also want to review your security settings regularly.";
            }

            Messages.Add(ChatMessage.BotMessage(response));
            ChatScrollViewer.ScrollToBottom();
        }


        // Extracts a cybersecurity topic from the user's input string.

        private string ExtractTopic(string input)
        {
            if (input.Contains("password")) { ResponseSystem.SetLastTopic("password"); return "password safety"; }
            if (input.Contains("phishing")) { ResponseSystem.SetLastTopic("phishing"); return "phishing"; }
            if (input.Contains("privacy")) { ResponseSystem.SetLastTopic("privacy"); return "privacy"; }
            if (input.Contains("browsing")) { ResponseSystem.SetLastTopic("browsing"); return "safe browsing"; }
            if (input.Contains("malware")) { ResponseSystem.SetLastTopic("malware"); return "malware"; }
            if (input.Contains("2fa") || input.Contains("two factor")) { ResponseSystem.SetLastTopic("2fa"); return "two-factor authentication"; }
            return null;
        }
    }
}