using System.Data.Entity;
using burda.Models;
using burda.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Windows.Forms;
using System.Linq;



public class AppDbContext : DbContext
{
    public AppDbContext() : base("name=AppDbContext")
    {
        Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
        // Update-Database -ConfigurationTypeName burda.Migrations.Configuration
        //Database.SetInitializer<AppDbContext>(new DropCreateDatabaseIfModelChanges<AppDbContext>());
        //Database.SetInitializer<AppDbContext>(new MigrateDatabaseToLatestVersion<AppDbContext, burda.Migrations.Configuration>());
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<RFIDCard> RFIDCards { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Role>()
            .HasMany<User>(r => r.Users)
            .WithRequired(u => u.Role)
            .HasForeignKey<int>(u => u.RoleID)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<User>()
            .HasOptional(u => u.RFIDCard)
            .WithMany()
            .HasForeignKey<long?>(u => u.RFIDCardID)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<User>()
            .HasMany<Attendance>(u => u.Attendances)
            .WithRequired(a => a.User)
            .HasForeignKey<int>(a => a.UserID)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<ClassRoom>()
            .HasRequired(c => c.Teacher)
            .WithMany()
            .HasForeignKey(c => c.TeacherID)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<ClassRoom>()
            .HasMany<Attendance>(c => c.Attendances)
            .WithRequired(a => a.ClassRoom)
            .HasForeignKey<int>(a => a.ClassID)
            .WillCascadeOnDelete(false);

        base.OnModelCreating(modelBuilder);


    }

    public override int SaveChanges()
    {
        var addedEntities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added)
            .Select(e => e.Entity)
            .ToList();

        int result = base.SaveChanges();

        foreach (var entity in addedEntities)
        {
            //Logger.Information($"New object: {entity.GetType().Name + " " + entity.ToString()}");
            Console.WriteLine($"New object: {entity.GetType().Name + " " + entity.ToString()}");
        }

        return result;
    }
}
