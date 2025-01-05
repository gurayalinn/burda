using burda.Controllers;
using burda.Helpers;
using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace burda.Views
{
    public partial class ManagementForm : BaseForm
    {

        private RoleController roleController = new RoleController();
        private UserController userController = new UserController();
        private ClassRoomController classRoomController = new ClassRoomController();
        private AttendanceController attendanceController = new AttendanceController();
        private CardController cardController = new CardController();
        private TicketController ticketController = new TicketController();

        public static String selectedSource;
        private int selectedID;

        public ManagementForm(User user)
        {
            LoginForm.loggedUser = user;

            if (LoginForm.loggedUser != null)
            {

                InitializeComponent();
            }
            else
            {
                this.Close();
            }
        }


        private void ManagementPanel_Load(object sender, EventArgs e)
        {

            if (LoginForm.loggedUser != null)
            {
                linkLabelUser.Text = LoginForm.loggedUser.FullName;
                radioButtonStudents.Checked = true;
                selectedSource = "Students";
                dataGridViewList.DataSource = userController.GetAllStudents();
                dataGridViewList.DefaultCellStyle.ForeColor = Color.Black;
                if (dataGridViewList.Rows.Count > 0 && dataGridViewList.Rows[0].Cells[0].Value != null)
                {
                        selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                        dataGridViewList.Rows[0].Selected = true;
                }

                if (LoginForm.loggedUser.Role.RoleName == "ADMIN")
                {
                    buttonUsers.Visible = true;
                    pictureBoxUsers.Visible = true;
                    
                    buttonCards.Visible = true;
                    pictureBoxCards.Visible = true;
                    
                    buttonTickets.Visible = true;
                    pictureBoxTickets.Visible = true;
                }
                else
                {
                    buttonUsers.Visible = false;
                    pictureBoxUsers.Visible = false;
                    radioButtonUsers.Visible = false;
                    
                    buttonCards.Visible = false;
                    pictureBoxCards.Visible = false;
                    radioButtonCards.Visible = false;

                    buttonTickets.Visible = false;
                    pictureBoxTickets.Visible = false;
                    radioButtonTickets.Visible = false;
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else
            {
                this.Close();
            }


        }

        private void buttonInspect_Click(object sender, EventArgs e)
        {
            if (selectedID > 0 && selectedID != 0)
            {
                if (radioButtonStudents.Checked)
                {
                    User user = userController.GetById(selectedID);
                    if (user != null)
                    {
                        MessageBox.Show("İncele Öğrenciler" + selectedID);
                        // InspectForm form = new InspectForm(selectedSource, selectedID);
                    }
                }
                else if (radioButtonClassrooms.Checked)
                {
                    ClassRoom classRoom = classRoomController.GetById(selectedID);
                    if (classRoom != null)
                    {
                        MessageBox.Show("İncele Sınıflar" + selectedID);
                    }
                }
                else if (radioButtonAttendances.Checked)
                {
                    Attendance attendance = attendanceController.GetById(selectedID);
                    if (attendance != null)
                    {
                        MessageBox.Show("İncele Yoklamalar" + selectedID);
                    }
                }
                else if (radioButtonUsers.Checked)
                {
                    User user = userController.GetById(selectedID);
                    if (user != null)
                    {
                        MessageBox.Show("İncele Kullanıcılar" + selectedID);
                    }
                }
                else if (radioButtonCards.Checked)
                {
                    RFIDCard card = cardController.GetById(selectedID);
                    if (card != null)
                    {
                        MessageBox.Show("İncele Kartlar" + selectedID);
                    }
                }
            }
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (selectedID > 0 && selectedID != 0)
            {
                if (radioButtonStudents.Checked)
                {
                    User user = userController.GetById(selectedID);
                    if (user != null)
                    {
                        EditForm form = new EditForm(selectedSource, selectedID);
                        form.Show();
                    }
                }
                else if (radioButtonClassrooms.Checked)
                {
                    ClassRoom classRoom = classRoomController.GetById(selectedID);
                    if (classRoom != null)
                    {
                        EditForm form = new EditForm(selectedSource, selectedID);
                        form.Show();
                    }
                }
                else if (radioButtonAttendances.Checked)
                {
                    Attendance attendance = attendanceController.GetById(selectedID);
                    if (attendance != null)
                    {
                        MessageBox.Show("Yoklama kaydı düzenlenemez!");
                    }
                }
                else if (radioButtonUsers.Checked)
                {
                    User user = userController.GetById(selectedID);
                    if (user != null)
                    {
                        EditForm form = new EditForm(selectedSource, selectedID);
                        form.Show();

                    }
                }
                else if (radioButtonCards.Checked)
                {
                    RFIDCard card = cardController.GetById(selectedID);
                    if (card != null)
                    {
                        EditForm form = new EditForm(selectedSource, selectedID);
                        form.Show();
                    }
                }
                else if (radioButtonTickets.Checked)
                {
                    Ticket ticket = ticketController.GetById(selectedID);
                    if (ticket != null)
                    {
                        MessageBox.Show("Talep kaydı düzenlenemez!");
                    }


                }
            }
        }


        private void dataGridViewListID_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewList.Rows[e.RowIndex];
                if (row != null) {
                selectedID = Convert.ToInt32(row.Cells[0].Value);
                }

                if (selectedID > 0 && selectedID != 0)
                {
                    if (radioButtonStudents.Checked)
                    {
                        User user = userController.GetById(selectedID);
                    }
                    
                    else if (radioButtonClassrooms.Checked)
                    {
                        ClassRoom classRoom = classRoomController.GetById(selectedID);
                    }
                    
                    else if (radioButtonAttendances.Checked)
                    {
                        Attendance attendance = attendanceController.GetById(selectedID);
                    }
                    else if (radioButtonUsers.Checked)
                    {
                        User user = userController.GetById(selectedID);
                    }
                    else if (radioButtonCards.Checked)
                    {
                        RFIDCard card = cardController.GetById(selectedID);
                    }

                }
            }
        }



        private void pictureBoxStudents_Click(object sender, EventArgs e)
        {
            buttonStudents.PerformClick();
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Focus();
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            buttonAdd.PerformClick();
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            buttonEdit.PerformClick();

        }

        private void pictureBoxSave_Click(object sender, EventArgs e)
        {
            buttonSave.PerformClick();

        }

        private void pictureBoxInspect_Click(object sender, EventArgs e)
        {
            buttonInspect.PerformClick();

        }

        private void pictureBoxRefresh_Click(object sender, EventArgs e)
        {
            buttonRefresh.PerformClick();

        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            buttonDelete.PerformClick();

        }

        private void pictureBoxClassrooms_Click(object sender, EventArgs e)
        {
            buttonClassrooms.PerformClick();

        }

        private void pictureBoxAttendances_Click(object sender, EventArgs e)
        {
            buttonAttendances.PerformClick();

        }

        private void pictureBoxUsers_Click(object sender, EventArgs e)
        {
            buttonUsers.PerformClick();

        }

        private void pictureBoxCards_Click(object sender, EventArgs e)
        {
            buttonCards.PerformClick();

        }

        private void pictureBoxTickets_Click(object sender, EventArgs e)
        {
            buttonTickets.PerformClick();

        }

        private void radioButtonStudents_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStudents.Checked)
            {
                buttonStudents.PerformClick();
            }

        }

        private void radioButtonClassrooms_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonClassrooms.Checked)
            {
                buttonClassrooms.PerformClick();
            }

        }

        private void radioButtonAttendances_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAttendances.Checked)
            {
                buttonAttendances.PerformClick();
            }

        }

        private void radioButtonUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUsers.Checked)
            {
                buttonUsers.PerformClick();
            }

        }

        private void radioButtonCards_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCards.Checked)
            {
                buttonCards.PerformClick();
            }

        }

        private void radioButtonTickets_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTickets.Checked)
            {
                buttonTickets.PerformClick();
            }

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            LoginForm.loggedUser = null;
            LoginForm form = new LoginForm();
            selectedSource = "";
            selectedID = 0;
            this.Close();
            form.Show();

        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            buttonLogout.PerformClick();
        }

        private void linkLabelUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LoginForm.loggedUser != null)
            {
                StringBuilder userInfo = new StringBuilder();
                userInfo.AppendLine($"Ad: {LoginForm.loggedUser.FirstName}");
                userInfo.AppendLine($"Soyad: {LoginForm.loggedUser.LastName}");
                userInfo.AppendLine($"E-posta: {LoginForm.loggedUser.Email}");
                userInfo.AppendLine($"Rol: {LoginForm.loggedUser.Role.RoleName}");
                userInfo.AppendLine($"Oluşturulma Tarihi: {LoginForm.loggedUser.CreatedDate}");
                userInfo.AppendLine($"Güncellenme Tarihi: {LoginForm.loggedUser.UpdatedDate}");

                MessageBox.Show(userInfo.ToString(), "Profil Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void buttonTickets_Click(object sender, EventArgs e)
        {
            radioButtonTickets.Checked = true;
            groupBoxList.Text = "Talepler";
            selectedSource = "Tickets";
            dataGridViewList.DataSource = ticketController.GetAll();
            if (dataGridViewList.Rows.Count > 0)
            {
                selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
            }
            customizeDataGridView(selectedSource, dataGridViewList);

        }

        private void buttonClassrooms_Click(object sender, EventArgs e)
        {
            radioButtonClassrooms.Checked = true;
            groupBoxList.Text = "Sınıflar";
            selectedSource = "Classrooms";
            dataGridViewList.DataSource = classRoomController.GetAllClassRooms();
            if (dataGridViewList.Rows.Count > 0)
            {
                selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
            }
            customizeDataGridView(selectedSource, dataGridViewList);

        }

        private void buttonStudents_Click(object sender, EventArgs e)
        {
            radioButtonStudents.Checked = true;
            groupBoxList.Text = "Öğrenciler";
            selectedSource = "Students";
            dataGridViewList.DataSource = userController.GetAllStudents();
            if (dataGridViewList.Rows.Count > 0)
            {
                selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
            }
            customizeDataGridView(selectedSource, dataGridViewList);
        }

        private void buttonAttendances_Click(object sender, EventArgs e)
        {
            radioButtonAttendances.Checked = true;
            groupBoxList.Text = "Yoklamalar";
            selectedSource = "Attendances";
            dataGridViewList.DataSource = attendanceController.GetAll();
            if (dataGridViewList.Rows.Count > 0)
            {
                selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
            }
            customizeDataGridView(selectedSource, dataGridViewList);


        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {

            radioButtonUsers.Checked = true;
            groupBoxList.Text = "Kullanıcılar";
            selectedSource = "Users";
            dataGridViewList.DataSource = userController.GetAll();
            if (dataGridViewList.Rows.Count > 0)
            {
                selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
            }
            customizeDataGridView(selectedSource, dataGridViewList);


        }

        private void buttonCards_Click(object sender, EventArgs e)
        {
            radioButtonCards.Checked = true;
            groupBoxList.Text = "Kartlar";
            selectedSource = "Cards";
            dataGridViewList.DataSource = cardController.GetAll();
            if (dataGridViewList.Rows.Count > 0)
            {
                selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
            }
            customizeDataGridView(selectedSource, dataGridViewList);


        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            switch (selectedSource)
            {
                case "Students":
                    AddForm AddFormStudent = new AddForm(selectedSource);
                    AddFormStudent.Show();
                    break;
                case "Classrooms":
                    AddForm AddFormClassroom = new AddForm(selectedSource);
                    AddFormClassroom.Show();
                    break;
                case "Attendances":
                    MessageBox.Show("Yoklama eklemek için ana sayfaya gidiniz.");
                    break;
                case "Users":
                    AddForm AddFormUser = new AddForm(selectedSource);
                    AddFormUser.Show();
                    break;
                case "Cards":
                    AddForm AddFormCard = new AddForm(selectedSource);
                    AddFormCard.Show();
                    break;
                case "Tickets":
                    HelpDeskForm HelpDeskForm = new HelpDeskForm();
                    HelpDeskForm.Show();
                    break;
            }

        }


        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (radioButtonStudents.Checked)
            {
                dataGridViewList.DataSource = userController.Search(textBoxSearch.Text);
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonClassrooms.Checked)
            {
                dataGridViewList.DataSource = classRoomController.Search(textBoxSearch.Text);
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonAttendances.Checked)
            {
                dataGridViewList.DataSource = attendanceController.Search(textBoxSearch.Text);
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonUsers.Checked)
            {
                dataGridViewList.DataSource = userController.Search(textBoxSearch.Text);
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonCards.Checked)
            {
                dataGridViewList.DataSource = cardController.Search(textBoxSearch.Text);
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonTickets.Checked)
            {
                groupBox1.Visible = false;
            }

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (radioButtonStudents.Checked)
            {
                dataGridViewList.DataSource = userController.GetAllStudents();
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonClassrooms.Checked)
            {
                dataGridViewList.DataSource = classRoomController.GetAllClassRooms();
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonAttendances.Checked)
            {
                dataGridViewList.DataSource = attendanceController.GetAll();
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonUsers.Checked)
            {
                dataGridViewList.DataSource = userController.GetAll();
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonCards.Checked)
            {
                dataGridViewList.DataSource = cardController.GetAll();
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }
            else if (radioButtonTickets.Checked)
            {
                dataGridViewList.DataSource = ticketController.GetAll();
                if (dataGridViewList.Rows.Count > 0)
                {
                    selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                }
                customizeDataGridView(selectedSource, dataGridViewList);
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            switch (selectedSource) {
                case "Attendances":
                    Attendance attendance = attendanceController.GetById(selectedID);
                    if (attendance != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                        attendanceController.Delete(attendance);
                        dataGridViewList.DataSource = attendanceController.GetAll();
                        if (dataGridViewList.Rows.Count > 0)
                        {
                            selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                        }
                        customizeDataGridView(selectedSource, dataGridViewList);
                    }
                    break;
                case "Cards":
                    RFIDCard card = cardController.GetById(selectedID);
                    if (card != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                        User cardUser = userController.FindUserByCardNumber(card.RFIDNumber);

                        if (cardUser != null && cardUser.RFIDCard != null && cardUser.RFIDCard.ID == card.ID)
                        {
                            cardUser.RFIDCard = null;
                            userController.UpdateUser(cardUser);
                        }

                        cardController.Delete(card);
                        dataGridViewList.DataSource = cardController.GetAll();
                        if (dataGridViewList.Rows.Count > 0)
                        {
                            selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                        }
                        customizeDataGridView(selectedSource, dataGridViewList);
                    }
                    break;
                case "Classrooms":
                    ClassRoom classRoom = classRoomController.GetById(selectedID);
                    if (classRoom != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                        if (classRoom.Attendances != null && classRoom.Attendances.Count > 0)
                        {
                            MessageBox.Show("Sınıfa ait yoklama kayıtları olduğu için silinemez!");
                            return;
                        }

                        if (classRoom.Teacher != null)
                        {
                            classRoom.Teacher = null;
                            classRoomController.Update(classRoom);
                        }

                        classRoomController.Delete(classRoom);
                        dataGridViewList.DataSource = classRoomController.GetAllClassRooms();
                        if (dataGridViewList.Rows.Count > 0)
                        {
                            selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                        }
                        customizeDataGridView(selectedSource, dataGridViewList);
                    }
                    break;
                case "Students":
                    User stundent = userController.GetById(selectedID);
                    if (stundent != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                        if (stundent.RoleID == 1)
                        {
                            MessageBox.Show("Bu kullanıcı silinemez!");
                            return;
                        }

                        if (stundent.Attendances != null && stundent.Attendances.Count > 0)
                        {
                            MessageBox.Show("Öğrenciye ait yoklama kayıtları olduğu için silinemez!");
                        }
                        else
                        {
                            userController.Delete(stundent);
                            dataGridViewList.DataSource = userController.GetAllStudents();
                            if (dataGridViewList.Rows.Count > 0)
                            {
                                selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                            }
                            customizeDataGridView(selectedSource, dataGridViewList);
                        }
                    }
                    break;
                case "Users":
                    User user = userController.GetById(selectedID);
                    if (user != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                        if (user.RoleID == 1)
                        {
                            MessageBox.Show("Bu kullanıcı silinemez!");
                            return;
                        }

                        if (LoginForm.loggedUser.ID == user.ID)
                        {
                            MessageBox.Show("Kendi hesabınızı silemezsiniz!");
                            return;
                        }

                        if (user.RoleID == 3 && user.Attendances != null && user.Attendances.Count > 0)
                        {
                            MessageBox.Show("Öğrenciye ait yoklama kayıtları olduğu için silinemez!");
                            return;
                        }

                        List <ClassRoom> teacherClassRooms = classRoomController.FindClassesByTeacherID(user.ID);
                        if (user.RoleID == 2 && teacherClassRooms != null && teacherClassRooms.Count > 0)
                        {
                            foreach (ClassRoom teacherClassRoom in teacherClassRooms)
                            {
                                teacherClassRoom.Teacher = null;
                                classRoomController.Update(teacherClassRoom);
                            }
                        }

                        if (user.RFIDCard != null)
                        {
                            user.RFIDCard = null;
                            userController.Update(user);
                        }

                        userController.Delete(user);
                        dataGridViewList.DataSource = userController.GetAll();
                        if (dataGridViewList.Rows.Count > 0)
                        {
                            selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                        }
                        customizeDataGridView(selectedSource, dataGridViewList);

                    }
                    break;
                case "Tickets":
                    Ticket ticket = ticketController.GetById(selectedID);
                    if (ticket != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                        ticketController.Delete(ticket);
                        dataGridViewList.DataSource = ticketController.GetAll();
                        if (dataGridViewList.Rows.Count > 0)
                        {
                            selectedID = Convert.ToInt32(dataGridViewList.Rows[0].Cells[0].Value);
                        }
                        customizeDataGridView(selectedSource, dataGridViewList);
                    }
                    break;
            }
        }


        private void customizeDataGridView(String SelectedSource, DataGridView dataGridView)
        {
            if (SelectedSource == "Students")
            {
                dataGridView.Columns["ID"].Visible = false; 
                dataGridView.Columns["RoleID"].Visible = false;
                dataGridView.Columns["Password"].Visible = false;
                dataGridView.Columns["UpdatedDate"].Visible = false;
                dataGridView.Columns["ProfileImage"].Visible = false;
                dataGridView.Columns["Role"].Visible = false;
                dataGridView.Columns["RFIDCard"].Visible = false;
                dataGridView.Columns["ClassRooms"].Visible = false;
                dataGridView.Columns["Attendances"].Visible = false;
                dataGridView.Columns["FullName"].Visible = false;
                dataGridView.Columns["RoleName"].HeaderText = "Rol";
                dataGridView.Columns["ProgramName"].Visible = false;
                dataGridView.Columns["RFIDCardID"].HeaderText = "Kart ID";
                dataGridView.Columns["CreatedDate"].HeaderText = "Kayıt Tarihi";
                dataGridView.Columns["StudentID"].HeaderText = "Öğrenci No";
                dataGridView.Columns["FirstName"].HeaderText = "Ad";
                dataGridView.Columns["LastName"].HeaderText = "Soyad";
                dataGridView.Columns["Email"].HeaderText = "E-posta";

            }
            else if (SelectedSource == "Classrooms")
            {
                dataGridView.Columns["ID"].Visible = false;
                dataGridView.Columns["Teacher"].Visible = false;
                dataGridView.Columns["Students"].Visible = false;
                dataGridView.Columns["UpdatedDate"].Visible = false;
                dataGridView.Columns["CreatedDate"].Visible = false;
                dataGridView.Columns["TeacherID"].HeaderText = "Öğretmen ID";
                dataGridView.Columns["ClassName"].HeaderText = "Sınıf Adı";
                dataGridView.Columns["LessonName"].HeaderText = "Ders Adı";
                dataGridView.Columns["ClassDate"].HeaderText = "Sınıf Tarihi";
                dataGridView.Columns["StartTime"].HeaderText = "Ders Baş. Saati";
                dataGridView.Columns["EndTime"].HeaderText = "Ders Bit. Saati";
                dataGridView.Columns["IsExam"].HeaderText = "Sınav Mı?";

            }
            else if (SelectedSource == "Attendances")
            {
                dataGridView.Columns["ID"].Visible = false;
                dataGridView.Columns["User"].Visible = false;
                dataGridView.Columns["ClassRoom"].Visible = false;
                dataGridView.Columns["AttType"].HeaderText = "Yoklama Türü";
                dataGridView.Columns["AttTime"].HeaderText = "Yoklama Tarihi";
                dataGridView.Columns["ClassID"].HeaderText = "Sınıf ID";
                dataGridView.Columns["UserID"].HeaderText = "Öğrenci ID";


            }
            else if (SelectedSource == "Users")
            {
                dataGridView.Columns["ID"].Visible = false;
                dataGridView.Columns["RoleID"].Visible = false;
                dataGridView.Columns["Password"].Visible = false;
                dataGridView.Columns["UpdatedDate"].Visible = false;
                dataGridView.Columns["ProfileImage"].Visible = false;
                dataGridView.Columns["Role"].Visible = false;
                dataGridView.Columns["RFIDCard"].Visible = false;
                dataGridView.Columns["ClassRooms"].Visible = false;
                dataGridView.Columns["Attendances"].Visible = false;
                dataGridView.Columns["FullName"].Visible = false;
                dataGridView.Columns["RoleName"].HeaderText = "Rol";
                dataGridView.Columns["ProgramName"].Visible = false;
                dataGridView.Columns["RFIDCardID"].HeaderText = "Kart ID";
                dataGridView.Columns["CreatedDate"].HeaderText = "Kayıt Tarihi";
                dataGridView.Columns["StudentID"].HeaderText = "Öğrenci No";
                dataGridView.Columns["FirstName"].HeaderText = "Ad";
                dataGridView.Columns["LastName"].HeaderText = "Soyad";
                dataGridView.Columns["Email"].HeaderText = "E-posta";

            }
            else if (SelectedSource == "Cards")
            {
                dataGridView.Columns["ID"].Visible = false;
            }
            else if (SelectedSource == "Tickets")
            {
                dataGridView.Columns["ID"].Visible = false;
            }
        }




        private void buttonSave_Click(object sender, EventArgs e)
        {
            switch (selectedSource)
            {
                case "Students":
                    MessageBox.Show("Öğrenci Kaydet");
                    break;
                case "Classrooms":
                    MessageBox.Show("Sınıf Kaydet");
                    break;
                case "Attendances":
                    MessageBox.Show("Yoklama Kaydet");
                    break;
                case "Users":
                    MessageBox.Show("Kullanıcı Kaydet");
                    break;
                case "Cards":
                    MessageBox.Show("Kart Kaydet");
                    break;
                case "Tickets":
                    MessageBox.Show("Talep Kaydet");
                    break;
            }
        }
    }
}

