namespace SMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateUserAndAddToAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO 
                [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                VALUES (N'a23d9c76-1c94-430a-9ef8-4e055de5f7ae', N'admin@demo.com', 0, N'ANQ66nngse6rznPt+2TPK9j2dkI09ynSAmbje9GFBL6uUkf4MMh8fvsMcXk2jwLO9A==', N'59dd8dea-9520-4c3a-ad7e-afc2f14a24a1', NULL, 0, 0, NULL, 1, 0, N'admin@demo.com')");

            Sql(@"INSERT INTO 
                [dbo].[AspNetUserRoles] ([UserId], [RoleId]) 
                VALUES (N'a23d9c76-1c94-430a-9ef8-4e055de5f7ae', N'1')");
        }

        public override void Down()
        {
        }
    }
}
