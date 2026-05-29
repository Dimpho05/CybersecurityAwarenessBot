using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBotGUI
{
    
    // Stores session information for the current user interaction.
    
    public class UserSession
    {
        //The user's name collected at the start of the session.
        public string UserName { get; set; }

        //Tracks whether the user's name has been collected.
        public bool NameCollected { get; set; } = false;
    }
}