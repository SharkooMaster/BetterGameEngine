using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Audio
{
    public class AudioTrack : MediaPlayer
    {
        public int id;

        private Uri audioPath;
        public string Audio
        {
            get { return audioPath.LocalPath; }
            set { audioPath = new Uri(value, UriKind.Absolute); }
        }

        public int volume
        {
            get { return Convert.ToInt32(Volume); }
            set
            {
                bool valid = (value <= 100 && value >= 0);
                Volume = valid ? value/100 : Volume;
            }
        }

        public bool mute
        {
            get { return mute; }
            set
            {
                IsMuted = value;
                mute = value;
            }
        }

        public AudioTrack(string _path)
        {
            Audio = _path;
            Open(audioPath);
        }
    }
}
