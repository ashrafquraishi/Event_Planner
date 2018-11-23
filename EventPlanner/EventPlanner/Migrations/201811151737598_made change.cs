namespace EventPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madechange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventLocationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueName = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Capacity = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventOwnerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        ZipCode = c.Int(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        EventLocationModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventLocationModels", t => t.EventLocationModelId, cascadeDelete: true)
                .Index(t => t.EventLocationModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventOwnerModels", "EventLocationModelId", "dbo.EventLocationModels");
            DropIndex("dbo.EventOwnerModels", new[] { "EventLocationModelId" });
            DropTable("dbo.EventOwnerModels");
            DropTable("dbo.EventLocationModels");
        }
    }
}
