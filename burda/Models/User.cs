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
        RFIDCardID BIGINT UNIQUE,
        RoleID INT NOT NULL,
        StudentID NVARCHAR(20) NULL,
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Password NVARCHAR(256) NOT NULL,
        Email NVARCHAR(254) NOT NULL UNIQUE,
        ProgramName NVARCHAR(100) NOT NULL,
        ProfileImage NVARCHAR(256) NULL,
        FOREIGN KEY (RoleID) REFERENCES Roles(ID),
        FOREIGN KEY (RFIDCardID) REFERENCES RFIDCards(ID),
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME DEFAULT GETDATE()
        );
        */


        public User()
        {
            ClassRooms = new HashSet<ClassRoom>();
            Attendances = new HashSet<Attendance>();
        }

        [Key]
        public int ID { get; set; }
        public long? RFIDCardID { get; set; }

        [Required, Range(1, 3), Display(Name = "Role")]
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
        [Index(IsUnique = true)]
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

        [ForeignKey("RFIDCardID")]
        public virtual RFIDCard RFIDCard { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }

        // User.RoleID = 1 => Admin
        // User.RoleID = 2 => Teacher
        // User.RoleID = 3 => Student

        public string FullName => $"{FirstName} {LastName}";
    }
}