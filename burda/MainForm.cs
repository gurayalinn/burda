using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using burda.Controllers;
using burda.Helpers;
using burda.Models;
using burda.Views;


namespace burda
{

    public partial class MainForm : BaseForm
    {
        private Timer timer1;
        private Timer timer2;

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

            ClassRoomController classRoomController = new ClassRoomController();
            List<ClassRoom> classrooms = classRoomController.GetAllClassRooms();
            comboBoxClassrooms.DataSource = classrooms;
            ClassRoom selectedClassRoom = classrooms.FirstOrDefault();
            comboBoxClassrooms.SelectedItem = selectedClassRoom;
            comboBoxClassrooms.ValueMember = "ID";
            comboBoxClassrooms.DisplayMember = "ClassName";
            comboBoxClassrooms.DropDownStyle = ComboBoxStyle.DropDownList;
            if (classrooms.Count > 0)
            {
            labelTeacherName.ForeColor = Color.Lime;
                
            labelLessonName.Text = selectedClassRoom.LessonName;
                if (selectedClassRoom.Teacher != null)
                {
                    labelTeacherName.Text = selectedClassRoom.Teacher.FullName;
                }
                else
                {
                    labelTeacherName.Text = "Öğretmen Yok";
                    labelTeacherName.ForeColor = Color.Red;
                }

                List<Attendance> todayAttendances = classRoomController.GetAttendanceListToday(selectedClassRoom.ID);
                labelCurrentStudentCount.Text = todayAttendances.Count.ToString();

                labelLessonStartTime.Text = selectedClassRoom.StartTime.Hours.ToString() + ":" + selectedClassRoom.StartTime.Minutes.ToString();
                labelLessonEndTime.Text = selectedClassRoom.EndTime.Hours.ToString() + ":" + selectedClassRoom.EndTime.Minutes.ToString();
                }


            maskedTextBoxClear();
            labelStatus.Text = "";
            labelStatus.Visible = true;
            labelCardReaderStatus.Text = "Bağlı Değil";
            labelDateCurrent.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            timer2 = new Timer();
            timer2.Interval = 10000;
            timer2.Tick += timer2_Tick;
            timer2.Start();

            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.labelDateCurrent.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            Gist gist = new Gist();
            await gist.SyncGistPeriodically(10000);
        }

        private void buttonHelpDesk_Click(object sender, EventArgs e)
        {
            HelpDeskForm form = new HelpDeskForm();
            form.Show();
        }

        private void pictureBoxHelpDesk_Click(object sender, EventArgs e)
        {
            buttonHelpDesk.PerformClick();
        }

        private void buttonHere_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            if (maskedTextBoxStudentId.Text.Length < 9)
            {
                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = "Öğrenci Numarası Girin!";
                maskedTextBoxClear();
                return;
            }

            if (userController.FindUserByStudentID(maskedTextBoxStudentId.Text) == null)
            {
                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = "Öğrenci Bulunamadı!";
                maskedTextBoxClear();
                return;
            }
            User student = userController.FindUserByStudentID(maskedTextBoxStudentId.Text);

            if (student != null && student.RoleID == 3 && comboBoxClassrooms.SelectedItem != null)
            {
                SoundHelper.PlayBeep();
                TextToSpeechHelper.ReadName(student.FullName);
                AttendanceController attendanceController = new AttendanceController();

                loadStudentInfo(student);

                ClassRoom selectedClassRoom = (ClassRoom)comboBoxClassrooms.SelectedItem;


                Attendance attendance = new Attendance()
                {
                    UserID = student.ID,
                    ClassID = selectedClassRoom.ID,
                    AttType = "NUM",
                    AttTime = DateTime.Now,
                };

                attendanceController.AddAttendance(attendance);

               
                EmailHelper emailHelper = new EmailHelper();
                bool isSuccess = emailHelper.SendEmail(student.Email, 
                    "Yoklama", "Yoklama başarıyla alındı." +
                    " Sınıf: " + selectedClassRoom.ClassName +
                    " Ders: " + selectedClassRoom.LessonName +
                    " Öğretmen: " + selectedClassRoom.Teacher.FullName +
                    " Tarih: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

                ClassRoomController classRoomController = new ClassRoomController();
                List<Attendance> todayAttendances = classRoomController.GetAttendanceListToday(selectedClassRoom.ID);
                labelCurrentStudentCount.Text = todayAttendances.Count.ToString();


                maskedTextBoxClear();

                labelStatus.ForeColor = Color.Lime;
                labelStatus.Text = "Kayıt Başarılı!";

            }
            else
            {
                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = "Öğrenci Bulunamadı!";
            }
        }


