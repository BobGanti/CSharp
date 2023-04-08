namespace ShopperApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShopNameToProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ShopName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ShopName");
        }
    }
}
