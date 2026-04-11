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
            WriteLine("\n===============================================================");
            WriteLine("       Hello! Welcome to the Cybersecurity Awareness Bot    ");
            WriteLine("===============================================================\n");

            WriteLine("Before we begin, may I know your name?");
            Write("Enter your name: ");

            UserName = ReadLine();

            // Keep asking until the user enters a valid name
            while (string.IsNullOrWhiteSpace(UserName))
            {
                WriteLine("Please enter a valid name.");
                Write("Enter your name: ");
                UserName = ReadLine();
            }

            WriteLine($"\nNice to meet you, {UserName}!");
       
        }
    }
}


