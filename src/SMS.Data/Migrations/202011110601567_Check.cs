namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Check : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Townships", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Townships", "Version", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Townships", "Version");
            DropColumn("dbo.Townships", "IsDelete");
        }
    }
}
