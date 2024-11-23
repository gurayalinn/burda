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
using burda.Views;


namespace burda
{

    public partial class Burda : Form
    {
        private Timer syncTimer;
        private bool isSyncing = false;

        public Burda()
        {
            InitializeComponent();
        }

        private void Burda_Load(object sender, EventArgs e)
        {

            Logger.Information("Views: Burda loaded.");

            syncTimer = new Timer();
            syncTimer.Interval = 1000;
            syncTimer.Tick += async (s, args) => await Program.SyncGist();
            syncTimer.Start();

        }

        private void button_beep_Click(object sender, EventArgs e)
        {

            SoundHelper.PlayBeep();
            TextToSpeechHelper.ReadName("BURADA!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BasePanel form = new LoginPanel();
            form.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BasePanel form = new HelpDeskPanel();
            form.Show();
        }

        private void Burda_Load_1(object sender, EventArgs e)
        {

        }
    }
}
