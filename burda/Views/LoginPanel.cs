using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace burda.Views
{
    public partial class LoginPanel : BasePanel
    {
        public LoginPanel()
    {
        InitializeComponent();
    }
    private void LoginPanel_Load(object sender, EventArgs e)
    {
    }

        private void button_beep_Click(object sender, EventArgs e)
        {
            BasePanel form = new AdminPanel();
            form.Show();
        }
    }
}