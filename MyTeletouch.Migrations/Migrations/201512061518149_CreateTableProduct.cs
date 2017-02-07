namespace MyTeletouch.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableProduct : DbMigration
    {
        const string tableName = "dbo.Products";

        public override void Up()
        {
            CreateTable(
                tableName,
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    InternalCode = c.String(nullable: false, maxLength: 128),
                    ImagePath = c.String(nullable: true, maxLength: 255),
                    UnitPrice = c.Double(nullable: true, defaultValue: 0),
                    CreatedAt = c.DateTime(nullable: false, storeType: "datetime"),
                    UpdatedAt = c.DateTime(nullable: false, storeType: "datetime")
                })
             .PrimaryKey(t => t.Id);

            // http://stackoverflow.com/questions/13070431/unique-constraint-with-entity-framework-using-code-first-migrations
            CreateIndex(tableName, "InternalCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex(tableName, "ProductInternalCode");

            DropTable(tableName);
        }
    }
}
