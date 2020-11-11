namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBranchesTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CityId = c.Int(nullable: false),
                        TownshipId = c.Int(nullable: false),
                        FullAddress = c.String(nullable: false, maxLength: 200),
                        PhoneNo = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        CreatedUserId = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedUserId = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        Version = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Townships", "CreatedUserId", c => c.String(nullable: false));
            AlterColumn("dbo.Townships", "UpdatedUserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Townships", "UpdatedUserId", c => c.String());
            AlterColumn("dbo.Townships", "CreatedUserId", c => c.String());
            DropTable("dbo.Branches");
        }
    }
}
