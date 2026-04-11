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
            // Question 1 - Play voice greeting
            Greeting.PlayVoiceGreeting();

            // Question 2 - Display ASCII art
            AsciiArt.DisplayLogo();

            // Question 3 - Get user name and display welcome message
            UserInteraction.GetUserName();

            ReadLine();
        }
    }
}



