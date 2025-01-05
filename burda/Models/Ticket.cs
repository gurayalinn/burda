using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace burda.Models
{
    public class Ticket
    {
        /*
        CREATE TABLE Tickets (
        ID INT PRIMARY KEY IDENTITY(1,1),
        Message NVARCHAR(MAX) NOT NULL,
        Email NVARCHAR(254) NOT NULL,
        CreatedDate DATETIME DEFAULT GETDATE()
        );
        */

        [Key]
        public int ID { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(254)]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        public Ticket()
        {
            CreatedDate = DateTime.Now;
        }

        public Ticket(string message, string email)
        {
            Message = message;
            Email = email;
            CreatedDate = DateTime.Now;
        }

        public Ticket(int id, string message, string email, DateTime createdDate)
        {
            ID = id;
            Message = message;
            Email = email;
            CreatedDate = createdDate;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Message: {Message}, Email: {Email}, CreatedAt: {CreatedDate}";
        }

    }
}
