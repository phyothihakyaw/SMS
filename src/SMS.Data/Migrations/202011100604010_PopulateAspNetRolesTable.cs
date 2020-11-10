namespace SMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateAspNetRolesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES (1, 'Admin')");
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES (2, 'Branch Manager')");
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES (3, 'School Manager')");
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES (4, 'Staff')");
        }

        public override void Down()
        {
        }
    }
}
