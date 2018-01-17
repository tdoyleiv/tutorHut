namespace tutorHut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableaddressid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Profiles", new[] { "AddressId" });
            AlterColumn("dbo.Profiles", "AddressId", c => c.Int());
            CreateIndex("dbo.Profiles", "AddressId");
            AddForeignKey("dbo.Profiles", "AddressId", "dbo.Addresses", "AddressId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Profiles", new[] { "AddressId" });
            AlterColumn("dbo.Profiles", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Profiles", "AddressId");
            AddForeignKey("dbo.Profiles", "AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
    }
}
