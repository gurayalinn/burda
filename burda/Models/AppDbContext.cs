using System.Data.Entity;
using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class AppDbContext : DbContext
{
    public AppDbContext() : base("name=AppDbContext")
    {
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RFIDCard> RFIDCards { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasRequired(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleID);

        modelBuilder.Entity<RFIDCard>()
            .HasOptional(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserID);

        modelBuilder.Entity<ClassRoom>()
            .HasRequired(c => c.Teacher)
            .WithMany(t => t.ClassRooms)
            .HasForeignKey(c => c.TeacherID)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<Attendance>()
            .HasRequired(a => a.User)
            .WithMany(u => u.Attendances)
            .HasForeignKey(a => a.UserID);
    }
}
