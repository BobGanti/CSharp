namespace ShopperApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Scan1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Owners");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ShoppingListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
