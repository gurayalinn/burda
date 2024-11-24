using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using burda.Models;
using burda.Controllers;


namespace burda.Views
{
    public partial class LoginForm : BaseForm
    {
        public static User loggedUser;

        public LoginForm()
        {
            if (loggedUser != null)
            {
                BaseForm form = new ManagementForm(loggedUser);
                form.Show();
            }
            InitializeComponent();
        }



        private void LoginPanel_Load(object sender, EventArgs e)
        {
            burda.Properties.Settings.Default.Reload();
            buttonLogin.Enabled = false;
            textBoxEmail.Focus();

        }


        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            buttonClose.PerformClick();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (email == "" || password == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }
            else
            {
                UserController userController = new UserController();
                User user = userController.Login(email, password);
                if (user != null)
                {
                    loggedUser = user;
                    ManagementForm form = new ManagementForm(loggedUser);
                    form.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                }
            }
        }


        private void pictureBoxLogin_Click(object sender, EventArgs e)
        {
            buttonLogin.PerformClick();
        }

        private void buttonForget_Click(object sender, EventArgs e)
        {
            HelpDeskForm form = new HelpDeskForm();
            form.Show();
        }

        private void pictureBoxForget_Click(object sender, EventArgs e)
        {
            buttonForget.PerformClick();
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && textBoxPassword.Text != "")
            {
                buttonLogin.Enabled = true;
            }
            else
            {
                buttonLogin.Enabled = false;
            }

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && textBoxPassword.Text != "")
            {
                buttonLogin.Enabled = true;
            }
            else
            {
                buttonLogin.Enabled = false;
            }

        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxAdmin_Click(object sender, EventArgs e)
        {
            textBoxEmail.Text = burda.Properties.Settings.Default.AdminEmail;
            textBoxPassword.Text = burda.Properties.Settings.Default.AdminPassword;
            buttonLogin.PerformClick();

        }
    }
}