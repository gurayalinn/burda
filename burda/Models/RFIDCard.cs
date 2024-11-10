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
        ID BIGINT PRIMARY KEY IDENTITY(1,1),
        RFIDNumber NVARCHAR(50) NOT NULL UNIQUE,
        RawData NVARCHAR(MAX) DEFAULT NULL,
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME DEFAULT GETDATE()
        );
        */

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, StringLength(50)]
        [Index(IsUnique = true)]
        public string RFIDNumber { get; set; }

        [MaxLength]
        public string RawData { get; set; } = null;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

    }
}
