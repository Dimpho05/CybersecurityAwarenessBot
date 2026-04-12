using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CybersecurityAwarenessBot
{
    internal class UserInteraction
    {
        // Store the user's name so we can use it throughout the conversation
        public static string UserName { get; set; }

        public static void GetUserName()
        {
            ConsoleUI.PrintHeader("Welcome to the Cybersecurity Awareness Bot!");

            ConsoleUI.TypeMessage("Before we begin, may I know your name?");
            ConsoleUI.PrintUserPrompt("You");

            UserName = ReadLine();

            // Keep asking until the user enters a valid name
            while (string.IsNullOrWhiteSpace(UserName))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Please enter a valid name.");
                ResetColor();
                ConsoleUI.PrintUserPrompt("You");
                UserName = ReadLine();
            }

            ConsoleUI.TypeMessage($"Nice to meet you, {UserName}!");
            ConsoleUI.TypeMessage($"I am here to help you stay safe online, {UserName}.");
            ConsoleUI.PrintBorder();
        }
    }
}





