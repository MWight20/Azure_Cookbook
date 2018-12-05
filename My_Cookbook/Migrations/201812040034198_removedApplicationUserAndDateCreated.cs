namespace My_Cookbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedApplicationUserAndDateCreated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "User_Id" });
            AddColumn("dbo.Recipes", "Username", c => c.String());
            DropColumn("dbo.Recipes", "DateCreated");
            DropColumn("dbo.Recipes", "UserID");
            DropColumn("dbo.Recipes", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Recipes", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "DateCreated", c => c.DateTime());
            DropColumn("dbo.Recipes", "Username");
            CreateIndex("dbo.Recipes", "User_Id");
            AddForeignKey("dbo.Recipes", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
