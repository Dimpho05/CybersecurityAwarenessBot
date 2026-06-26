using System;
using System.Windows;

namespace CybersecurityAwarenessBotGUI
{
    public partial class TaskWindow : Window
    {
        public TaskWindow()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            try
            {
                TaskListView.ItemsSource = DatabaseHelper.GetAllTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load tasks: " + ex.Message, "Database Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleBox.Text.Trim();
            string description = DescriptionBox.Text.Trim();
            DateTime? reminderDate = ReminderDatePicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.", "Missing Title",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                DatabaseHelper.AddTask(title, description, reminderDate);
                TitleBox.Clear();
                DescriptionBox.Clear();
                ReminderDatePicker.SelectedDate = null;
                LoadTasks();

                MessageBox.Show($"Task '{title}' added successfully!", "Task Added",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add task: " + ex.Message, "Database Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MarkComplete_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListView.SelectedItem is TaskItem selected)
            {
                try
                {
                    DatabaseHelper.MarkTaskCompleted(selected.Id);
                    LoadTasks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not update task: " + ex.Message, "Database Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a task first.", "No Task Selected",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListView.SelectedItem is TaskItem selected)
            {
                var result = MessageBox.Show($"Delete '{selected.Title}'?", "Confirm Delete",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DatabaseHelper.DeleteTask(selected.Id);
                        LoadTasks();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not delete task: " + ex.Message, "Database Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a task first.", "No Task Selected",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadTasks();
        }
    }
}