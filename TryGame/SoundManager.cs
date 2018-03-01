using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

            soundName =File.Exists(ConfigurationSettings.AppSettings["SoundFileName"]) ? ConfigurationSettings.AppSettings["SoundFileName"] : null;
        }
        string soundName;
        public void Play()
       {if (soundName!=null){
            sp = new System.Media.SoundPlayer(soundName);
            sp.PlayLooping();
        }
        }

        public void Close()
        {
            if (soundName != null)
            {
                sp.Stop();
                sp.Dispose();
            }
        }
    }
}
