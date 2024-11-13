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
            try
            {
                sound.Position = 0;
                using (SoundPlayer player = new SoundPlayer())
                {
                    player.Stream = sound;
                    player.Play();
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error playing sound: " + ex.Message);
            }
        }

        public static void PlayBeep()
        {
            PlaySound(beep);
        }
    }

}
