using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;


namespace burda.Helpers
{
    public class TextToSpeechHelper
    {
        public static void ReadName(string name)
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                synthesizer.Rate = -2;
                synthesizer.Volume = 100;
                synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);

                synthesizer.Speak($"{name}");
            }
        }
    }
}
