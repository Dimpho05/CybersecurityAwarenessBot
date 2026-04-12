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
            WriteLine($"\nHi {UserInteraction.UserName}! Type your question below.");
            WriteLine("(Type 'exit' to quit)\n");

            // Keep the conversation going until user types exit
            while (true)
            {
                Write($"{UserInteraction.UserName}: ");
                string userInput = ReadLine();

                // Check for exit command
                if (userInput.ToLower() == "exit")
                {
                    WriteLine($"\nBot: Goodbye {UserInteraction.UserName}! Stay safe online!");
                    break;
                }

                // Validate user input
                if (!ResponseSystem.IsValidInput(userInput))
                {
                    continue;
                }

                //Get response from ResponseSystem
                ResponseSystem.GetResponse(userInput);
                WriteLine();
            }
        }
    }
}



