using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBotGUI
{
    
    //Handles all keyword recognition and response generation for the chatbot.
    //Uses lists of responses for random variation and tracks the last topic for follow-up conversation flow.
    
    public class ResponseSystem
    {
        private static Random _random = new Random();

        // Tracks the last cybersecurity topic discussed.
        public static string LastTopic { get; private set; } = "";

        // Random response lists for varied replies on each topic
        private static List<string> _phishingTips = new List<string>
        {
            "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
            "Always hover over links before clicking them. The real URL might look suspicious.",
            "Legitimate companies will never ask for your password via email.",
            "Watch out for urgent language like 'Your account will be closed!' — this is a common phishing tactic.",
            "Check the sender's email address carefully. Scammers often use addresses like 'support@paypa1.com'."
        };

        private static List<string> _passwordTips = new List<string>
        {
            "Use a mix of uppercase, lowercase, numbers and symbols in your passwords.",
            "Never reuse the same password across multiple accounts.",
            "Consider using a passphrase — a sentence that's easy to remember but hard to guess.",
            "Use a password manager to generate and store strong, unique passwords.",
            "Change your passwords immediately if you suspect a breach."
        };

        private static List<string> _privacyTips = new List<string>
        {
            "Review your social media privacy settings regularly.",
            "Avoid oversharing personal details like your address or phone number online.",
            "Use a VPN when connecting to public Wi-Fi networks.",
            "Be careful what permissions you grant to mobile apps.",
            "Regularly check which apps have access to your accounts and revoke any you no longer use."
        };

        private static List<string> _safeBrowsingTips = new List<string>
        {
            "Always look for 'https' and the padlock icon before entering any personal details.",
            "Avoid clicking on pop-up ads — they can lead to malicious websites.",
            "Keep your browser and extensions updated to patch security vulnerabilities.",
            "Use a trusted antivirus program and keep it updated.",
            "Be cautious when downloading files — only use official and trusted sources."
        };

        // Processes user input and returns an appropriate response.
        // Handles follow-ups, keyword recognition, and default error handling.
        public static string GetResponse(string userInput)
        {
            // Validate input as extra safety net
            if (string.IsNullOrWhiteSpace(userInput))
                return "I didn't receive any input. Please type something!";

            string input = userInput.ToLower();

            // Handle follow-up requests
            if (input.Contains("another tip") || input.Contains("tell me more") ||
                input.Contains("more") || input.Contains("explain more") ||
                input.Contains("give me another"))
                return GetFollowUpResponse();

            // General conversation
            if (input.Contains("how are you"))
            {
                LastTopic = "";
                return "I am doing great, thank you for asking! I am always ready to help you stay safe online.";
            }

            if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                LastTopic = "";
                return "My purpose is to help you stay safe online! I can educate you about cybersecurity threats and how to avoid them.";
            }

            if (input.Contains("help") || input.Contains("what can i ask"))
            {
                LastTopic = "";
                return "You can ask me about:\n- Password safety\n- Phishing scams\n- Safe browsing\n- Online privacy\n- Malware\n- Two factor authentication";
            }

            // Cybersecurity keyword recognition
            if (input.Contains("password"))
            {
                LastTopic = "password";
                return _passwordTips[_random.Next(_passwordTips.Count)];
            }

            if (input.Contains("phishing") || input.Contains("scam"))
            {
                LastTopic = "phishing";
                return _phishingTips[_random.Next(_phishingTips.Count)];
            }

            if (input.Contains("safe browsing") || input.Contains("browsing"))
            {
                LastTopic = "browsing";
                return _safeBrowsingTips[_random.Next(_safeBrowsingTips.Count)];
            }

            if (input.Contains("privacy"))
            {
                LastTopic = "privacy";
                return _privacyTips[_random.Next(_privacyTips.Count)];
            }

            if (input.Contains("malware"))
            {
                LastTopic = "malware";
                return "Malware is malicious software designed to harm your device:\n- Never download software from untrusted sources\n- Keep your operating system updated\n- Use a reputable antivirus program\n- Avoid clicking unknown email attachments";
            }

            if (input.Contains("two factor") || input.Contains("2fa"))
            {
                LastTopic = "2fa";
                return "Two-factor authentication (2FA) adds an extra layer of security:\n- Enable 2FA on all important accounts\n- Use an authenticator app instead of SMS when possible\n- Never share your 2FA codes with anyone";
            }

            // Default response for unrecognised input
            LastTopic = "";
            return "I'm not sure I understand. Can you try rephrasing? Type 'help' to see what I can assist with.";
        }

        // Returns a follow-up tip based on the last discussed topic.
        public static string GetFollowUpResponse()
        {
            switch (LastTopic)
            {
                case "password":
                    return _passwordTips[_random.Next(_passwordTips.Count)];
                case "phishing":
                    return _phishingTips[_random.Next(_phishingTips.Count)];
                case "browsing":
                    return _safeBrowsingTips[_random.Next(_safeBrowsingTips.Count)];
                case "privacy":
                    return _privacyTips[_random.Next(_privacyTips.Count)];
                case "malware":
                    return "Here is another malware tip:\n- Ransomware encrypts your files and demands payment. Always back up your data!\n- Spyware secretly monitors your activity. Use anti-spyware tools regularly.\n- Trojans disguise themselves as legitimate software. Only download from trusted sources.";
                case "2fa":
                    return "Here is another 2FA tip:\n- Authenticator apps like Google Authenticator are more secure than SMS codes.\n- Always save your backup codes somewhere safe when setting up 2FA.\n- Never approve 2FA requests you did not initiate.";
                default:
                    return "Could you remind me what topic you'd like more information on? Type 'help' to see available topics.";
            }
        }
        //Allows external classes to set the last topic.
        public static void SetLastTopic(string topic)
        {
            LastTopic = topic;
        }
    }
}