        private void loadStudentInfo(User student)
        {
            labelStudentName.Text = student.FullName;
            labelStudentId.Text = student.StudentID;
            if (student.RFIDCard != null)
            {
                labelLastCardID.Text = student.RFIDCard.RFIDNumber;
                labelLastCardID.ForeColor = Color.DarkGreen;
            }
            else
            {
                labelLastCardID.Text = "Kart Yok!";
                labelLastCardID.ForeColor = Color.Red;
            }
            labelLastReadTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");



            if (student.ProfileImage == null || student.ProfileImage == "")
            {
                pictureBoxStudentProfilePicture.Image = Properties.Resources.user;
            }
            else
            {
                Console.WriteLine(student.ProfileImage);
            }

        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void maskedTextBoxStudentId_TextChanged(object sender, EventArgs e)
        {
            labelStatus.Text = "";

            if (maskedTextBoxStudentId.Text.Length > 9)
            {
                maskedTextBoxStudentId.Text = maskedTextBoxStudentId.Text.Substring(0, 9);
            }
        }

        private void maskedTextBoxStudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void maskedTextBoxClear()
        {
            maskedTextBoxStudentId.Text = "";
            maskedTextBoxStudentId.Focus();
            maskedTextBoxStudentId.SelectAll();
        }

        private void maskedTextBoxStudentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonHere.PerformClick();
            }
        }

        private void pictureBoxHere_Click(object sender, EventArgs e)
        {
            buttonHere.PerformClick();
        }

        private void buttonManagement_Click(object sender, EventArgs e)
        {
            if (LoginForm.loggedUser != null)
            {
                ManagementForm form = new ManagementForm(LoginForm.loggedUser);
                form.Show();
            }
            else
            {
                LoginForm form = new LoginForm();
                form.Show();
            }
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            maskedTextBoxStudentId.Text += button.Text;

        }



        private void pictureBoxManagement_Click(object sender, EventArgs e)
        {
            buttonManagement.PerformClick();
        }

        private void maskedTextBoxStudentId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void buttonNum0_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);

        }

        private void buttonNum1_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);
        }

        private void buttonNum2_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);

        }

        private void buttonNum3_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);

        }

        private void buttonNum4_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);

        }

        private void buttonNum5_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);

        }

        private void buttonNum6_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);

        }

        private void buttonNum7_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);

        }

        private void buttonNum8_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);

        }

        private void buttonNum9_Click(object sender, EventArgs e)
        {
            buttonNum_Click(sender, e);

        }

        private void buttonNumClear_Click(object sender, EventArgs e)
        {
            maskedTextBoxStudentId.Text = "";
            maskedTextBoxStudentId.Focus();
            maskedTextBoxStudentId.SelectAll();
        }

        private void buttonNumDel_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxStudentId.Text.Length > 0)
            {
                maskedTextBoxStudentId.Text = maskedTextBoxStudentId.Text.Substring(0, maskedTextBoxStudentId.Text.Length - 1);
            }

        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxClassrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassRoom selectedClassRoom = (ClassRoom)comboBoxClassrooms.SelectedItem;

            ClassRoomController classRoomController = new ClassRoomController();
            List<Attendance> todayAttendances = classRoomController.GetAttendanceListToday(selectedClassRoom.ID);

            labelLessonName.Text = selectedClassRoom.LessonName;
            labelTeacherName.ForeColor = Color.Lime;
            labelCurrentStudentCount.Text = todayAttendances.Count.ToString();

            if (selectedClassRoom.Teacher != null)
            {
                labelTeacherName.Text = selectedClassRoom.Teacher.FullName;
            }
            else
            {
                labelTeacherName.Text = "Öğretmen Yok";
                labelTeacherName.ForeColor = Color.Red;
            }
            labelLessonStartTime.Text = selectedClassRoom.StartTime.Hours + ":" + selectedClassRoom.StartTime.Minutes.ToString();
            labelLessonEndTime.Text = selectedClassRoom.EndTime.Hours + ":" + selectedClassRoom.EndTime.Minutes.ToString();

        }

        private void pictureBoxClassList_Click(object sender, EventArgs e)
        {
            buttonClassList.PerformClick();
        }

        private void buttonClassList_Click(object sender, EventArgs e)
        {
            ClassRoom selectedClassRoom = (ClassRoom)comboBoxClassrooms.SelectedItem;
            ClassListForm form = new ClassListForm(selectedClassRoom);
            form.Show();
        }

        private void MainForm_FocusChanged(object sender, EventArgs e)
        {
            ClassRoomController classRoomController = new ClassRoomController();
            List<ClassRoom> classrooms = classRoomController.GetAllClassRooms();
            comboBoxClassrooms.DataSource = classrooms;
            comboBoxClassrooms.ValueMember = "ID";
            comboBoxClassrooms.DisplayMember = "ClassName";
            comboBoxClassrooms.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
