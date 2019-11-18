namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myfirstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientDetails", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ClientDetails",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientAddresses", "ClientId", "dbo.ClientDetails");
            DropIndex("dbo.ClientAddresses", new[] { "ClientId" });
            DropTable("dbo.ClientDetails");
            DropTable("dbo.ClientAddresses");
        }
    }
}
