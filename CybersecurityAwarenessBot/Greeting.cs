using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using static System.Console;

namespace CybersecurityAwarenessBot
{
    internal class Greeting
    {
        public static void PlayVoiceGreeting()
        {
            // This builds the path relative to wherever the program is running from
            // It will work on any computer as long as the WAV file is in the project
            string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

            SoundPlayer player = new SoundPlayer(audioPath);
            player.Load();
            player.PlaySync();
        }
    }
}


