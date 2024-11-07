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

namespace burda
{
    public partial class Burda : Form
    {
        public Burda()
        {
            InitializeComponent();
        }

        private void button_beep_Click(object sender, EventArgs e)
        {
            SoundHelper.PlayBeep();
        }
    }
}
