using burda.Helpers;
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
    public partial class HelpDeskForm : BaseForm
    {
        public HelpDeskForm()
    {
        InitializeComponent();
    }
    private async Task HelpDeskPanel_LoadAsync(object sender, EventArgs e)
    {

            buttonSend.Enabled = false;
            textBoxEmail.Text = "";
            richTextBoxMessage.Text = "";
            textBoxEmail.Focus();
            await Logger.Information("Views: HelpDeskPanel loaded.");
    }


        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && richTextBoxMessage.Text != "")
            {
                buttonSend.Enabled = true;
            }
            else
            {
                buttonSend.Enabled = false;
            }

        }

        private void richTextBoxMessage_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && richTextBoxMessage.Text != "")
            {
                buttonSend.Enabled = true;
            }
            else
            {
                buttonSend.Enabled = false;
            }

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            buttonClose.PerformClick();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}