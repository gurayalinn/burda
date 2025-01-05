using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace burda.Views
{
    public partial class ClassListForm : BaseForm
    {
        List<ClassRoom> classRooms;
        List<Attendance> attendances;
        ClassRoomController classRoomController;
        UserController userController;
        AttendanceController attendanceController;
        public ClassRoom SelectedClassRoom;

        public ClassListForm(ClassRoom selectedClassRoom)
        {
            InitializeComponent();
            classRoomController = new ClassRoomController();
            userController = new UserController();
            attendanceController = new AttendanceController();
            classRooms = classRoomController.GetAllClassRooms();
            attendances = attendanceController.GetAll();

            comboBoxClassrooms.DataSource = classRooms;
            comboBoxClassrooms.ValueMember = "ID";
            comboBoxClassrooms.DisplayMember = "ClassName";
            comboBoxClassrooms.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectedClassRoom = classRooms.FirstOrDefault();
            SelectedClassRoom = selectedClassRoom;
            comboBoxClassrooms.SelectedItem = SelectedClassRoom;
            FillClassList();
        }

        private void ClassListForm_Load(object sender, EventArgs e)
        {
            FillClassList();
        }

        

        private void FillClassList()
        {
            SelectedClassRoom = (ClassRoom)comboBoxClassrooms.SelectedItem;
            List<Attendance> todayAttendances = classRoomController.GetAttendanceListToday(SelectedClassRoom.ID);
            dataGridViewClassList.DataSource = todayAttendances.Select(a => new
            {
                a.ID,
                StudentID = a.User.StudentID,
                StudentName = a.User.FullName,
                a.AttType,
                a.AttTime
            }).ToList();

            dataGridViewClassList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridViewClassList.Columns["ID"].Visible = false;
            dataGridViewClassList.Columns["AttTime"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
            dataGridViewClassList.Columns["AttTime"].HeaderText = "Zaman";
            dataGridViewClassList.Columns["StudentID"].HeaderText = "Öğrenci No";
            dataGridViewClassList.Columns["StudentName"].HeaderText = "Öğrenci";
            dataGridViewClassList.Columns["AttType"].HeaderText = "Yoklama";
            dataGridViewClassList.Columns["StudentID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewClassList.Columns["AttType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewClassList.Columns["StudentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewClassList.Columns["AttTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewClassList.Refresh();

        }

        private void comboBoxClassrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassRoom SelectedClassRoom = (ClassRoom)comboBoxClassrooms.SelectedItem;
            FillClassList();
        }
    }
}
