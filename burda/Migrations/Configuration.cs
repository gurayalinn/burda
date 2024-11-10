using burda.Models;

namespace burda.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDbContext context)
        {

            context.Roles.AddOrUpdate(
                r => r.RoleName,
                new Role { RoleName = "ADMIN" },
                new Role { RoleName = "TEACHER" },
                new Role { RoleName = "STUDENT" }
            );


            context.RFIDCards.AddOrUpdate(
                new RFIDCard { ID = 1, RFIDNumber = "000000000000" },
                new RFIDCard { ID = 2, RFIDNumber = "000000000001" },
                new RFIDCard { ID = 3, RFIDNumber = "000000000002" },
                new RFIDCard { ID = 4, RFIDNumber = "000000000003" },
                new RFIDCard { ID = 5, RFIDNumber = "000000000004" },
                new RFIDCard { ID = 6, RFIDNumber = "000000000005" },
                new RFIDCard { ID = 7, RFIDNumber = "000000000006" },
                new RFIDCard { ID = 8, RFIDNumber = "000000000007" },
                new RFIDCard { ID = 9, RFIDNumber = "000000000008" },
                new RFIDCard { ID = 10, RFIDNumber = "000000000009" }
            );

            context.Users.AddOrUpdate(u => u.ID,
                new User
                {
                    ID = 1,
                    RFIDCardID = 1,
                    RoleID = 1,
                    StudentID = "000000000",
                    FirstName = "ADMIN",
                    LastName = "ACCOUNT",
                    Password = "Burda16!",
                    Email = "admin@burda.local",
                    ProgramName = "ADMIN",
                    ProfileImage = null
                },
                new User
                {
                    ID = 2,
                    RFIDCardID = 2,
                    RoleID = 2,
                    StudentID = "002942369",
                    FirstName = "EBRU",
                    LastName = "YENİMAN",
                    Password = "123456",
                    Email = "yeniman@uludag.edu.tr",
                    ProgramName = "Bilgisayar Programcılığı",
                    ProfileImage = "https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/ebru_yeniman_yildirim.jpg"
                },
                new User
                {
                    ID = 3,
                    RFIDCardID = 3,
                    RoleID = 2,
                    StudentID = "002942387",
                    FirstName = "HATİCE",
                    LastName = "ÇAVUŞ",
                    Password = "123456",
                    Email = "hyilmaz@uludag.edu.tr",
                    ProgramName = "Bilgisayar Programcılığı",
                    ProfileImage = "https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/hatice_cavus.jpg"
                },
                new User
                {
                    ID = 4,
                    RFIDCardID = 4,
                    RoleID = 2,
                    StudentID = "002942372",
                    FirstName = "UĞUR",
                    LastName = "FIKDIKOĞLU",
                    Password = "123456",
                    Email = "ugurf@uludag.edu.tr",
                    ProgramName = "Bilgisayar Programcılığı",
                    ProfileImage = "https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/ugur_findikoglu.jpg"
                },
                new User
                {
                    ID = 5,
                    RFIDCardID = 5,
                    RoleID = 2,
                    StudentID = "002942378",
                    FirstName = "HÜLYA",
                    LastName = "BOZYOKUŞ",
                    Password = "123456",
                    Email = "hulya@uludag.edu.tr",
                    ProgramName = "Bilgisayar Programcılığı",
                    ProfileImage = "https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/hulya_bozyokus.jpg"
                },
                new User
                {
                    ID = 6,
                    RFIDCardID = 6,
                    RoleID = 2,
                    StudentID = "002942379",
                    FirstName = "MURAT",
                    LastName = "ÇALIŞ",
                    Password = "123456",
                    Email = "murat.calis@uludag.edu.tr",
                    ProgramName = "Bilgisayar Programcılığı",
                    ProfileImage = null
                },
                new User
                {
                    ID = 7,
                    RFIDCardID = 7,
                    RoleID = 2,
                    StudentID = "002942380",
                    FirstName = "KADİR BURAK",
                    LastName = "OLGUN",
                    Password = "123456",
                    Email = "kadirburak.olgun@uludag.edu.tr",
                    ProgramName = "Bilgisayar Programcılığı",
                    ProfileImage = null
                },
                new User
                {
                    ID = 8,
                    RFIDCardID = 8,
                    RoleID = 3,
                    StudentID = "222203578",
                    FirstName = "GÜRAY",
                    LastName = "ALIN",
                    Password = "123456",
                    Email = "222203578@ogr.uludag.edu.tr",
                    ProgramName = "Bilgisayar Programcılığı",
                    ProfileImage = null,
                },
                new User
                {
                    ID = 9,
                    RFIDCardID = 9,
                    RoleID = 3,
                    StudentID = "222303507",
                    FirstName = "EMİRHAN",
                    LastName = "UYSAL",
                    Password = "123456",
                    Email = "222303507@ogr.uludag.edu.tr",
                    ProgramName = "Bilgisayar Programcılığı",
                    ProfileImage = null
                },
                new User
                {
                    ID = 10,
                    RFIDCardID = 10,
                    RoleID = 3,
                    StudentID = "222303519",
                    FirstName = "HİLMİ",
                    LastName = "ENGİNAR",
                    Password = "123456",
                    Email = "222303519@ogr.uludag.edu.tr",
                    ProgramName = "Bilgisayar Programcılığı",
                    ProfileImage = null
                }
                );




            context.ClassRooms.AddOrUpdate(c => c.ID,
                new ClassRoom
                {
                    ID = 1,
                    ClassName = "BİL. LAB. 1",
                    TeacherID = 3,
                    LessonName = "VERİ TABANI I",
                    ClassDate = new DateTime(2024, 10, 1),
                    StartTime = new TimeSpan(10, 30, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    IsExam = false
                },
                new ClassRoom
                {
                    ID = 2,
                    ClassName = "C BLOK D6",
                    TeacherID = 5,
                    LessonName = "TEMEL MATEMATİK",
                    ClassDate = new DateTime(2024, 10, 1),
                    StartTime = new TimeSpan(13, 0, 0),
                    EndTime = new TimeSpan(14, 30, 0),
                    IsExam = false
                },
                new ClassRoom
                {
                    ID = 3,
                    ClassName = "BİL. LAB. 2",
                    TeacherID = 2,
                    LessonName = "PROGRAMLAMA TEMELLERİ",
                    ClassDate = new DateTime(2024, 10, 1),
                    StartTime = new TimeSpan(8, 30, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    IsExam = false
                },
                new ClassRoom
                {
                    ID = 4,
                    ClassName = "BİL. LAB. 2",
                    TeacherID = 7,
                    LessonName = "NESNE TABANLI PROGRAMLAMA",
                    ClassDate = new DateTime(2024, 10, 1),
                    StartTime = new TimeSpan(8, 30, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    IsExam = false
                },
                new ClassRoom
                {
                    ID = 5,
                    ClassName = "BİL. LAB. 2",
                    TeacherID = 6,
                    LessonName = "GÖRSEL PROGRAMLA",
                    ClassDate = new DateTime(2024, 10, 1),
                    StartTime = new TimeSpan(8, 30, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    IsExam = false
                },
                new ClassRoom
                {
                    ID = 6,
                    ClassName = "BİL. LAB. 2",
                    TeacherID = 4,
                    LessonName = "İNTERNET PROGRAMCILIĞI",
                    ClassDate = new DateTime(2024, 10, 1),
                    StartTime = new TimeSpan(8, 30, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    IsExam = false
                },
                new ClassRoom
                {
                    ID = 7,
                    ClassName = "BİL. LAB. 2",
                    TeacherID = 3,
                    LessonName = "SINAV: VERİ TABANI II",
                    ClassDate = new DateTime(2024, 11, 1),
                    StartTime = new TimeSpan(16, 15, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    IsExam = true
                }
                );


            context.Attendances.AddOrUpdate(a => a.ID,
                new Attendance { ID = 1, UserID = 8, ClassID = 1, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 10, 30, 0) },
                new Attendance { ID = 2, UserID = 9, ClassID = 1, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 10, 30, 0) },
                new Attendance { ID = 3, UserID = 10, ClassID = 1, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 10, 30, 0) },
                new Attendance { ID = 4, UserID = 8, ClassID = 2, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 13, 0, 0) },
                new Attendance { ID = 5, UserID = 9, ClassID = 2, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 13, 0, 0) },
                new Attendance { ID = 6, UserID = 10, ClassID = 2, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 13, 0, 0) },
                new Attendance { ID = 7, UserID = 8, ClassID = 3, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 8, UserID = 9, ClassID = 3, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 9, UserID = 10, ClassID = 3, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 10, UserID = 8, ClassID = 4, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 11, UserID = 9, ClassID = 4, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 12, UserID = 10, ClassID = 4, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 13, UserID = 8, ClassID = 5, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 14, UserID = 9, ClassID = 5, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 15, UserID = 10, ClassID = 5, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 16, UserID = 8, ClassID = 6, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 17, UserID = 9, ClassID = 6, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 18, UserID = 10, ClassID = 6, AttType = "RFID", AttTime = new DateTime(2024, 10, 1, 8, 30, 0) },
                new Attendance { ID = 19, UserID = 8, ClassID = 7, AttType = "RFID", AttTime = new DateTime(2024, 11, 1, 16, 15, 0) },
                new Attendance { ID = 20, UserID = 9, ClassID = 7, AttType = "RFID", AttTime = new DateTime(2024, 11, 1, 16, 15, 0) },
                new Attendance { ID = 21, UserID = 10, ClassID = 7, AttType = "RFID", AttTime = new DateTime(2024, 11, 1, 16, 15, 0) }
                );

            context.Logs.AddOrUpdate(l => l.ID,
                new Log { ID = 1, LogType = "INFO", Message = "System started.", LogTime = new DateTime(2024, 11, 1, 16, 15, 0) });

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
            }

        }
    }
}
