using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBotGUI
{
    
    // Detects the user's sentiment from their input and provides empathetic responses to create a more natural conversation flow.
    
    public class SentimentDetector
    {
        public enum Sentiment
        {
            Neutral,
            Worried,
            Curious,
            Frustrated
        }

        
        // Analyses user input and returns the detected sentiment.
       
        public static Sentiment Detect(string input)
        {
            string lower = input.ToLower();

            // Check for worried/anxious sentiment
            if (lower.Contains("worried") || lower.Contains("scared") ||
                lower.Contains("afraid") || lower.Contains("nervous") ||
                lower.Contains("anxious") || lower.Contains("concern"))
                return Sentiment.Worried;

            // Check for curious sentiment
            if (lower.Contains("curious") || lower.Contains("interesting") ||
    lower.Contains("want to know") || lower.Contains("how does") ||
    lower.Contains("what is") || lower.Contains("why"))
                return Sentiment.Curious;

            // Check for frustrated sentiment
            if (lower.Contains("frustrated") || lower.Contains("annoyed") ||
                lower.Contains("confused") || lower.Contains("dont understand") ||
                lower.Contains("don't understand") || lower.Contains("this is hard") ||
                lower.Contains("too complicated"))
                return Sentiment.Frustrated;

            return Sentiment.Neutral;
        }

       
        //Returns an empathetic opening response based on detected sentiment.
        //Returns null if sentiment is neutral.
        
        public static string GetSentimentResponse(Sentiment sentiment, string userName)
        {
            switch (sentiment)
            {
                case Sentiment.Worried:
                    return $"It's completely understandable to feel that way, {userName}. Cybersecurity can feel overwhelming, but I'm here to help. Let me share some tips to ease your concerns.";
                case Sentiment.Curious:
                    return $"I love your curiosity, {userName}! Asking questions is the first step to staying safe online. Here's what you need to know:";
                case Sentiment.Frustrated:
                    return $"I understand this can feel complicated, {userName}. Don't worry — let's break it down simply. Here's an easy explanation:";
                default:
                    return null;
            }
        }
    }
}