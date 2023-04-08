namespace ShopperApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "ShoppingListId", c => c.Int(nullable: false));
            AddColumn("dbo.Owners", "User_Id", c => c.Int());
            CreateIndex("dbo.Owners", "User_Id");
            AddForeignKey("dbo.Owners", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Owners", "User_Id", "dbo.Users");
            DropIndex("dbo.Owners", new[] { "User_Id" });
            DropColumn("dbo.Owners", "User_Id");
            DropColumn("dbo.Owners", "ShoppingListId");
        }
    }
}
