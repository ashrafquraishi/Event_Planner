namespace EventPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItems", "CateringCompany", c => c.String());
            AddColumn("dbo.MenuItems", "EnterDishes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItems", "EnterDishes");
            DropColumn("dbo.MenuItems", "CateringCompany");
        }
    }
}
