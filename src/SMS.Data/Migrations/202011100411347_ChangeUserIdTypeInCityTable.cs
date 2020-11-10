namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIdTypeInCityTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "CreatedUserId", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "UpdatedUserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cities", "UpdatedUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cities", "CreatedUserId", c => c.Int(nullable: false));
        }
    }
}
