using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using burda.Helpers;
using burda.Models;

namespace burda
{
    public partial class Burda : Form
    {
        private Timer syncTimer;

        public Burda()
        {
            InitializeComponent();
            this.Shown += Burda_Shown;
        }

        private void Burda_Load(object sender, EventArgs e)
        {

        }

        private void button_beep_Click(object sender, EventArgs e)
        {
            SoundHelper.PlaySound(SoundHelper.beep);
            TextToSpeechHelper.ReadName("BURDA!");
            SoundHelper.PlayBeep();
        }

        private void Burda_Shown(object sender, EventArgs e)
        {
            syncTimer = new Timer
            {
                Interval = 60000 // 1 dakika
            };

            syncTimer.Tick += async (s, args) => await Program.SyncGist();
            syncTimer.Start();
        }

    }
}
