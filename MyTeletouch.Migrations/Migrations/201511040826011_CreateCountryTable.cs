namespace MyTeletouch.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCountryTable : DbMigration
    {
        const string tableName = "dbo.Countries";

        public override void Up()
        {
            CreateTable(
                tableName,
                c => new
                {
                    CountryId = c.Int(nullable: false, identity: true),
                    CountryCode = c.String(nullable: false, maxLength: 2),
                    CreatedAt = c.DateTime(nullable: false, storeType: "datetime"),
                    UpdatedAt = c.DateTime(nullable: false, storeType: "datetime")
                })
             .PrimaryKey(t => t.CountryId);

            // http://stackoverflow.com/questions/13070431/unique-constraint-with-entity-framework-using-code-first-migrations
            CreateIndex(tableName, "CountryCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex(tableName, "CountryCode");

            DropTable(tableName);
        }
    }
}
