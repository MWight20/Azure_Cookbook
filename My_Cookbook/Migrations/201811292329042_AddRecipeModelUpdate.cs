namespace My_Cookbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipeModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Description", c => c.String());
            AddColumn("dbo.Recipes", "Directions", c => c.String());
            AddColumn("dbo.Recipes", "Ingredients", c => c.String());
            AddColumn("dbo.Recipes", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Recipes", "Rating");
            DropColumn("dbo.Recipes", "ReadyTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "ReadyTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "Rating", c => c.Int());
            DropColumn("dbo.Recipes", "UserID");
            DropColumn("dbo.Recipes", "Ingredients");
            DropColumn("dbo.Recipes", "Directions");
            DropColumn("dbo.Recipes", "Description");
        }
    }
}
