namespace MyTeletouch.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductTextTable : DbMigration
    {
        const string tableName = "dbo.ProductTexts";

        public override void Up()
        {
            CreateTable(
                tableName,
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ProductId = c.Int(nullable: false),
                    Locale = c.String(nullable: false, maxLength: 2),
                    Name = c.String(nullable: false, maxLength: 128),
                    Slogon = c.String(nullable: false, maxLength: 255),
                    Description = c.String(nullable: true, storeType: "ntext"),
                    CreatedAt = c.DateTime(nullable: false, storeType: "datetime"),
                    UpdatedAt = c.DateTime(nullable: false, storeType: "datetime")
                })
             .PrimaryKey(t => t.Id);

            CreateIndex(tableName, "ProductId");
            AddForeignKey(tableName, "ProductId", "Products", "Id");
        }

        public override void Down()
        {
            DropIndex(tableName, "ProductId");
            DropForeignKey(tableName, "ProductId", "Products");

            DropTable(tableName);
        }
    }
}
