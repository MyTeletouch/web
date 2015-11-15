using MyTeletouch.Entities;
using MyTeletouch.Repositories.Intefraces;
using System.Linq;
using MyTeletouch.DBContexts;
using SharedStruct;
using System.Data.Entity.Migrations;
using System;

namespace MyTeletouch.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private class CountryLocaleRepository : RepositoryLocale<CountryText>
        {
            public CountryLocaleRepository() : base(new CountryDbContext())
            {

            }
        }

        private CountryDbContext _db;
        private readonly CountryLocaleRepository _dbLocaleRepository = new CountryLocaleRepository();

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
            System.Linq.Expressions.Expression<Func<CountryText, bool>> expresion = (c => c.CountryId == countryLocale.CountryId && c.Locale.Equals(countryLocale.Locale));
            _dbLocaleRepository.AddOrUpdateRecord(countryLocale, expresion);
        }

        public Country FindCountryByCountryCode(string countryCode)
        {
            Country dbCountry = _db.Countries
                .FirstOrDefault(c => c.CountryCode.Equals(countryCode));

            return dbCountry;
        }
    }
}