namespace ShopperApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShopperLists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopperLists",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ListId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopperLists", "UserId", "dbo.Users");
            DropIndex("dbo.ShopperLists", new[] { "UserId" });
            DropTable("dbo.ShopperLists");
        }
    }
}
