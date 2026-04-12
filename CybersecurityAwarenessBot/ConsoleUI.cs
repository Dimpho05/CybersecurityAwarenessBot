using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CybersecurityAwarenessBot
{
    internal class ConsoleUI
    {
        // Prints a full border line
        public static void PrintBorder()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("============================================================");
            ResetColor();
        }

        // Prints a section header with borders
        public static void PrintHeader(string title)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("\n============================================================");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"   {title}");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("============================================================\n");
            ResetColor();
        }

        // Prints bot messages in a specific colour
        public static void PrintBotMessage(string message)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\nBot: {message}");
            ResetColor();
        }

        // Prints user prompt in a specific colour
        public static void PrintUserPrompt(string userName)
        {
            ForegroundColor = ConsoleColor.White;
            Write($"{userName}: ");
            ResetColor();
        }

        // Simulates typing effect for bot messages
        public static void TypeMessage(string message)
        {
            ForegroundColor = ConsoleColor.Green;
            Write("\nBot: ");
            foreach (char c in message)
            {
                Write(c);
                System.Threading.Thread.Sleep(30); // slight delay between each character
            }
            WriteLine();
            ResetColor();
        }
    }
}


