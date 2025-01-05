namespace burda.Views
{
    partial class ClassListForm
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
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewClassList = new System.Windows.Forms.DataGridView();
            this.comboBoxClassrooms = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassList)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cascadia Mono", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Bisque;
            this.label11.Location = new System.Drawing.Point(27, 10);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 22);
            this.label11.TabIndex = 24;
            this.label11.Text = "Sınıf:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewClassList
            // 
            this.dataGridViewClassList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassList.Location = new System.Drawing.Point(31, 73);
            this.dataGridViewClassList.Name = "dataGridViewClassList";
            this.dataGridViewClassList.RowHeadersWidth = 51;
            this.dataGridViewClassList.RowTemplate.Height = 24;
            this.dataGridViewClassList.Size = new System.Drawing.Size(738, 253);
            this.dataGridViewClassList.TabIndex = 26;
            // 
            // comboBoxClassrooms
            // 
            this.comboBoxClassrooms.BackColor = System.Drawing.Color.LightSlateGray;
            this.comboBoxClassrooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxClassrooms.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxClassrooms.ForeColor = System.Drawing.Color.Lime;
            this.comboBoxClassrooms.FormattingEnabled = true;
            this.comboBoxClassrooms.Location = new System.Drawing.Point(31, 36);
            this.comboBoxClassrooms.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxClassrooms.Name = "comboBoxClassrooms";
            this.comboBoxClassrooms.Size = new System.Drawing.Size(249, 30);
            this.comboBoxClassrooms.TabIndex = 27;
            this.comboBoxClassrooms.SelectedIndexChanged += new System.EventHandler(this.comboBoxClassrooms_SelectedIndexChanged);
            // 
            // ClassListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 450);
            this.Controls.Add(this.comboBoxClassrooms);
            this.Controls.Add(this.dataGridViewClassList);
            this.Controls.Add(this.label11);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Name = "ClassListForm";
            this.Text = "YOKLAMA LİSTESİ";
            this.Load += new System.EventHandler(this.ClassListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewClassList;
        private System.Windows.Forms.ComboBox comboBoxClassrooms;
    }
}