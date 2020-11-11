namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTownshipsTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Townships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedUserId = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedUserId = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Townships");
        }
    }
}
