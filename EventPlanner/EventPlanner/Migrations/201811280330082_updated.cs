namespace EventPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItemID = c.Int(nullable: false, identity: true),
                        MenuItemTitle = c.String(nullable: false),
                        MenuItemDescription = c.String(),
                        MenuitemNutrition = c.String(),
                        MenuItemIngredients = c.String(),
                        MenuItemQuantity = c.Int(nullable: false),
                        MenuItemCost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MenuItemID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuItems");
        }
    }
}
