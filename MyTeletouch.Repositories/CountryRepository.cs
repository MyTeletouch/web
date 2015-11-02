using MyTeletouch.Entities;
using MyTeletouch.Repositories.Intefraces;
using System.Linq;
using MyTeletouch.DBContexts;
using SharedStruct;

namespace MyTeletouch.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private CountryDbContext _db;

        public CountryRepository() : base(new CountryDbContext())
        {
            _db = dbSet as CountryDbContext;
        }

        /// <summary>
        /// Try insert country in database, if you country code doesn't exist.
        /// </summary>
        /// <param name="country"></param>
        /// <returns>Give us information for country database id.</returns>
        public int AddCountry(CountryInfo country)
        {
            var dbCountry = _db.Countries
                .FirstOrDefault(c => c.CountryCode.Equals(country.CountryCode));

            if (dbCountry == null)
            {
                var myDbCountry = new Country(country.CountryCode);
                this.Insert(myDbCountry);

                return dbCountry.CountryId;
            }
            else
            {
                return dbCountry.CountryId;
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