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

                // Check if the user wants to exit the chat
                if (userInput.ToLower() == "exit")
                {
                    WriteLine($"\nBot: Goodbye {UserInteraction.UserName}! Stay safe online!");
                    break;
                }

                // Get the bot's response based on user input
                ResponseSystem.GetResponse(userInput);
                WriteLine();
            }
        }
    }
}


