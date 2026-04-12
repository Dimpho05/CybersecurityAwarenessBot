using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CybersecurityAwarenessBot
{
    internal class ChatBot
    {
        public static void StartChat()
        {
            ConsoleUI.PrintHeader($"     How can I help you today?");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("     Type 'exit' to quit\n");
            ResetColor();

            // Keep the conversation going until user types exit
            while (true)
            {
                ConsoleUI.PrintUserPrompt(UserInteraction.UserName);
                string userInput = ReadLine();

                // Check for exit command
                if (userInput.ToLower() == "exit")
                {
                    ConsoleUI.TypeMessage($"Goodbye {UserInteraction.UserName}! Stay safe online!");
                    ConsoleUI.PrintBorder();
                    break;
                }

                // Validate user input
                if (!ResponseSystem.IsValidInput(userInput))
                {
                    continue;
                }

                //Get response from ResponseSystem
                ResponseSystem.GetResponse(userInput);
                ConsoleUI.PrintBorder();
            }
        }
    }
}



           
    



