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
using Serilog.Sinks.Seq;


namespace burda
{

    public partial class Burda : Form
    {
        private Timer syncTimer;
        public Serilog.Core.Logger logger;

        public Burda()
        {
            InitializeComponent();
        }

        private void Burda_Load(object sender, EventArgs e)
        {


        }

        private void button_beep_Click(object sender, EventArgs e)
        {

            SoundHelper.PlayBeep();
            TextToSpeechHelper.ReadName("BURADA!");
        }

        private void Burda_Shown(object sender, EventArgs e)
        {
            syncTimer = new Timer
            {
                Interval = 60000 // 1 dakika
            };

            //syncTimer.Tick += async (s, args) => await Program.SyncGist();
            
            syncTimer.Start();
        }

    }
}
