namespace EventPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeasingleModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventOwnerModels", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventOwnerModels", "EventLocationModelId", "dbo.EventLocationModels");
            DropIndex("dbo.EventOwnerModels", new[] { "EventLocationModelId" });
            DropIndex("dbo.EventOwnerModels", new[] { "ApplicationUserId" });
            DropTable("dbo.EventLocationModels");
            DropTable("dbo.EventOwnerModels");
            DropTable("dbo.MenuItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItemID = c.Int(nullable: false, identity: true),
                        CateringCompany = c.String(),
                        MenuItemTitle = c.String(nullable: false),
                        MenuItemDescription = c.String(),
                        MenuitemNutrition = c.String(),
                        MenuItemIngredients = c.String(),
                        MenuItemQuantity = c.Int(nullable: false),
                        MenuItemCost = c.Single(nullable: false),
                        EnterDishes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuItemID);
            
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
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateIndex("dbo.EventOwnerModels", "ApplicationUserId");
            CreateIndex("dbo.EventOwnerModels", "EventLocationModelId");
            AddForeignKey("dbo.EventOwnerModels", "EventLocationModelId", "dbo.EventLocationModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EventOwnerModels", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
