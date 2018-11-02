namespace My_Cookbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fb4de172-ef4e-46b9-9f9a-4d27f07969e1', N'Admin@Admin.com', 0, N'AKBywAEHnVY4rjna07qIn1w5xMTItym6mWAKyWzGHwVKLg8jrmFsugN9oU/nDilEbg==', N'ecff17e0-aeef-4616-bc1a-52fa0af197e3', NULL, 0, 0, NULL, 1, 0, N'Admin')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1fde7f03-fe1c-4e94-be70-243da385e84d', N'isAdmin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb4de172-ef4e-46b9-9f9a-4d27f07969e1', N'1fde7f03-fe1c-4e94-be70-243da385e84d')


");
        }
        
        public override void Down()
        {
        }
    }
}
