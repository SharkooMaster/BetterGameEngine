using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Audio
{
    public class AudioBoard
    {
        public int id;
        public List<AudioTrack> tracks = new List<AudioTrack>();

        public void setVolume(int volume)
        {
            foreach (AudioTrack track in tracks)
            {
                track.volume = volume;
            }
        }

        public void PLAY()
        {
            foreach(AudioTrack track in tracks)
            {
                track.Play();
            }
        }

        public void PAUSE()
        {
            foreach (AudioTrack track in tracks)
            {
                track.Pause();
            }
        }

        public void RESTART()
        {
            foreach( AudioTrack track in tracks)
            {
                track.Stop();
            }
            PLAY();
        }
    }
}
