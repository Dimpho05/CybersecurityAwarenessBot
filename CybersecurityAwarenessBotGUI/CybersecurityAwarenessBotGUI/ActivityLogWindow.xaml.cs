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
    public partial class ActivityLogWindow : Window
    {
        private bool _showingAll = false;

        public ActivityLogWindow()
        {
            InitializeComponent();
            LoadLog();
        }

        private void LoadLog()
        {
            if (_showingAll)
            {
                LogListBox.ItemsSource = ActivityLog.GetAll();
                SubtitleText.Text = $"Showing all {ActivityLog.TotalCount} actions";
                ShowMoreButton.Content = "▲ SHOW LESS";
            }
            else
            {
                LogListBox.ItemsSource = ActivityLog.GetRecent(10);
                SubtitleText.Text = $"Showing last 10 of {ActivityLog.TotalCount} actions";
                ShowMoreButton.Content = "▼ SHOW FULL HISTORY";
            }

            if (ActivityLog.TotalCount == 0)
            {
                LogListBox.ItemsSource = new[] { "No activity recorded yet." };
                ShowMoreButton.IsEnabled = false;
            }
        }

        private void ShowMore_Click(object sender, RoutedEventArgs e)
        {
            _showingAll = !_showingAll;
            LoadLog();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}