namespace ShopperApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyOwner1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Owners", "User_Id", "dbo.Users");
            DropIndex("dbo.Owners", new[] { "User_Id" });
            AddColumn("dbo.Owners", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Owners", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Owners", "User_Id", c => c.Int());
            DropColumn("dbo.Owners", "UserId");
            CreateIndex("dbo.Owners", "User_Id");
            AddForeignKey("dbo.Owners", "User_Id", "dbo.Users", "Id");
        }
    }
}
