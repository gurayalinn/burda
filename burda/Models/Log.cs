using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace burda.Models
{
    public class Log
    {
        /*
        CREATE TABLE Logs (
        ID INT PRIMARY KEY IDENTITY(1,1),
        LogType NVARCHAR(50) NOT NULL,
        Message NVARCHAR(MAX) NOT NULL,
        LogTime DATETIME DEFAULT GETDATE()
        );
        */

        [Key]
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string LogType { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime LogTime { get; set; } = DateTime.Now;
    }
}
