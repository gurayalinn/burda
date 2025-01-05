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
    public partial class EditForm : BaseForm
    {

        public static String SelectedSource;
        public static int SelectedID;
        private UserController userController;
        private ClassRoomController classRoomController;
        private CardController cardController;
        private RoleController roleController;


        public EditForm(String selectedSource, int SelectedID)
        {
            EditForm.SelectedSource = selectedSource;
            EditForm.SelectedID = SelectedID;

            if (SelectedSource != null && SelectedSource.Length > 0 && SelectedID > 0)
            {
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

        private void EditForm_Load(object sender, EventArgs e)
        {

            switch (SelectedSource)
            {
                case "Users":
                case "Students":

                    User user = userController.GetById(SelectedID);

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
                    cmbCard.SelectedItem = user.RFIDCard;

                    Label lblStudentId = new Label();
                    lblStudentId.Text = "Student ID";
                    lblStudentId.Location = new Point(10, 50);
                    lblStudentId.AutoSize = true;

                    TextBox txtStudentId = new TextBox();
                    txtStudentId.Location = new Point(10, 80);
                    txtStudentId.Size = new Size(200, 20);
                    txtStudentId.TabIndex = 1;
                    txtStudentId.Text = user.StudentID;


                    Label lblName = new Label();
                    lblName.Text = "FirstName";
                    lblName.Location = new Point(10, 110);
                    lblName.AutoSize = true;

                    TextBox txtName = new TextBox();
                    txtName.Location = new Point(10, 130);
                    txtName.Size = new Size(200, 20);
                    txtName.TabIndex = 2;
                    txtName.Text = user.FirstName;

                    Label lblSurname = new Label();
                    lblSurname.Text = "Surname";
                    lblSurname.Location = new Point(10, 160);
                    lblSurname.AutoSize = true;

                    TextBox txtSurname = new TextBox();
                    txtSurname.Location = new Point(10, 180);
                    txtSurname.Size = new Size(200, 20);
                    txtSurname.TabIndex = 3;
                    txtSurname.Text = user.LastName;

                    Label lblEmail = new Label();
                    lblEmail.Text = "Email";
                    lblEmail.Location = new Point(10, 210);
                    lblEmail.AutoSize = true;

                    TextBox txtEmail = new TextBox();
                    txtEmail.Location = new Point(10, 230);
                    txtEmail.Size = new Size(200, 20);
                    txtEmail.TabIndex = 4;
                    txtEmail.Text = user.Email;
                    txtEmail.Validating += (s, ev) =>
                    {
                        if (!ValidationHelper.IsEmailValid(txtEmail.Text))
                        {
                            MessageBox.Show("Geçerli bir email adresi giriniz.");
                            ev.Cancel = true;
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
                    txtPassword.Text = user.Password;


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
                    cmbRole.SelectedItem = user.Role;

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


                    btnSave.Click += (s, ev) =>
                    {
                        User updatedUser = new User
                        {
                            ID = SelectedID,
                            StudentID = txtStudentId.Text,
                            FirstName = txtName.Text,
                            LastName = txtSurname.Text,
                            Email = txtEmail.Text,
                            Password = txtPassword.Text,
                            RoleID = cmbRole.SelectedIndex + 1,
                            RFIDCardID = cmbCard.SelectedIndex + 1,
                            ProfileImage = "",
                            ProgramName = "Bilgisayar Programcılığı"
                        };
                        bool isSuccess = userController.UpdateUser(updatedUser);
                        MessageBox.Show(isSuccess ? "Kullanıcı başarıyla güncellendi. " + updatedUser.FullName : "Kullanıcı güncellenirken bir hata oluştu.");

                        this.Close();
                    };

                    break;
                case "Classrooms":

                    ClassRoom classRoom = classRoomController.GetById(SelectedID);

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
                    cmbTeacher.SelectedItem = classRoom.Teacher;

                    Label lblClassName = new Label();
                    lblClassName.Text = "Class Name";
                    lblClassName.Location = new Point(10, 50);
                    lblClassName.AutoSize = true;

                    TextBox txtClassName = new TextBox();
                    txtClassName.Location = new Point(10, 80);
                    txtClassName.Size = new Size(200, 20);
                    txtClassName.TabIndex = 1;
                    txtClassName.Text = classRoom.ClassName;

                    Label lblLessonName = new Label();
                    lblLessonName.Text = "Lesson Name";
                    lblLessonName.Location = new Point(10, 110);
                    lblLessonName.AutoSize = true;

                    TextBox txtLessonName = new TextBox();
                    txtLessonName.Location = new Point(10, 130);
                    txtLessonName.Size = new Size(200, 20);
                    txtLessonName.TabIndex = 2;
                    txtLessonName.Text = classRoom.LessonName;


                    Label lblClassDate = new Label();
                    lblClassDate.Text = "Class Date";
                    lblClassDate.Location = new Point(10, 160);
                    lblClassDate.AutoSize = true;

                    DateTimePicker dtpClassDate = new DateTimePicker();
                    dtpClassDate.Location = new Point(10, 180);
                    dtpClassDate.Size = new Size(200, 20);
                    dtpClassDate.TabIndex = 3;
                    dtpClassDate.Value = classRoom.ClassDate;


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
                    dtpStartTime.Value = new DateTime(classRoom.ClassDate.Year, classRoom.ClassDate.Month, classRoom.ClassDate.Day, classRoom.StartTime.Hours, classRoom.StartTime.Minutes, classRoom.StartTime.Seconds);

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
                    dtpEndTime.Value = new DateTime(classRoom.ClassDate.Year, classRoom.ClassDate.Month, classRoom.ClassDate.Day, classRoom.EndTime.Hours, classRoom.EndTime.Minutes, classRoom.EndTime.Seconds);

                    Label lblIsExam = new Label();
                    lblIsExam.Text = "Is Exam";
                    lblIsExam.Location = new Point(10, 310);
                    lblIsExam.AutoSize = true;

                    CheckBox chkIsExam = new CheckBox();
                    chkIsExam.Location = new Point(10, 330);
                    chkIsExam.Size = new Size(200, 20);
                    chkIsExam.TabIndex = 6;
                    chkIsExam.Checked = classRoom.IsExam;

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

                    btnSaveClassRoom.Click += (s, ev) =>
                    {
                        ClassRoom updatedClassRoom = new ClassRoom
                        {
                            ID = SelectedID,
                            TeacherID = cmbTeacher.SelectedIndex + 1,
                            ClassName = txtClassName.Text,
                            LessonName = txtLessonName.Text,
                            ClassDate = dtpClassDate.Value,
                            StartTime = dtpStartTime.Value.TimeOfDay,
                            EndTime = dtpEndTime.Value.TimeOfDay,
                            IsExam = chkIsExam.Checked,
                        };
                        bool isSuccess = classRoomController.UpdateClassRoom(updatedClassRoom);
                        MessageBox.Show(isSuccess ? "Sınıf başarıyla güncellendi. " + updatedClassRoom.ClassName : "Sınıf güncellenirken bir hata oluştu.");
                        this.Close();
                    };


                    break;
                case "Cards":

                    RFIDCard card = cardController.GetById(SelectedID);

                    Label lblRFIDNumber = new Label();
                    lblRFIDNumber.Text = "RFID Number";
                    lblRFIDNumber.Location = new Point(10, 10);
                    lblRFIDNumber.AutoSize = true;


                    TextBox txtRFIDNumber = new TextBox();
                    txtRFIDNumber.Location = new Point(10, 30);
                    txtRFIDNumber.Size = new Size(200, 20);
                    txtRFIDNumber.TabIndex = 0;
                    txtRFIDNumber.Text = card.RFIDNumber;

                    Label lblRawData = new Label();
                    lblRawData.Text = "Raw Data";
                    lblRawData.Location = new Point(10, 60);
                    lblRawData.AutoSize = true;

                    TextBox txtRawData = new TextBox();
                    txtRawData.Location = new Point(10, 80);
                    txtRawData.Size = new Size(200, 20);
                    txtRawData.TabIndex = 1;
                    lblRawData.AutoSize = true;
                    txtRawData.Text = card.RawData;

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

                    btnSaveCard.Click += (s, ev) =>
                    {
                        RFIDCard updatedCard = new RFIDCard
                        {
                            ID = SelectedID,
                            RFIDNumber = txtRFIDNumber.Text,
                            RawData = card.RawData,
                            CreatedDate = card.CreatedDate,
                            UpdatedDate = DateTime.Now
                        };
                        bool isSuccess = cardController.UpdateCard(updatedCard);
                        MessageBox.Show(isSuccess ? "RFID Card başarıyla güncellendi. " + updatedCard.RFIDNumber : "RFID Card güncellenirken bir hata oluştu.");
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