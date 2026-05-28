using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBotGUI
{
    public class ResponseSystem
    {
        public static string GetResponse(string userInput)
        {
            string input = userInput.ToLower();

            if (input.Contains("how are you"))
                return "I am doing great, thank you for asking! I am always ready to help you stay safe online.";

            if (input.Contains("purpose") || input.Contains("what do you do"))
                return "My purpose is to help you stay safe online! I can educate you about cybersecurity threats and how to avoid them.";

            if (input.Contains("help") || input.Contains("what can i ask"))
                return "You can ask me about:\n- Password safety\n- Phishing scams\n- Safe browsing\n- Online privacy\n- Malware\n- Two factor authentication";

            if (input.Contains("password"))
                return "Here are some password safety tips:\n- Use a mix of letters, numbers and symbols\n- Never use personal details like your birthday\n- Use a different password for each account\n- Consider using a password manager";

            if (input.Contains("phishing"))
                return "Phishing is when scammers pretend to be trusted organisations to steal your information.\n- Never click suspicious links in emails\n- Always check the sender's email address\n- Do not enter personal details on unknown websites";

            if (input.Contains("safe browsing") || input.Contains("browsing"))
                return "Here are some safe browsing tips:\n- Always look for 'https' in the website address\n- Avoid clicking on pop up ads\n- Keep your browser updated\n- Use a trusted antivirus program";

            if (input.Contains("privacy"))
                return "Protecting your privacy online is important:\n- Review your social media privacy settings\n- Avoid sharing personal details publicly\n- Use a VPN on public Wi-Fi\n- Be careful what apps you give permissions to";

            if (input.Contains("malware"))
                return "Malware is malicious software designed to harm your device:\n- Never download software from untrusted sources\n- Keep your operating system updated\n- Use a reputable antivirus program\n- Avoid clicking unknown email attachments";

            if (input.Contains("two factor") || input.Contains("2fa"))
                return "Two-factor authentication (2FA) adds an extra layer of security:\n- Enable 2FA on all important accounts\n- Use an authenticator app instead of SMS when possible\n- Never share your 2FA codes with anyone";

            return "I did not quite understand that. Could you rephrase? Type 'help' to see what I can assist with.";
        }
    }
}
