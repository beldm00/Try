using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryGame
{
    public class SoundManager
    {
        private static SoundManager _instance;
        public static SoundManager getInstance()
        {
            if (_instance == null)
                _instance = new SoundManager();
            return _instance;
        }
        System.Media.SoundPlayer sp;
        private SoundManager()
        {            
            //REVIEW: Название файла - в настройки
            soundName = "backgroundSound.wav";
        }
        string soundName;
        public void Play()
        {
            sp = new System.Media.SoundPlayer(soundName);
            sp.PlayLooping();
            
        }

        public void Close()
        {
            sp.Stop();
            sp.Dispose();
        }
    }
}
