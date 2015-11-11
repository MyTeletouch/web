using MyTeletouch.Entities;
using MyTeletouch.Repositories.Intefraces;
using System.Linq;
using MyTeletouch.DBContexts;
using SharedStruct;
using System.Data.Entity.Migrations;

namespace MyTeletouch.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private CountryDbContext _db;

        public CountryRepository() : base(new CountryDbContext())
        {
            _db = Context as CountryDbContext;
        }

        /// <summary>
        /// Try insert country in database, if you country code doesn't exist.
        /// </summary>
        /// <param name="country"></param>
        /// <returns>Give us information for country database id.</returns>
        public int AddCountry(CountryInfo country)
        {
            Country dbCountry = FindCountryByCountryCode(country.CountryCode);

            if (dbCountry == null)
            {
                var myDbCountry = new Country(country.CountryCode);
                this.Insert(myDbCountry);

                return myDbCountry.Id;
            }
            else
            {
                return dbCountry.Id;
            }
        }

        public void AddOrUpdateCountryLocale(CountryText countryLocale)
        {
            CountryText locale = _db.CountryLocales.FirstOrDefault(c => c.CountryId == countryLocale.CountryId && c.Locale.Equals(countryLocale.Locale));

            if (locale == null)
            {
                _db.CountryLocales.Add(countryLocale);
                this.Context.SaveChanges();
            }
        }

        public Country FindCountryByCountryCode(string countryCode)
        {
            Country dbCountry = _db.Countries
                .FirstOrDefault(c => c.CountryCode.Equals(countryCode));

            return dbCountry;
        }
    }
}