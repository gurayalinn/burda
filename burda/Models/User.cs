using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace burda.Models
{
    public class User
    {
        /*
        CREATE TABLE Users(
        ID INT PRIMARY KEY IDENTITY(1,1),
        RoleID INT NOT NULL,
        StudentID NVARCHAR(20) NULL,
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Password NVARCHAR(256) NOT NULL,
        Email NVARCHAR(254) NOT NULL UNIQUE,
        ProgramName NVARCHAR(100) NOT NULL,
        ProfileImage NVARCHAR(256) NULL,
        FOREIGN KEY (RoleID) REFERENCES Roles(ID),
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME DEFAULT GETDATE()
        );
        */

        [Key]
        public int ID { get; set; }

        [Required]
        public int RoleID { get; set; }

        [StringLength(20, ErrorMessage = "Öğrenci numarası 20 karakterden fazla olamaz.")]
        public string StudentID { get; set; }

        [Required(ErrorMessage = "Ad boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Ad 50 karakterden fazla olamaz.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Soyad 50 karakterden fazla olamaz.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz."), StringLength(256), DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz."), StringLength(254), DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }


        [Required, StringLength(100)]
        public string ProgramName { get; set; }

        [StringLength(256), DataType(DataType.ImageUrl)]
        [RegularExpression(@"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)", ErrorMessage = "Geçerli bir resim URL'si girin.")]
        [Display(Name = "Profile Image"), DisplayFormat(NullDisplayText = "No image")]
        public string ProfileImage { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        public virtual ICollection<RFIDCard> RFIDCards { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        // User.RoleID = 1 => Admin
        // User.RoleID = 2 => Teacher
        // User.RoleID = 3 => Student
        public bool IsAdmin => RoleID == 1;
        public bool IsTeacher => RoleID == 2;
        public bool IsStudent => RoleID == 3;

        public string FullName => $"{FirstName} {LastName}";

        public string RoleName => Role.RoleName;

        // get all users
        public static List<User> GetUsers()
        {
            using (var db = new AppDbContext())
            {
                return db.Users.ToList();
            }
        }

        // get teachers
        public static List<User> GetTeachers()
        {
            using (var db = new AppDbContext())
            {
                return db.Users.Where(u => u.RoleID == 2).ToList();
            }
        }

        // get students
        public static List<User> GetStudents()
        {
            using (var db = new AppDbContext())
            {
                return db.Users.Where(u => u.RoleID == 3).ToList();
            }
        }

        // get admins
        public static List<User> GetAdmins()
        {
            using (var db = new AppDbContext())
            {
                return db.Users.Where(u => u.RoleID == 1).ToList();
            }
        }

        // get user by ID
        public static User GetUser(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.Find(id);
            }
        }

        // get admin by ID
        public static User GetAdmin(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => u.RoleID == 1 && u.ID == id);
            }

        }

        // get teacher by ID
        public static User GetTeacher(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => u.RoleID == 2 && u.ID == id);
            }
        }

        // get student by ID
        public static User GetStudent(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => u.RoleID == 3 && u.ID == id);
            }
        }

        // get user by email
        public static User GetUserByEmail(string email)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => u.Email == email);
            }
        }

        // get admin by email
        public static User GetAdminByEmail(string email)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => u.Email == email && u.RoleID == 1);
            }
        }

        // get student by email

        public static User GetStudentByEmail(string email)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => u.Email == email && u.RoleID == 3);
            }
        }

        // get teacher by email
        public static User GetTeacherByEmail(string email)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => u.Email == email && u.RoleID == 2);
            }
        }


        // get user by RFIDNumber
        public static User GetUserByRFIDNumber(string rfidNumber)
        {
            using (var db = new AppDbContext())
            {
                return db.RFIDCards.FirstOrDefault(r => r.RFIDNumber == rfidNumber).User;
            }
        }

        // get student by StudentID (StudentID is unique) and RoleID = 3
        public static User GetStudentByStudentID(string studentID)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => u.StudentID == studentID && u.RoleID == 3);
            }
        }


        // get user by email and password > for login
        public static User GetUserByEmailAndPassword(string email, string password)
        {
            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            }
        }
    }
}