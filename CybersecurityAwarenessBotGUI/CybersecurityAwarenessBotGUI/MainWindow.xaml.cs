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

        // Opens the Task Assistant window
        private void OpenTasks_Click(object sender, RoutedEventArgs e)
        {
            ActivityLog.Add("User opened Task Assistant");
            var taskWindow = new TaskWindow();
            taskWindow.ShowDialog();
        }

        // Opens the Quiz window
        private void OpenQuiz_Click(object sender, RoutedEventArgs e)
        {
            ActivityLog.Add("User opened Quiz");
            var quizWindow = new QuizWindow();
            quizWindow.ShowDialog();
        }

        // Opens the Activity Log window
        private void OpenActivityLog_Click(object sender, RoutedEventArgs e)
        {
            var logWindow = new ActivityLogWindow();
            logWindow.ShowDialog();
        }

        private void ProcessInput()
        {
            string input = UserInputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input)) return;

            Messages.Add(ChatMessage.UserMessage(input));
            UserInputBox.Clear();

            // Step 1: Collect the user's name first
            if (!_session.NameCollected)
            {
                _session.UserName = input;
                _session.NameCollected = true;
                _memory.Remember("name", input);
                ActivityLog.Add($"User session started for: {_session.UserName}");
                Messages.Add(ChatMessage.BotMessage($"Nice to meet you, {_session.UserName}! I am here to help you stay safe online."));
                Messages.Add(ChatMessage.BotMessage("Type 'help' to see what you can ask me about."));
                Messages.Add(ChatMessage.BotMessage("You can also use the buttons below to access the Task Assistant, Quiz, and Activity Log."));
                ChatScrollViewer.ScrollToBottom();
                return;
            }

            string lowerInput = input.ToLower();

            // Step 2: Check for exit command
            if (lowerInput == "exit")
            {
                Messages.Add(ChatMessage.BotMessage($"Goodbye {_session.UserName}! Stay safe online!"));
                ActivityLog.Add("User ended the chat session");
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
                    Messages.Add(ChatMessage.BotMessage($"Great! I'll remember that you're interested in {topic}."));
                    ActivityLog.Add($"User interest remembered: {topic}");
                    ChatScrollViewer.ScrollToBottom();
                    return;
                }
            }

            // Step 5: Get response from ResponseSystem
            string response = ResponseSystem.GetResponse(input);

            // Step 6: Handle special NLP commands returned by ResponseSystem
            if (response == "OPEN_TASK_WINDOW")
            {
                Messages.Add(ChatMessage.BotMessage("Opening your Task Assistant..."));
                ChatScrollViewer.ScrollToBottom();
                ActivityLog.Add("NLP: Opened Task Assistant via chat command");
                var taskWindow = new TaskWindow();
                taskWindow.ShowDialog();
                return;
            }

            if (response == "OPEN_QUIZ_WINDOW")
            {
                Messages.Add(ChatMessage.BotMessage("Starting the Cybersecurity Quiz..."));
                ChatScrollViewer.ScrollToBottom();
                ActivityLog.Add("NLP: Opened Quiz via chat command");
                var quizWindow = new QuizWindow();
                quizWindow.ShowDialog();
                return;
            }

            if (response == "SHOW_ACTIVITY_LOG")
            {
                Messages.Add(ChatMessage.BotMessage("Opening your Activity Log..."));
                ChatScrollViewer.ScrollToBottom();
                var logWindow = new ActivityLogWindow();
                logWindow.ShowDialog();
                return;
            }

            // Step 7: Personalise response using memory
            if (_memory.Has("favourite_topic"))
            {
                string fav = _memory.Recall("favourite_topic");
                if (!lowerInput.Contains(fav))
                    response += $"\n\nAs someone interested in {fav}, you might also want to review your security settings regularly.";
            }

            Messages.Add(ChatMessage.BotMessage(response));
            ChatScrollViewer.ScrollToBottom();
        }

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