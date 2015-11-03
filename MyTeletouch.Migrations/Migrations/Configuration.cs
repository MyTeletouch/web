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
            // Migrate countries
            var countryList = new CountryList();
            countryList.InsertCountries();
        }
    }
}
