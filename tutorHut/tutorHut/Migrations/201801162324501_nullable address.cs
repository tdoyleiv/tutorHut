namespace tutorHut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableaddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Profiles", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "EducationLevelId", "dbo.EducationLevels");
            DropIndex("dbo.Profiles", new[] { "SubjectId" });
            DropIndex("dbo.Profiles", new[] { "RequestId" });
            DropIndex("dbo.Subjects", new[] { "EducationLevelId" });
            AlterColumn("dbo.Profiles", "SubjectId", c => c.Int());
            AlterColumn("dbo.Profiles", "RequestId", c => c.Int());
            AlterColumn("dbo.Subjects", "EducationLevelId", c => c.Int());
            CreateIndex("dbo.Profiles", "SubjectId");
            CreateIndex("dbo.Profiles", "RequestId");
            CreateIndex("dbo.Subjects", "EducationLevelId");
            AddForeignKey("dbo.Profiles", "RequestId", "dbo.Requests", "RequestId");
            AddForeignKey("dbo.Profiles", "SubjectId", "dbo.Subjects", "SubjectID");
            AddForeignKey("dbo.Subjects", "EducationLevelId", "dbo.EducationLevels", "EducationLevelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "EducationLevelId", "dbo.EducationLevels");
            DropForeignKey("dbo.Profiles", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Profiles", "RequestId", "dbo.Requests");
            DropIndex("dbo.Subjects", new[] { "EducationLevelId" });
            DropIndex("dbo.Profiles", new[] { "RequestId" });
            DropIndex("dbo.Profiles", new[] { "SubjectId" });
            AlterColumn("dbo.Subjects", "EducationLevelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "RequestId", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "EducationLevelId");
            CreateIndex("dbo.Profiles", "RequestId");
            CreateIndex("dbo.Profiles", "SubjectId");
            AddForeignKey("dbo.Subjects", "EducationLevelId", "dbo.EducationLevels", "EducationLevelId", cascadeDelete: true);
            AddForeignKey("dbo.Profiles", "SubjectId", "dbo.Subjects", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.Profiles", "RequestId", "dbo.Requests", "RequestId", cascadeDelete: true);
        }
    }
}
