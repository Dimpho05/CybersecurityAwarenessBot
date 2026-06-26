using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBotGUI
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? ReminderDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public string StatusDisplay => IsCompleted ? "✔ Completed" : "Pending";
        public string ReminderDisplay => ReminderDate.HasValue
            ? ReminderDate.Value.ToString("dd MMM yyyy")
            : "No reminder";
    }
}
