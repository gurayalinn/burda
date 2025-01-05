using burda.Controllers;
using burda.Helpers;
using burda.Models;
using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace burda.Views

{
    public partial class AddForm : BaseForm
        {

       public static String SelectedSource;
        private UserController userController;
        private ClassRoomController classRoomController;
        private CardController cardController;
        private RoleController roleController;


        public AddForm(String selectedSource)
        {
            AddForm.SelectedSource = selectedSource;

            if (SelectedSource != null && SelectedSource.Length > 0) {
            switch (selectedSource)
            {
                case "Users":
                        roleController = new RoleController();
                        userController = new UserController();
                        cardController = new CardController();
                        break;
                case "Students":
                        roleController = new RoleController();
                        userController = new UserController();
                        cardController = new CardController();
                        break;
                case "Classrooms":
                        userController = new UserController();
                        classRoomController = new ClassRoomController();
                    break;
                case "Cards":
                        cardController = new CardController();
                        break;
                default:
                    break;
            }
            }
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

            switch (SelectedSource)
            {
                case "Users":
                case "Students":

                    Label lblRFIDCard = new Label();
                    lblRFIDCard.Text = "RFID Card";
                    lblRFIDCard.Location = new Point(10, 10);
                    lblRFIDCard.AutoSize = true;

                    ComboBox cmbCard = new ComboBox();
                    cmbCard.Location = new Point(10, 30);
                    cmbCard.Size = new Size(200, 20);
                    cmbCard.TabIndex = 0;
                    cmbCard.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbCard.DataSource = cardController.GetAll();
                    cmbCard.DisplayMember = "RFIDNumber";
                    cmbCard.ValueMember = "ID";

                    Label lblStudentId = new Label();
                    lblStudentId.Text = "Student ID";
                    lblStudentId.Location = new Point(10, 50);
                    lblStudentId.AutoSize = true;

                    TextBox txtStudentId = new TextBox();
                    txtStudentId.Location = new Point(10, 80);
                    txtStudentId.Size = new Size(200, 20);
                    txtStudentId.TabIndex = 1;


                    Label lblName = new Label();
                    lblName.Text = "FirstName";
                    lblName.Location = new Point(10, 110);
                    lblName.AutoSize = true;

                    TextBox txtName = new TextBox();
                    txtName.Location = new Point(10, 130);
                    txtName.Size = new Size(200, 20);
                    txtName.TabIndex = 2;

                    Label lblSurname = new Label();
                    lblSurname.Text = "Surname";
                    lblSurname.Location = new Point(10, 160);
                    lblSurname.AutoSize = true;
                    TextBox txtSurname = new TextBox();
                    txtSurname.Location = new Point(10, 180);
                    txtSurname.Size = new Size(200, 20);
                    txtSurname.TabIndex = 3;

                    Label lblEmail = new Label();
                    lblEmail.Text = "Email";
                    lblEmail.Location = new Point(10, 210);
                    lblEmail.AutoSize = true;
                    TextBox txtEmail = new TextBox();
                    txtEmail.Location = new Point(10, 230);
                    txtEmail.Size = new Size(200, 20);
                    txtEmail.TabIndex = 4;
                    txtEmail.Validated += (s, ev) =>
                    {
                        if (!ValidationHelper.IsEmailValid(txtEmail.Text))
                        {
                            MessageBox.Show("Geçerli bir email adresi giriniz.");
                            txtEmail.Focus();
                        }
                    };

                    Label lblPassword = new Label();
                    lblPassword.Text = "Password";
                    lblPassword.Location = new Point(10, 260);
                    lblPassword.AutoSize = true;

                    TextBox txtPassword = new TextBox();
                    txtPassword.Location = new Point(10, 280);
                    txtPassword.Size = new Size(200, 20);
                    txtPassword.TabIndex = 5;
                    txtPassword.UseSystemPasswordChar = true;


                    Label lblRole = new Label();
                    lblRole.Text = "Role";
                    lblRole.Location = new Point(10, 310);
                    lblRole.AutoSize = true;

                    ComboBox cmbRole = new ComboBox();
                    cmbRole.Location = new Point(10, 330);
                    cmbRole.Size = new Size(200, 20);
                    cmbRole.TabIndex = 6;
                    cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbRole.DataSource = roleController.GetAll();
                    cmbRole.DisplayMember = "RoleName";
                    cmbRole.ValueMember = "ID";

                    Button btnSave = new Button();
                    btnSave.Text = "Save";
                    btnSave.Location = new Point(10, 360);
                    btnSave.Size = new Size(200, 30);
                    btnSave.TabIndex = 7;
                    btnSave.BackColor = Color.DarkGreen;
                    btnSave.ForeColor = Color.Bisque;

                    this.Controls.Add(lblRFIDCard);
                    this.Controls.Add(cmbCard);
                    this.Controls.Add(lblStudentId);
                    this.Controls.Add(txtStudentId);
                    this.Controls.Add(lblName);
                    this.Controls.Add(txtName);
                    this.Controls.Add(lblSurname);
                    this.Controls.Add(txtSurname);
                    this.Controls.Add(lblEmail);
                    this.Controls.Add(txtEmail);
                    this.Controls.Add(lblPassword);
                    this.Controls.Add(txtPassword);
                    this.Controls.Add(lblRole);
                    this.Controls.Add(cmbRole);
                    this.Controls.Add(btnSave);

                    if (SelectedSource == "Students")
                    {

                        txtStudentId.TextChanged += (s, ev) =>
                        {
                            txtEmail.Text = txtStudentId.Text + "@ogr.uludag.edu.tr";
                            int random = new Random().Next(6, 12);
                            String hash = Guid.NewGuid().ToString().Substring(0, random);
                            String password = hash + txtStudentId.Text;
                            txtPassword.Text = password;
                        };

                        cmbRole.SelectedIndex = 2;
                        cmbRole.Enabled = false;
                        txtEmail.Enabled = false;
                        txtPassword.Enabled = false;

                    }


                    txtStudentId.KeyPress += (s, ev) =>
                    {
                        if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar))
                        {
                            ev.Handled = true;
                        }

                        if (txtStudentId.Text.Length > 9)
                        {
                            ev.Handled = true;
                        }

                    };

                    txtName.KeyPress += (s, ev) =>
                    {
                        if (!char.IsControl(ev.KeyChar) && !char.IsLetter(ev.KeyChar) && !char.IsWhiteSpace(ev.KeyChar))
                        {
                            ev.Handled = true;
                        }

                        if (txtName.Text.Length > 50)
                        {
                            ev.Handled = true;
                        }

                    };

                    txtSurname.KeyPress += (s, ev) =>
                    {
                        if (!char.IsControl(ev.KeyChar) && !char.IsLetter(ev.KeyChar) && !char.IsWhiteSpace(ev.KeyChar))
                        {
                            ev.Handled = true;
                        }

                        if (txtSurname.Text.Length > 50)
                        {
                            ev.Handled = true;
                        }
                    };

                    txtEmail.KeyPress += (s, ev) =>
                    {
                        if (!char.IsControl(ev.KeyChar) && !char.IsLetterOrDigit(ev.KeyChar) && !char.IsPunctuation(ev.KeyChar))
                        {
                            ev.Handled = true;
                        }

                    };

                    txtPassword.KeyPress += (s, ev) =>
                    {
                        if (!char.IsControl(ev.KeyChar) && !char.IsLetterOrDigit(ev.KeyChar) && !char.IsPunctuation(ev.KeyChar))
                        {
                            ev.Handled = true;
                        }

                    };


                    btnSave.Enabled = false;

                    txtStudentId.TextChanged += (s, ev) =>
                    {
                        btnSave.Enabled = txtStudentId.Text.Length > 3 && txtName.Text.Length > 3 && txtSurname.Text.Length > 3 && txtEmail.Text.Length > 3 && txtPassword.Text.Length > 3;
                    };

                    txtName.TextChanged += (s, ev) =>
                    {
                        btnSave.Enabled = txtStudentId.Text.Length > 3 && txtName.Text.Length > 3 && txtSurname.Text.Length > 3 && txtEmail.Text.Length > 3 && txtPassword.Text.Length > 3;
                    };

                    txtSurname.TextChanged += (s, ev) =>
                    {
                        btnSave.Enabled = txtStudentId.Text.Length > 3 && txtName.Text.Length > 3 && txtSurname.Text.Length > 3 && txtEmail.Text.Length > 3 && txtPassword.Text.Length > 3;
                    };

                    txtEmail.TextChanged += (s, ev) =>
                    {
                        btnSave.Enabled = txtStudentId.Text.Length > 3 && txtName.Text.Length > 3 && txtSurname.Text.Length > 3 && txtEmail.Text.Length > 3 && txtPassword.Text.Length > 3;
                    };

                    txtPassword.TextChanged += (s, ev) =>
                    {
                        btnSave.Enabled = txtStudentId.Text.Length > 3 && txtName.Text.Length > 3 && txtSurname.Text.Length > 3 && txtEmail.Text.Length > 3 && txtPassword.Text.Length > 3;
                    };

                    btnSave.Click += (s, ev) =>
                    {

                        User newUser = new User
                        {
                            StudentID = txtStudentId.Text,
                            Email = txtEmail.Text,
                            Password = txtPassword.Text,
                            FirstName = txtName.Text,
                            LastName = txtSurname.Text,
                            RoleID = (int)cmbRole.SelectedValue,
                            RFIDCardID = (long)cmbCard.SelectedValue,
                            ProfileImage = "",
                            ProgramName = "Bilgisayar Programcılığı"
                        };


                        bool isSuccess = userController.AddUser(newUser);
                        MessageBox.Show(isSuccess ? "Kullanıcı başarıyla eklendi. " + newUser.FullName : "Kullanıcı eklenirken bir hata oluştu.");
                        this.Close();
                    };



                    break;
                case "Classrooms":
                    
                    Label lblTeacher = new Label();
                    lblTeacher.Text = "Teacher";
                    lblTeacher.Location = new Point(10, 10);
                    lblTeacher.AutoSize = true;

                    ComboBox cmbTeacher = new ComboBox();
                    cmbTeacher.Location = new Point(10, 30);
                    cmbTeacher.Size = new Size(200, 20);
                    cmbTeacher.TabIndex = 0;
                    cmbTeacher.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbTeacher.DataSource = userController.GetAllTeachers();
                    cmbTeacher.DisplayMember = "FullName";
                    cmbTeacher.ValueMember = "ID";

                    Label lblClassName = new Label();
                    lblClassName.Text = "Class Name";
                    lblClassName.Location = new Point(10, 50);
                    lblClassName.AutoSize = true;

                    TextBox txtClassName = new TextBox();
                    txtClassName.Location = new Point(10, 80);
                    txtClassName.Size = new Size(200, 20);
                    txtClassName.TabIndex = 1;

                    Label lblLessonName = new Label();
                    lblLessonName.Text = "Lesson Name";
                    lblLessonName.Location = new Point(10, 110);
                    lblLessonName.AutoSize = true;

                    TextBox txtLessonName = new TextBox();
                    txtLessonName.Location = new Point(10, 130);
                    txtLessonName.Size = new Size(200, 20);
                    txtLessonName.TabIndex = 2;


                    Label lblClassDate = new Label();
                    lblClassDate.Text = "Class Date";
                    lblClassDate.Location = new Point(10, 160);
                    lblClassDate.AutoSize = true;
                    
                    DateTimePicker dtpClassDate = new DateTimePicker();
                    dtpClassDate.Location = new Point(10, 180);
                    dtpClassDate.Size = new Size(200, 20);
                    dtpClassDate.TabIndex = 3;
                    dtpClassDate.Value = DateTime.Today;

                    Label lblStartTime = new Label();
                    lblStartTime.Text = "Start Time";
                    lblStartTime.Location = new Point(10, 210);
                    lblStartTime.AutoSize = true;

                    DateTimePicker dtpStartTime = new DateTimePicker();
                    dtpStartTime.Location = new Point(10, 230);
                    dtpStartTime.Size = new Size(200, 20);
                    dtpStartTime.TabIndex = 4;
                    dtpStartTime.Format = DateTimePickerFormat.Time;
                    dtpStartTime.ShowUpDown = true;
                    dtpStartTime.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);

                    Label lblEndTime = new Label();
                    lblEndTime.Text = "End Time";
                    lblEndTime.Location = new Point(10, 260);
                    lblEndTime.AutoSize = true;
                    DateTimePicker dtpEndTime = new DateTimePicker();
                    dtpEndTime.Location = new Point(10, 280);
                    dtpEndTime.Size = new Size(200, 20);
                    dtpEndTime.TabIndex = 5;
                    dtpEndTime.Format = DateTimePickerFormat.Time;
                    dtpEndTime.ShowUpDown = true;
                    dtpEndTime.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 0, 0);

                    Label lblIsExam = new Label();
                    lblIsExam.Text = "Is Exam";
                    lblIsExam.Location = new Point(10, 310);
                    lblIsExam.AutoSize = true;

                    CheckBox chkIsExam = new CheckBox();
                    chkIsExam.Location = new Point(10, 330);
                    chkIsExam.Size = new Size(200, 20);
                    chkIsExam.TabIndex = 6;

                    Button btnSaveClassRoom = new Button();
                    btnSaveClassRoom.Text = "Save";
                    btnSaveClassRoom.Location = new Point(10, 360);
                    btnSaveClassRoom.Size = new Size(200, 30);
                    btnSaveClassRoom.TabIndex = 7;
                    btnSaveClassRoom.BackColor = Color.DarkGreen;
                    btnSaveClassRoom.ForeColor = Color.Bisque;


                    this.Controls.Add(lblTeacher);
                    this.Controls.Add(cmbTeacher);
                    this.Controls.Add(lblClassName);
                    this.Controls.Add(txtClassName);
                    this.Controls.Add(lblLessonName);
                    this.Controls.Add(txtLessonName);
                    this.Controls.Add(lblClassDate);
                    this.Controls.Add(dtpClassDate);
                    this.Controls.Add(lblStartTime);
                    this.Controls.Add(dtpStartTime);
                    this.Controls.Add(lblEndTime);
                    this.Controls.Add(dtpEndTime);
                    this.Controls.Add(lblIsExam);
                    this.Controls.Add(chkIsExam);
                    this.Controls.Add(btnSaveClassRoom);

                    btnSaveClassRoom.Enabled = false;

                    txtClassName.TextChanged += (s, ev) =>
                    {
                        btnSaveClassRoom.Enabled = txtClassName.Text.Length > 3 && txtLessonName.Text.Length > 3;
                    };

                    txtLessonName.TextChanged += (s, ev) =>
                    {
                        btnSaveClassRoom.Enabled = txtClassName.Text.Length > 3 && txtLessonName.Text.Length > 3;
                    };

                    btnSaveClassRoom.Click += (s, ev) =>
                    {
                        User Teacher = (User)cmbTeacher.SelectedItem;
                        String ClassName = txtClassName.Text;
                        String LessonName = txtLessonName.Text;
                        DateTime ClassDate = dtpClassDate.Value;
                        TimeSpan StartTime = dtpStartTime.Value.TimeOfDay;
                        TimeSpan EndTime = dtpEndTime.Value.TimeOfDay;
                        bool IsExam = chkIsExam.Checked;
                        ClassRoom newClassRoom = new ClassRoom
                        {
                            TeacherID = Teacher.ID,
                            ClassName = ClassName,
                            LessonName = LessonName,
                            ClassDate = ClassDate,
                            StartTime = StartTime,
                            EndTime = EndTime,
                            IsExam = IsExam
                        };
                        bool isSuccess = classRoomController.AddClassRoom(newClassRoom);
                        MessageBox.Show(isSuccess ? "Sınıf başarıyla eklendi. " + newClassRoom.ClassName : "Sınıf eklenirken bir hata oluştu.");
                        this.Close();
                    };



                    break;
                case "Cards":

                    Label lblRFIDNumber = new Label();
                    lblRFIDNumber.Text = "RFID Number";
                    lblRFIDNumber.Location = new Point(10, 10);
                    lblRFIDNumber.AutoSize = true;


                    TextBox txtRFIDNumber = new TextBox();
                    txtRFIDNumber.Location = new Point(10, 30);
                    txtRFIDNumber.Size = new Size(200, 20);
                    txtRFIDNumber.TabIndex = 0;


                    Label lblRawData = new Label();
                    lblRawData.Text = "Raw Data";
                    lblRawData.Location = new Point(10, 60);
                    lblRawData.AutoSize = true;

                    TextBox txtRawData = new TextBox();
                    txtRawData.Location = new Point(10, 80);
                    txtRawData.Size = new Size(200, 20);
                    txtRawData.TabIndex = 1;
                    lblRawData.AutoSize = true;


                    Button btnSaveCard = new Button();
                    btnSaveCard.Text = "Save";
                    btnSaveCard.Location = new Point(10, 120);
                    btnSaveCard.Size = new Size(200, 30);
                    btnSaveCard.TabIndex = 1;
                    btnSaveCard.BackColor = Color.DarkGreen;
                    btnSaveCard.ForeColor = Color.Bisque;

                    this.Controls.Add(lblRFIDNumber);
                    this.Controls.Add(txtRFIDNumber);
                    this.Controls.Add(btnSaveCard);
                    this.Controls.Add(lblRawData);
                    this.Controls.Add(txtRawData);


                    this.ResumeLayout(false);
                    btnSaveCard.Enabled = false;

                    txtRFIDNumber.TextChanged += (s, ev) =>
                    {
                        btnSaveCard.Enabled = txtRFIDNumber.Text.Length > 3;
                    };

                    btnSaveCard.Click += (s, ev) =>
                    {
                        RFIDCard newCard = new RFIDCard
                        {
                            RFIDNumber = txtRFIDNumber.Text,
                            RawData = txtRawData.Text
                        };
                        bool isSuccess = cardController.AddCard(newCard);
                        MessageBox.Show(isSuccess ? "RFID Card başarıyla eklendi. " + newCard.RFIDNumber : "RFID Card eklenirken bir hata oluştu.");
                        this.Close();
                    };

                    break;
                default:
                    break;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}