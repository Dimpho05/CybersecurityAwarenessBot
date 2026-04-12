using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CybersecurityAwarenessBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Play voice greeting
            Greeting.PlayVoiceGreeting();

            //Display ASCII art
            AsciiArt.DisplayLogo();

            // Get user name and display welcome message
            UserInteraction.GetUserName();

            // Start the chat
            ChatBot.StartChat();

            ReadLine();
        }
    }
}



