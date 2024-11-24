using System;
using System.Drawing;
using System.Windows.Forms;

namespace burda.Views
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            InitializeBasePanel();

        }

        private void InitializeBasePanel()
        {
            this.Text = "BURDA: YOKLAMA TAKİP";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = Icon.FromHandle(Properties.Resources.clock.GetHicon());
            this.Font = new Font("Cascadia Mono", 10);
            this.MaximizeBox = false;
            this.BackColor = Color.LightSlateGray;
            this.ForeColor = Color.Bisque;
            this.WindowState = FormWindowState.Normal;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.Padding = new Padding(10);
            this.MaximizeBox = false;
        }


        public void OpenForm(Form childForm)
        {
            this.Controls.Clear();
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            childForm.Show();
        }

        public void CloseForm(Form childForm)
        {
            this.Controls.Remove(childForm);
        }

        private void BasePanel_Load(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
