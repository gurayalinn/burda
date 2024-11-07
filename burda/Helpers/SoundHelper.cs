using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace burda.Helpers
{
    public class SoundHelper
    {
        public static UnmanagedMemoryStream beep = Properties.Resources.beep;

        public static void PlaySound(UnmanagedMemoryStream sound)
        {
            using (SoundPlayer player = new SoundPlayer(sound))
            {
                player.Play();
            }
        }



        public static void PlayBeep()
        {
            PlaySound(beep);
        }

    }
}
