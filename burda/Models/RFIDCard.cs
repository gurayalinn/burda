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
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME DEFAULT GETDATE()
        );
        */

        [Key]
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string RFIDNumber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<User> Users { get; set; }

    }
}
