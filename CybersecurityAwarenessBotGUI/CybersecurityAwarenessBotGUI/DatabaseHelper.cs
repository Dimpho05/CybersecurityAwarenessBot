using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CybersecurityAwarenessBotGUI
{
    public class DatabaseHelper
    {
        private const string ConnectionString =
            "Server=localhost;Port=3306;Database=cybersecurity_bot;Uid=root;Pwd=SangahRecti99@;";

        public static bool TestConnection()
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch { return false; }
        }

        public static void AddTask(string title, string description, DateTime? reminderDate)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO tasks (title, description, reminder_date) VALUES (@title, @desc, @reminder)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@reminder", reminderDate.HasValue ? (object)reminderDate.Value : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<TaskItem> GetAllTasks()
        {
            var tasks = new List<TaskItem>();
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT id, title, description, is_completed, reminder_date, created_at FROM tasks ORDER BY created_at DESC";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new TaskItem
                        {
                            Id = reader.GetInt32("id"),
                            Title = reader.GetString("title"),
                            Description = reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString("description"),
                            IsCompleted = reader.GetBoolean("is_completed"),
                            ReminderDate = reader.IsDBNull(reader.GetOrdinal("reminder_date")) ? (DateTime?)null : reader.GetDateTime("reminder_date"),
                            CreatedAt = reader.GetDateTime("created_at")
                        });
                    }
                }
            }
            return tasks;
        }

        public static void MarkTaskCompleted(int id)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE tasks SET is_completed = TRUE WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTask(int id)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM tasks WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
