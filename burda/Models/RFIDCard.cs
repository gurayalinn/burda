using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace burda.Models
{
    public class RFIDCard
    {
        /*
        CREATE TABLE RFIDCards (
        ID INT PRIMARY KEY IDENTITY(1,1),
        RFIDNumber NVARCHAR(50) NOT NULL UNIQUE,
        UserID INT NULL UNIQUE,
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (UserID) REFERENCES Users(ID)
        );
        */

        [Key]
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string RFIDNumber { get; set; }

        public int? UserID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

    }
}
