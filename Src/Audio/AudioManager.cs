using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Audio
{
    public static class AudioManager
    {
        public static List<AudioBoard> audioBoards = new List<AudioBoard>();
        public static int activeAudioBoard = -1;
    }
}
