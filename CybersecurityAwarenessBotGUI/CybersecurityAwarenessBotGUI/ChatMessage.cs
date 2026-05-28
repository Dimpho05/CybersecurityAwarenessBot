using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CybersecurityAwarenessBotGUI
{
    public class ChatMessage
    {
        public string Text { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        public SolidColorBrush Background { get; set; }
        public SolidColorBrush Foreground { get; set; }

        public static ChatMessage BotMessage(string text) => new ChatMessage
        {
            Text = text,
            HorizontalAlignment = HorizontalAlignment.Left,
            Background = new SolidColorBrush(Color.FromRgb(20, 40, 40)),
            Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 150))
        };

        public static ChatMessage UserMessage(string text) => new ChatMessage
        {
            Text = text,
            HorizontalAlignment = HorizontalAlignment.Right,
            Background = new SolidColorBrush(Color.FromRgb(0, 80, 120)),
            Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255))
        };

        public static ChatMessage SystemMessage(string text) => new ChatMessage
        {
            Text = text,
            HorizontalAlignment = HorizontalAlignment.Center,
            Background = new SolidColorBrush(Color.FromRgb(30, 30, 50)),
            Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 255))
        };
    }
}
