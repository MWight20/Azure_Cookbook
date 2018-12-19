namespace My_Cookbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredRecipeModelAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Directions", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String());
            AlterColumn("dbo.Recipes", "Directions", c => c.String());
            AlterColumn("dbo.Recipes", "Description", c => c.String());
        }
    }
}
