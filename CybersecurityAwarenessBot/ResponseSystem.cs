using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CybersecurityAwarenessBot
{
    internal class ResponseSystem
    {
        //Input validation
        public static bool IsValidInput(string userInput)
        {
            // Check if input is empty or just spaces
            if (string.IsNullOrWhiteSpace(userInput))
            {
                ConsoleUI.TypeMessage("Please type something, I did not receive any input!");
                return false;
            }
            return true;
        }

        // Basic response system
        public static void GetResponse(string userInput)
        {
            // Convert to lowercase so we can match regardless of how user types
            string input = userInput.ToLower();

            if (input.Contains("how are you"))
            {
                ConsoleUI.TypeMessage("I am doing great, thank you for asking! I am always ready to help you stay safe online.");
            }
            else if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                ConsoleUI.TypeMessage("My purpose is to help you stay safe online! I can educate you about cybersecurity threats and how to avoid them.");
            }
            else if (input.Contains("what can i ask") || input.Contains("help"))
            {
                ConsoleUI.TypeMessage("You can ask me about:");
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("     - Password safety");
                WriteLine("     - Phishing scams");
                WriteLine("     - Safe browsing");
                WriteLine("     - Online privacy");
                ResetColor();
            }
            else if (input.Contains("password"))
            {
                ConsoleUI.TypeMessage("Here are some password safety tips:");
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("     - Use a mix of letters, numbers and symbols");
                WriteLine("     - Never use personal details like your birthday");
                WriteLine("     - Use a different password for each account");
                WriteLine("     - Consider using a password manager");
                ResetColor();
            }
            else if (input.Contains("phishing"))
            {
                ConsoleUI.TypeMessage("Phishing is when scammers pretend to be trusted organisations to steal your information.");
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("     - Never click suspicious links in emails");
                WriteLine("     - Always check the sender's email address");
                WriteLine("     - Do not enter personal details on unknown websites");
                ResetColor();
            }
            else if (input.Contains("safe browsing") || input.Contains("browsing"))
            {
                ConsoleUI.TypeMessage("Here are some safe browsing tips:");
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("     - Always look for 'https' in the website address");
                WriteLine("     - Avoid clicking on pop up ads");
                WriteLine("     - Keep your browser updated");
                WriteLine("     - Use a trusted antivirus program");
                ResetColor();
            }
            else
            {
                ConsoleUI.TypeMessage("I did not quite understand that. Could you rephrase?");
            }
        }
    }
}





