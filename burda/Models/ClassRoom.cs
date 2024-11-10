using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace burda.Models
{
    public class ClassRoom
    {
        /*
        CREATE TABLE ClassRooms (
        ID INT PRIMARY KEY IDENTITY(1,1),
        TeacherID INT NOT NULL,
        ClassName NVARCHAR(256) NOT NULL,
        LessonName NVARCHAR(256) NOT NULL,
        ClassDate DATE DEFAULT GETDATE(),
        StartTime TIME DEFAULT '08:00:00',
        EndTime TIME DEFAULT '23:00:00',
        IsExam BIT DEFAULT 0,
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (TeacherID) REFERENCES Users(ID)
        );
        */

        public ClassRoom()
        {
            Students = new HashSet<User>();
            Attendances = new HashSet<Attendance>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required, StringLength(256)]
        public string ClassName { get; set; }

        [Required, StringLength(256)]
        public string LessonName { get; set; }

        public DateTime ClassDate { get; set; } = DateTime.Today;
        public TimeSpan StartTime { get; set; } = new TimeSpan(8, 0, 0);
        public TimeSpan EndTime { get; set; } = new TimeSpan(23, 0, 0);

        public bool IsExam { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [ForeignKey("TeacherID")]
        public virtual User Teacher { get; set; }

        public virtual ICollection<User> Students { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
