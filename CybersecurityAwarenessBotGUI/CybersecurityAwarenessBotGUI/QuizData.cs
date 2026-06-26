using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CybersecurityAwarenessBotGUI
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string Explanation { get; set; }
    }

    public static class QuizData
    {
        public static List<QuizQuestion> GetQuestions()
        {
            return new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "Q1. What should you do if you receive an email asking for your password?",
                    Options = new List<string> { "A) Reply with your password", "B) Delete the email", "C) Report the email as phishing", "D) Ignore it" },
                    CorrectAnswer = "C) Report the email as phishing",
                    Explanation = "Reporting phishing emails helps protect others and prevents scammers from succeeding."
                },
                new QuizQuestion
                {
                    Question = "Q2. What is the minimum recommended length for a strong password?",
                    Options = new List<string> { "A) 6 characters", "B) 8 characters", "C) 12 characters", "D) 4 characters" },
                    CorrectAnswer = "C) 12 characters",
                    Explanation = "Longer passwords are exponentially harder to crack. 12+ characters with mixed types is recommended."
                },
                new QuizQuestion
                {
                    Question = "Q3. True or False: Using the same password for multiple accounts is safe if the password is strong.",
                    Options = new List<string> { "A) True", "B) False", "C) Only for banking sites", "D) Only if you use 2FA" },
                    CorrectAnswer = "B) False",
                    Explanation = "If one site is breached, attackers will try your password on other sites — known as credential stuffing."
                },
                new QuizQuestion
                {
                    Question = "Q4. What does 2FA stand for?",
                    Options = new List<string> { "A) Two-Factor Authentication", "B) Two-File Access", "C) Twice-Failed Attempt", "D) Two-Firewall Architecture" },
                    CorrectAnswer = "A) Two-Factor Authentication",
                    Explanation = "2FA adds an extra layer of security by requiring a second form of verification beyond your password."
                },
                new QuizQuestion
                {
                    Question = "Q5. Which of the following is a sign of a phishing website?",
                    Options = new List<string> { "A) HTTPS in the URL", "B) Misspelled domain name", "C) A padlock icon", "D) A professional design" },
                    CorrectAnswer = "B) Misspelled domain name",
                    Explanation = "Phishing sites often use misspelled domains like 'paypa1.com' to trick users into thinking they're legitimate."
                },
                new QuizQuestion
                {
                    Question = "Q6. What is social engineering in cybersecurity?",
                    Options = new List<string> { "A) Building social media apps", "B) Manipulating people to reveal confidential info", "C) Engineering secure networks", "D) Blocking social media at work" },
                    CorrectAnswer = "B) Manipulating people to reveal confidential info",
                    Explanation = "Social engineering exploits human psychology rather than technical vulnerabilities to gain access."
                },
                new QuizQuestion
                {
                    Question = "Q7. True or False: Public Wi-Fi networks are always safe to use for online banking.",
                    Options = new List<string> { "A) True", "B) False", "C) Only in coffee shops", "D) Only with a VPN" },
                    CorrectAnswer = "B) False",
                    Explanation = "Public Wi-Fi is often unencrypted. Attackers can intercept your data. Use a VPN if you must connect."
                },
                new QuizQuestion
                {
                    Question = "Q8. What is ransomware?",
                    Options = new List<string> { "A) Software that speeds up your PC", "B) A type of antivirus", "C) Malware that encrypts your files and demands payment", "D) A firewall tool" },
                    CorrectAnswer = "C) Malware that encrypts your files and demands payment",
                    Explanation = "Ransomware locks your files and demands a ransom to restore access. Regular backups are the best defence."
                },
                new QuizQuestion
                {
                    Question = "Q9. Which action best protects your online accounts?",
                    Options = new List<string> { "A) Using your name as password", "B) Enabling two-factor authentication", "C) Sharing passwords with trusted friends", "D) Using the same password everywhere" },
                    CorrectAnswer = "B) Enabling two-factor authentication",
                    Explanation = "2FA significantly reduces the risk of account takeover even if your password is compromised."
                },
                new QuizQuestion
                {
                    Question = "Q10. What should you do before clicking a link in an email?",
                    Options = new List<string> { "A) Click it immediately", "B) Forward it to friends", "C) Hover over it to check the real URL", "D) Reply to the sender first" },
                    CorrectAnswer = "C) Hover over it to check the real URL",
                    Explanation = "Hovering reveals the actual destination URL, helping you spot malicious or misleading links."
                },
                new QuizQuestion
                {
                    Question = "Q11. True or False: Antivirus software alone is enough to protect your computer from all threats.",
                    Options = new List<string> { "A) True", "B) False", "C) Only for Windows users", "D) Only for business computers" },
                    CorrectAnswer = "B) False",
                    Explanation = "Antivirus is just one layer. You also need updates, strong passwords, 2FA, and safe browsing habits."
                },
                new QuizQuestion
                {
                    Question = "Q12. What is the safest way to store your passwords?",
                    Options = new List<string> { "A) Write them in a notebook", "B) Save them in a browser only", "C) Use a reputable password manager", "D) Memorise them all" },
                    CorrectAnswer = "C) Use a reputable password manager",
                    Explanation = "Password managers securely store and generate strong, unique passwords for every account."
                }
            };
        }
    }
}
