namespace burda.Views
{
    partial class HelpDeskForm
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
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxTbmyo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTbmyo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.richTextBoxMessage.Location = new System.Drawing.Point(15, 150);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(300, 200);
            this.richTextBoxMessage.TabIndex = 4;
            this.richTextBoxMessage.Text = "";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Cascadia Mono", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.Color.Bisque;
            this.labelEmail.Location = new System.Drawing.Point(15, 75);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(64, 18);
            this.labelEmail.TabIndex = 1;
            this.labelEmail.Text = "E-mail:";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxEmail.Location = new System.Drawing.Point(5, 89);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(300, 23);
            this.textBoxEmail.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.LightSlateGray;
            this.labelTitle.Font = new System.Drawing.Font("Cascadia Mono", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelTitle.Location = new System.Drawing.Point(115, 25);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(91, 29);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "DESTEK";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonSend.Enabled = false;
            this.buttonSend.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.ForeColor = System.Drawing.Color.Beige;
            this.buttonSend.Location = new System.Drawing.Point(15, 365);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(200, 40);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Gönder";
            this.buttonSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Cascadia Mono", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.ForeColor = System.Drawing.Color.Bisque;
            this.labelMessage.Location = new System.Drawing.Point(15, 125);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(144, 18);
            this.labelMessage.TabIndex = 3;
            this.labelMessage.Text = "Mesajınızı girin:";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBoxClose.Image = global::burda.Properties.Resources.exit;
            this.pictureBoxClose.Location = new System.Drawing.Point(250, 357);
            this.pictureBoxClose.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(50, 35);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 58;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.DarkRed;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Cascadia Mono", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Bisque;
            this.buttonClose.Location = new System.Drawing.Point(245, 355);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(60, 40);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::burda.Properties.Resources.clock;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 59;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBoxTbmyo
            // 
            this.pictureBoxTbmyo.Image = global::burda.Properties.Resources.tbmyo;
            this.pictureBoxTbmyo.Location = new System.Drawing.Point(255, 0);
            this.pictureBoxTbmyo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxTbmyo.Name = "pictureBoxTbmyo";
            this.pictureBoxTbmyo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxTbmyo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTbmyo.TabIndex = 60;
            this.pictureBoxTbmyo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxClose);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.pictureBoxLogo);
            this.panel1.Controls.Add(this.pictureBoxTbmyo);
            this.panel1.Controls.Add(this.textBoxEmail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 414);
            this.panel1.TabIndex = 61;
            // 
            // HelpDeskForm
            // 
            this.AcceptButton = this.buttonSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(334, 436);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HelpDeskForm";
            this.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.Text = "BURDA: DESTEK";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTbmyo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxTbmyo;
        private System.Windows.Forms.Panel panel1;
    }
}