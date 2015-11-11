namespace MyTeletouch.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCountryTextTable : DbMigration
    {
        const string tableName = "dbo.CountryTexts";

        public override void Up()
        {
            CreateTable(
                tableName,
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CountryId = c.Int(nullable: false),
                    Locale = c.String(nullable: false, maxLength: 2),
                    Name = c.String(nullable: false, maxLength: 128),
                    CreatedAt = c.DateTime(nullable: false, storeType: "datetime"),
                    UpdatedAt = c.DateTime(nullable: false, storeType: "datetime")
                })
             .PrimaryKey(t => t.Id);

            CreateIndex(tableName, "CountryId");
            AddForeignKey(tableName, "CountryId", "Countries", "Id");
        }

        public override void Down()
        {
            DropIndex(tableName, "CountryId");
            DropForeignKey(tableName, "CountryId", "Countries");

            DropTable(tableName);
        }
    }
}
