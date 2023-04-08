namespace ShopperApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShopsToShopperLists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShopperLists", "ShopId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShopperLists", "ShopId");
            AddForeignKey("dbo.ShopperLists", "ShopId", "dbo.Shops", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopperLists", "ShopId", "dbo.Shops");
            DropIndex("dbo.ShopperLists", new[] { "ShopId" });
            DropColumn("dbo.ShopperLists", "ShopId");
        }
    }
}
