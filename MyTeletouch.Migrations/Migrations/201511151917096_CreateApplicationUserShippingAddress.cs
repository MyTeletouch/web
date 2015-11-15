namespace MyTeletouch.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateApplicationUserShippingAddress : DbMigration
    {
        const string tableName = "dbo.ApplicationUserShippingAddresses";

        public override void Up()
        {
            CreateTable(
                tableName,
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    CountryId = c.Int(nullable: false),
                    PrimaryAddress = c.String(nullable: false, maxLength: 128),
                    SecondaryAddress = c.String(nullable: true, maxLength: 128),
                    City = c.String(nullable: false, maxLength: 50),
                    State = c.String(nullable: true, maxLength: 80),
                    ZIP = c.String(nullable: false, maxLength: 15),
                    PhoneNumber = c.String(nullable: false, maxLength: 20),
                    CreatedAt = c.DateTime(nullable: false, storeType: "datetime"),
                    UpdatedAt = c.DateTime(nullable: false, storeType: "datetime")
                })
             .PrimaryKey(t => t.Id);

            // UserId
            CreateIndex(tableName, "UserId");
            AddForeignKey(tableName, "UserId", "AspNetUsers", "Id");

            // CountryId
            CreateIndex(tableName, "CountryId");
            AddForeignKey(tableName, "CountryId", "Countries", "Id");
        }

        public override void Down()
        {
            // UserId
            DropIndex(tableName, "UserId");
            DropForeignKey(tableName, "UserId", "AspNetUsers");

            // CountryId
            DropIndex(tableName, "CountryId");
            DropForeignKey(tableName, "CountryId", "Countries");

            DropTable(tableName);
        }
    }
}
