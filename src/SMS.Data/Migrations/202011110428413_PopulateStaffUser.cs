namespace SMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateStaffUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] 
                ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                VALUES (N'eaee1405-55f5-4795-9a42-fb7b3ff2e6a1', N'staff@demo.com', 0, N'AO8HDPJazHDRTUcIAPDFBlhtV/vvWH1OGSeEM55l8pX3qCLEcoKFGAAhUIH4pC5+3g==', N'e93a21c9-0c93-42c2-8261-12eedaf64e7a', NULL, 0, 0, NULL, 1, 0, N'staff@demo.com')");
        }

        public override void Down()
        {
        }
    }
}
