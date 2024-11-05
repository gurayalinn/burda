using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace burda.Models
{
    public class Role
    {
        /*
        CREATE TABLE Roles (
        ID INT PRIMARY KEY IDENTITY(1,1),
        RoleName NVARCHAR(256) NOT NULL
        );
        */

        [Key]
        public int ID { get; set; }
        [Required, StringLength(256)]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }


    }
}
