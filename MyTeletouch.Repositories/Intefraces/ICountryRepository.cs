using MyTeletouch.Entities;
using MyTeletouch.Entities.ViewModels.CountryViewModel;
using SharedStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Repositories.Intefraces
{
    public interface ICountryRepository
    {
        Country FindCountryByCountryCode(string countryCode);

        /// <summary>
        /// We try to insert country in database, if you country code doesn't exist.
        /// </summary>
        /// <param name="country"></param>
        /// <returns>Give us information for country database id.</returns>
        int AddCountry(CountryInfo country);

        void AddOrUpdateCountryLocale(CountryText countryLocale);

        /// <summary>
        /// Get all countries by locale and after that generate list with <seealso cref="CountryListItem"/>
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        IEnumerable<CountryListItem> GetCountryList(string locale);
    }
}
