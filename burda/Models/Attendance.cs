using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace burda.Models
{
    public class Attendance
    {
        /*
        CREATE TABLE Attendance (
        ID INT PRIMARY KEY IDENTITY(1,1),
        UserID INT NOT NULL,
        ClassID INT NOT NULL,
        AttType NVARCHAR(50) DEFAULT 'RFID',
        AttTime DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (UserID) REFERENCES Users(ID),
        FOREIGN KEY (ClassID) REFERENCES ClassRooms(ID)
        );
        */

        [Key]
        public int ID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int ClassID { get; set; }

        [StringLength(50)]
        public string AttType { get; set; } = "RFID";

        public DateTime AttTime { get; set; } = DateTime.Now;

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("ClassID")]
        public virtual ClassRoom ClassRoom { get; set; }

    }


}
