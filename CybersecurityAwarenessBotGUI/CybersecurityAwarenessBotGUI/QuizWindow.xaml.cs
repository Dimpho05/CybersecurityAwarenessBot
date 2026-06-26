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
using System.Windows.Shapes;

namespace CybersecurityAwarenessBotGUI
{
    public partial class QuizWindow : Window
    {
        private int _currentIndex = 0;
        private int _score = 0;
        private string _selectedAnswer = "";
        private List<QuizQuestion> _questions;

        public QuizWindow()
        {
            InitializeComponent();
            _questions = QuizData.GetQuestions();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (_currentIndex >= _questions.Count)
            {
                ShowFinalScore();
                return;
            }

            var q = _questions[_currentIndex];
            QuestionText.Text = q.Question;
            ProgressText.Text = $"Question {_currentIndex + 1} of {_questions.Count}";

            OptionA.Content = q.Options[0];
            OptionB.Content = q.Options[1];
            OptionC.Content = q.Options[2];
            OptionD.Content = q.Options[3];

            OptionA.IsChecked = false;
            OptionB.IsChecked = false;
            OptionC.IsChecked = false;
            OptionD.IsChecked = false;
            OptionA.IsEnabled = true;
            OptionB.IsEnabled = true;
            OptionC.IsEnabled = true;
            OptionD.IsEnabled = true;

            FeedbackBorder.Visibility = Visibility.Collapsed;
            NextButton.IsEnabled = false;
            _selectedAnswer = "";
        }

        private void Option_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.RadioButton rb)
            {
                _selectedAnswer = rb.Content.ToString();
                CheckAnswer();
            }
        }

        private void CheckAnswer()
        {
            var q = _questions[_currentIndex];
            bool isCorrect = _selectedAnswer == q.CorrectAnswer;

            if (isCorrect)
            {
                _score++;
                ScoreText.Text = $"Score: {_score}";
                FeedbackBorder.Background = new SolidColorBrush(Color.FromRgb(0, 60, 30));
                FeedbackText.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 100));
                FeedbackText.Text = "✔ Correct! " + q.Explanation;
            }
            else
            {
                FeedbackBorder.Background = new SolidColorBrush(Color.FromRgb(60, 0, 0));
                FeedbackText.Foreground = new SolidColorBrush(Color.FromRgb(255, 80, 80));
                FeedbackText.Text = $"✘ Incorrect. The correct answer is: {q.CorrectAnswer}\n{q.Explanation}";
            }

            FeedbackBorder.Visibility = Visibility.Visible;
            OptionA.IsEnabled = false;
            OptionB.IsEnabled = false;
            OptionC.IsEnabled = false;
            OptionD.IsEnabled = false;
            NextButton.IsEnabled = true;

            if (_currentIndex == _questions.Count - 1)
                NextButton.Content = "SEE FINAL SCORE ▶";
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex++;
            LoadQuestion();
        }

        private void ShowFinalScore()
        {
            int total = _questions.Count;
            string feedback;

            if (_score >= 10)
                feedback = "🏆 Outstanding! You're a cybersecurity pro!";
            else if (_score >= 7)
                feedback = "👍 Great job! You have solid cybersecurity knowledge.";
            else if (_score >= 5)
                feedback = "📚 Not bad! Keep learning to stay safe online.";
            else
                feedback = "⚠ Keep studying! Cybersecurity knowledge is essential.";

            QuestionText.Text = $"Quiz Complete!\n\nYour Score: {_score} out of {total}\n\n{feedback}";
            AnswerPanel.Visibility = Visibility.Collapsed;
            FeedbackBorder.Visibility = Visibility.Collapsed;
            NextButton.Content = "CLOSE";
            NextButton.IsEnabled = true;
            NextButton.Click -= Next_Click;
            NextButton.Click += (s, ev) => this.Close();
        }
    }
}