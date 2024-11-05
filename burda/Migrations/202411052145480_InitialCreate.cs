﻿namespace burda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                        AttType = c.String(maxLength: 50),
                        AttTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ClassRooms", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        ClassName = c.String(nullable: false, maxLength: 256),
                        LessonName = c.String(nullable: false, maxLength: 256),
                        ClassDate = c.DateTime(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        IsExam = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.TeacherID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        StudentID = c.String(maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 254),
                        ProgramName = c.String(nullable: false, maxLength: 100),
                        ProfileImage = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        ClassRoom_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoom_ID)
                .Index(t => t.RoleID)
                .Index(t => t.ClassRoom_ID);
            
            CreateTable(
                "dbo.RFIDCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RFIDNumber = c.String(nullable: false, maxLength: 50),
                        UserID = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.UserID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LogType = c.String(nullable: false, maxLength: 50),
                        Message = c.String(nullable: false),
                        LogTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "UserID", "dbo.Users");
            DropForeignKey("dbo.ClassRooms", "TeacherID", "dbo.Users");
            DropForeignKey("dbo.Users", "ClassRoom_ID", "dbo.ClassRooms");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.RFIDCards", "User_ID", "dbo.Users");
            DropForeignKey("dbo.RFIDCards", "UserID", "dbo.Users");
            DropForeignKey("dbo.Attendances", "ClassID", "dbo.ClassRooms");
            DropIndex("dbo.RFIDCards", new[] { "User_ID" });
            DropIndex("dbo.RFIDCards", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "ClassRoom_ID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.ClassRooms", new[] { "TeacherID" });
            DropIndex("dbo.Attendances", new[] { "ClassID" });
            DropIndex("dbo.Attendances", new[] { "UserID" });
            DropTable("dbo.Logs");
            DropTable("dbo.Roles");
            DropTable("dbo.RFIDCards");
            DropTable("dbo.Users");
            DropTable("dbo.ClassRooms");
            DropTable("dbo.Attendances");
        }
    }
}
