namespace MyTeletouch.Migrations.Migrations
{
    using Seeds;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyTeletouch.DBContexts.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyTeletouch.DBContexts.ApplicationDbContext context)
        {
            // http://stackoverflow.com/questions/17169020/debug-code-first-entity-framework-migration-codes
            // Enable debugging for migrations
            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                System.Diagnostics.Debugger.Launch();
            }
                
            // Migrate countries
            var countryList = new CountryList();
            countryList.InsertCountries();
        }
    }
}
