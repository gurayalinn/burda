using burda.Controllers;
using burda.Helpers;
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

namespace burda.Views
{
    public partial class ManagementForm : BaseForm
    {
        /*
        private RoleController roleController = new RoleController();
        private UserController userController = new UserController();
        private ClassRoomController classRoomController = new ClassRoomController();
        private AttendanceController attendanceController = new AttendanceController();
        private CardController cardController = new CardController();
        
        private List<Role> roles;
        private List<User> users;
        private List<ClassRoom> classRooms;
        private List<Attendance> attendances;
        private List<RFIDCard> cards;
        private List<RFIDCard> rooms;
        */
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

                if (LoginForm.loggedUser.Role.RoleName == "ADMIN")
                {
                    //dataGridViewList.DataSource = userController.GetAllStudents();
                    dataGridViewList.DefaultCellStyle.ForeColor = Color.Black;
                    buttonUsers.Visible = true;
                    pictureBoxUsers.Visible = true;
                    buttonCards.Visible = true;
                    pictureBoxCards.Visible = true;
                    buttonSettings.Visible = true;
                    pictureBoxSettings.Visible = true;
                }
                else
                {
                    buttonUsers.Visible = false;
                    pictureBoxUsers.Visible = false;
                    radioButtonUsers.Visible = false;
                    buttonCards.Visible = false;
                    pictureBoxCards.Visible = false;
                    radioButtonCards.Visible = false;
                }
            }
            else
            {
                this.Close();
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

        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            buttonSettings.PerformClick();

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

        private void radioButtonSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSettings.Checked)
            {
                buttonSettings.PerformClick();
            }

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            LoginForm.loggedUser = null;
            LoginForm form = new LoginForm();
            this.Close();
            form.Show();

        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            buttonLogout.PerformClick();
        }

        private void linkLabelUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //UserProfileForm form = new UserProfileForm(LoginForm.loggedUser);


        }
    }
}
