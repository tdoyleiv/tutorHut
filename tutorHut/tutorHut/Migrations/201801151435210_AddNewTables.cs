namespace tutorHut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        AddressId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        ProfileFirstName = c.String(),
                        ProfileLastName = c.String(),
                        ProfilePhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        DateAndTime = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Requests", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Profiles", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Profiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Profiles", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Requests", new[] { "SubjectId" });
            DropIndex("dbo.Requests", new[] { "AddressId" });
            DropIndex("dbo.Subjects", new[] { "UserId" });
            DropIndex("dbo.Profiles", new[] { "SubjectId" });
            DropIndex("dbo.Profiles", new[] { "AddressId" });
            DropIndex("dbo.Profiles", new[] { "UserId" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.Requests");
            DropTable("dbo.Subjects");
            DropTable("dbo.Profiles");
            DropTable("dbo.Addresses");
        }
    }
}
