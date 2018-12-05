namespace My_Cookbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeTypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
