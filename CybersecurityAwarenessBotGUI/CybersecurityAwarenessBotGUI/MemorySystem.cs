using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CybersecurityAwarenessBotGUI
{
    public class MemorySystem
    {
        private Dictionary<string, string> _memory = new Dictionary<string, string>();

        // Store a value
        public void Remember(string key, string value)
        {
            if (_memory.ContainsKey(key))
                _memory[key] = value;
            else
                _memory.Add(key, value);
        }

        // Retrieve a value
        public string Recall(string key)
        {
            return _memory.ContainsKey(key) ? _memory[key] : null;
        }

        // Check if something is remembered
        public bool Has(string key)
        {
            return _memory.ContainsKey(key);
        }
    }
}
