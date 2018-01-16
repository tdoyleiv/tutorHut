namespace tutorHut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.String(nullable: false, maxLength: 128),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        AddressId = c.String(maxLength: 128),
                        SubjectId = c.String(maxLength: 128),
                        RequestId = c.String(maxLength: 128),
                        ProfileFirstName = c.String(),
                        ProfileLastName = c.String(),
                        ProfilePhoneNumber = c.String(),
                        HourlyRate = c.String(),
                        MyDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Requests", t => t.RequestId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.SubjectId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.String(nullable: false, maxLength: 128),
                        DateAndTime = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.String(nullable: false, maxLength: 128),
                        EducationLevelId = c.String(maxLength: 128),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.EducationLevels", t => t.EducationLevelId)
                .Index(t => t.EducationLevelId);
            
            CreateTable(
                "dbo.EducationLevels",
                c => new
                    {
                        EducationLevelId = c.String(nullable: false, maxLength: 128),
                        LevelType = c.String(),
                    })
                .PrimaryKey(t => t.EducationLevelId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Profiles", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "EducationLevelId", "dbo.EducationLevels");
            DropForeignKey("dbo.Profiles", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Profiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Profiles", "AddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Subjects", new[] { "EducationLevelId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Profiles", new[] { "RequestId" });
            DropIndex("dbo.Profiles", new[] { "SubjectId" });
            DropIndex("dbo.Profiles", new[] { "AddressId" });
            DropIndex("dbo.Profiles", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.EducationLevels");
            DropTable("dbo.Subjects");
            DropTable("dbo.Requests");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Profiles");
            DropTable("dbo.Addresses");
        }
    }
}
