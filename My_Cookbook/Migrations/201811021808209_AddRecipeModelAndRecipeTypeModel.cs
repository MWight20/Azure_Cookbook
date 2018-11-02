namespace My_Cookbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipeModelAndRecipeTypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Rating = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        Type_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipeTypes", t => t.Type_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RecipeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipes", "Type_Id", "dbo.RecipeTypes");
            DropIndex("dbo.Recipes", new[] { "User_Id" });
            DropIndex("dbo.Recipes", new[] { "Type_Id" });
            DropTable("dbo.RecipeTypes");
            DropTable("dbo.Recipes");
        }
    }
}
