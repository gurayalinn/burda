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
    private void HelpDeskPanel_Load(object sender, EventArgs e)
    {

            buttonSend.Enabled = false;
            textBoxEmail.Text = "";
            richTextBoxMessage.Text = "";
            textBoxEmail.Focus();
    }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string message = richTextBoxMessage.Text;
            if (email == "" || message == "")
            {
                MessageBox.Show("Lütfen e-posta adresinizi ve mesajınızı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Mesajınız başarıyla gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxEmail.Text = "";
            richTextBoxMessage.Text = "";
            textBoxEmail.Focus();
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