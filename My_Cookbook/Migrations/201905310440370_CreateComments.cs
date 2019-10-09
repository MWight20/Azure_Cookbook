namespace My_Cookbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(maxLength: 50),
                        Body = c.String(nullable: false),
                        PostId = c.Int(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Comments", new[] { "Recipe_Id" });
            DropTable("dbo.Comments");
        }
    }
}
