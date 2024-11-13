namespace burda.Views
{
    partial class LoginPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginPanel = new System.Windows.Forms.Panel();
            this.errorLbl = new System.Windows.Forms.Label();
            this.passwordTxtBx = new System.Windows.Forms.TextBox();
            this.usernameTxtBx = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.loginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginPanel.Controls.Add(this.errorLbl);
            this.loginPanel.Controls.Add(this.passwordTxtBx);
            this.loginPanel.Controls.Add(this.usernameTxtBx);
            this.loginPanel.Controls.Add(this.loginBtn);
            this.loginPanel.Controls.Add(this.logoutBtn);
            this.loginPanel.Controls.Add(this.passwordLbl);
            this.loginPanel.Controls.Add(this.userNameLbl);
            this.loginPanel.Location = new System.Drawing.Point(225, 112);
            this.loginPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(629, 300);
            this.loginPanel.TabIndex = 0;
            // 
            // errorLbl
            // 
            this.errorLbl.AutoSize = true;
            this.errorLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLbl.Location = new System.Drawing.Point(255, 171);
            this.errorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(186, 16);
            this.errorLbl.TabIndex = 6;
            this.errorLbl.Text = "Kullanıcı Adı veya Şifre Hatalı !";
            // 
            // passwordTxtBx
            // 
            this.passwordTxtBx.BackColor = System.Drawing.Color.SlateGray;
            this.passwordTxtBx.Location = new System.Drawing.Point(259, 128);
            this.passwordTxtBx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordTxtBx.Name = "passwordTxtBx";
            this.passwordTxtBx.Size = new System.Drawing.Size(179, 22);
            this.passwordTxtBx.TabIndex = 5;
            // 
            // usernameTxtBx
            // 
            this.usernameTxtBx.BackColor = System.Drawing.Color.SlateGray;
            this.usernameTxtBx.Location = new System.Drawing.Point(259, 89);
            this.usernameTxtBx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usernameTxtBx.Name = "usernameTxtBx";
            this.usernameTxtBx.Size = new System.Drawing.Size(179, 22);
            this.usernameTxtBx.TabIndex = 4;
            this.usernameTxtBx.TextChanged += new System.EventHandler(this.usernameTxtBx_TextChanged);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.SlateGray;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginBtn.Location = new System.Drawing.Point(305, 206);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(179, 28);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Giriş Yap";
            this.loginBtn.UseVisualStyleBackColor = false;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.SlateGray;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.logoutBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logoutBtn.Location = new System.Drawing.Point(147, 206);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(151, 28);
            this.logoutBtn.TabIndex = 2;
            this.logoutBtn.Text = "Çıkış";
            this.logoutBtn.UseVisualStyleBackColor = false;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.passwordLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.passwordLbl.Location = new System.Drawing.Point(205, 132);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(52, 17);
            this.passwordLbl.TabIndex = 1;
            this.passwordLbl.Text = "Şifre :";
            // 
            // userNameLbl
            // 
            this.userNameLbl.AccessibleDescription = "";
            this.userNameLbl.AccessibleName = "";
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.userNameLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userNameLbl.Location = new System.Drawing.Point(147, 92);
            this.userNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(107, 17);
            this.userNameLbl.TabIndex = 0;
            this.userNameLbl.Text = "Kullanıcı Adı :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(327, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "BURDA YOKLAMA TAKİP SİSTEMİ";
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginPage";
            this.Text = "LoginPage";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.TextBox passwordTxtBx;
        private System.Windows.Forms.TextBox usernameTxtBx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label errorLbl;
    }
}