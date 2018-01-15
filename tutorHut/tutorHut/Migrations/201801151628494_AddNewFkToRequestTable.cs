namespace tutorHut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFkToRequestTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "ProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "ProfileId");
            AddForeignKey("dbo.Requests", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Requests", new[] { "ProfileId" });
            DropColumn("dbo.Requests", "ProfileId");
        }
    }
}
