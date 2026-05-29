using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CybersecurityAwarenessBotGUI
{
    
    // Provides memory and recall functionality for the chatbot.
    // Stores user details in a dictionary for personalised responses.
    
    public class MemorySystem
    {
        // Dictionary to store key-value pairs of user information
        private Dictionary<string, string> _memory = new Dictionary<string, string>();

        //Stores a value associated with a key.
        public void Remember(string key, string value)
        {
            if (_memory.ContainsKey(key))
                _memory[key] = value;
            else
                _memory.Add(key, value);
        }

        //Retrieves a stored value by key. Returns null if not found.
        public string Recall(string key)
        {
            return _memory.ContainsKey(key) ? _memory[key] : null;
        }

        //Checks whether a key exists in memory.
        public bool Has(string key)
        {
            return _memory.ContainsKey(key);
        }
    }
}