using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CybersecurityAwarenessBotGUI
{
    public static class ActivityLog
    {
        private static List<string> _log = new List<string>();

        public static void Add(string action)
        {
            string entry = $"[{DateTime.Now:HH:mm:ss}] {action}";
            _log.Add(entry);
        }

        public static List<string> GetRecent(int count = 10)
        {
            var recent = _log.Skip(Math.Max(0, _log.Count - count)).ToList();
            recent.Reverse();
            return recent;
        }

        public static List<string> GetAll()
        {
            var all = _log.ToList();
            all.Reverse();
            return all;
        }

        public static int TotalCount => _log.Count;
    }
}