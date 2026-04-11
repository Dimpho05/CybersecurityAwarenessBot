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
        public static void GetResponse(string userInput)
        {
            // Convert user input to lower case for easier matching
            string input = userInput.ToLower();

            if (input.Contains("how are you"))
            {
                WriteLine($"\nBot: I am doing great, thank you for asking! I am always ready to help you stay safe online.");
            }
            else if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                WriteLine($"\nBot: My purpose is to help you stay safe online! I can educate you about cybersecurity threats and how to avoid them.");
            }
            else if (input.Contains("what can i ask") || input.Contains("help"))
            {
                WriteLine("\nBot: You can ask me about:");
                WriteLine("     - Password safety");
                WriteLine("     - Phishing scams");
                WriteLine("     - Safe browsing");
               
            }
            else if (input.Contains("password"))
            {
                WriteLine("\nBot: Here are some password safety tips:");
                WriteLine("     - Use a mix of letters, numbers and symbols");
                WriteLine("     - Never use personal details like your birthday");
                WriteLine("     - Use a different password for each account");
                WriteLine("     - Consider using a password manager");
            }
            else if (input.Contains("phishing"))
            {
                WriteLine("\nBot: Phishing is when scammers pretend to be trusted organisations to steal your information.");
                WriteLine("     - Never click suspicious links in emails");
                WriteLine("     - Always check the sender's email address");
                WriteLine("     - Do not enter personal details on unknown websites");
            }
            else if (input.Contains("safe browsing") || input.Contains("browsing"))
            {
                WriteLine("\nBot: Here are some safe browsing tips:");
                WriteLine("     - Always look for 'https' in the website address");
                WriteLine("     - Avoid clicking on pop up ads");
                WriteLine("     - Keep your browser updated");
                WriteLine("     - Use a trusted antivirus program");
            }
            else
            {
                WriteLine("\nBot: I did not quite understand that. Could you rephrase?");
            }
        }
    }
}


