using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CybersecurityAwarenessBotGUI
{
    public class ResponseSystem
    {
        private static Random _random = new Random();
        public static string LastTopic { get; private set; } = "";

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

        private static List<string> _malwareTips = new List<string>
        {
            "Never download software from untrusted sources — always use official websites.",
            "Keep your operating system and apps updated to patch security vulnerabilities.",
            "Use a reputable antivirus program and run regular scans.",
            "Avoid clicking unknown email attachments — they may contain malware.",
            "Ransomware encrypts your files and demands payment. Always back up your data!"
        };

        private static List<string> _twoFATips = new List<string>
        {
            "Two-factor authentication adds an extra layer of security beyond your password.",
            "Use an authenticator app like Google Authenticator instead of SMS when possible.",
            "Never share your 2FA codes with anyone — not even support staff.",
            "Always save your backup codes somewhere safe when setting up 2FA.",
            "Never approve 2FA requests you did not initiate — this may be an attacker."
        };

        public static string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "I didn't receive any input. Please type something!";

            string input = userInput.ToLower().Trim();

            // === NLP: Activity Log commands ===
            if (ContainsAny(input, "show activity log", "what have you done", "recent actions",
                "show log", "activity log", "what did you do", "show history"))
            {
                ActivityLog.Add("User requested activity log");
                return "SHOW_ACTIVITY_LOG";
            }

            // === NLP: Task commands ===
            if (ContainsAny(input, "add task", "create task", "new task", "set a task",
                "i need to", "remind me to", "set reminder", "add a reminder",
                "create a reminder", "schedule a task"))
            {
                ActivityLog.Add("NLP detected task creation intent");
                return "OPEN_TASK_WINDOW";
            }

            if (ContainsAny(input, "show tasks", "view tasks", "my tasks", "list tasks",
                "what are my tasks", "open task", "manage tasks"))
            {
                ActivityLog.Add("NLP detected task view intent");
                return "OPEN_TASK_WINDOW";
            }

            // === NLP: Quiz commands ===
            if (ContainsAny(input, "start quiz", "play quiz", "take quiz", "quiz me",
                "test me", "test my knowledge", "cybersecurity quiz", "begin quiz",
                "i want to play", "open quiz"))
            {
                ActivityLog.Add("NLP detected quiz intent");
                return "OPEN_QUIZ_WINDOW";
            }

            // === Follow-up requests ===
            if (ContainsAny(input, "another tip", "tell me more", "more info",
                "explain more", "give me another", "what else", "more please"))
                return GetFollowUpResponse();

            // === General conversation ===
            if (ContainsAny(input, "how are you", "how r you", "how are u"))
            {
                LastTopic = "";
                return "I'm doing great, thank you for asking! I'm always ready to help you stay safe online.";
            }

            if (ContainsAny(input, "purpose", "what do you do", "what can you do",
                "who are you", "what are you"))
            {
                LastTopic = "";
                return "My purpose is to help you stay safe online! I can educate you about cybersecurity threats and how to avoid them. Type 'help' to see what I can assist with.";
            }

            if (ContainsAny(input, "help", "what can i ask", "menu", "options",
                "what topics", "show topics"))
            {
                LastTopic = "";
                return "You can ask me about:\n- Password safety\n- Phishing scams\n- Safe browsing\n- Online privacy\n- Malware\n- Two-factor authentication\n\nOr try:\n- 'Add task' to manage cybersecurity tasks\n- 'Start quiz' to test your knowledge\n- 'Show activity log' to see recent actions";
            }

            // === Cybersecurity keyword recognition (NLP enhanced) ===
            if (ContainsAny(input, "password", "passwords", "pass word", "passphrase",
                "login", "credentials", "forgot password", "weak password", "strong password"))
            {
                LastTopic = "password";
                ActivityLog.Add("NLP: Discussed password safety");
                return _passwordTips[_random.Next(_passwordTips.Count)];
            }

            if (ContainsAny(input, "phishing", "scam", "fake email", "suspicious email",
                "spam", "fraud", "deceptive", "impersonation"))
            {
                LastTopic = "phishing";
                ActivityLog.Add("NLP: Discussed phishing awareness");
                return _phishingTips[_random.Next(_phishingTips.Count)];
            }

            if (ContainsAny(input, "safe browsing", "browsing", "browser", "website",
                "internet safety", "online safety", "https", "secure site"))
            {
                LastTopic = "browsing";
                ActivityLog.Add("NLP: Discussed safe browsing");
                return _safeBrowsingTips[_random.Next(_safeBrowsingTips.Count)];
            }

            if (ContainsAny(input, "privacy", "private", "personal data", "data protection",
                "personal information", "oversharing", "vpn", "social media privacy"))
            {
                LastTopic = "privacy";
                ActivityLog.Add("NLP: Discussed privacy");
                return _privacyTips[_random.Next(_privacyTips.Count)];
            }

            if (ContainsAny(input, "malware", "virus", "ransomware", "spyware", "trojan",
                "antivirus", "infected", "hacked", "malicious software", "worm"))
            {
                LastTopic = "malware";
                ActivityLog.Add("NLP: Discussed malware");
                return _malwareTips[_random.Next(_malwareTips.Count)];
            }

            if (ContainsAny(input, "two factor", "2fa", "two-factor", "multi factor",
                "mfa", "authenticator", "verification code", "one time password", "otp"))
            {
                LastTopic = "2fa";
                ActivityLog.Add("NLP: Discussed two-factor authentication");
                return _twoFATips[_random.Next(_twoFATips.Count)];
            }

            // === Default response ===
            LastTopic = "";
            return "I'm not sure I understand. Could you rephrase that? Type 'help' to see what I can assist with.";
        }

        // Helper method — checks if input contains any of the given keywords
        private static bool ContainsAny(string input, params string[] keywords)
        {
            foreach (var keyword in keywords)
            {
                if (input.Contains(keyword))
                    return true;
            }
            return false;
        }

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
                    return _malwareTips[_random.Next(_malwareTips.Count)];
                case "2fa":
                    return _twoFATips[_random.Next(_twoFATips.Count)];
                default:
                    return "Could you remind me what topic you'd like more on? Type 'help' to see available topics.";
            }
        }

        public static void SetLastTopic(string topic)
        {
            LastTopic = topic;
        }
    }
}