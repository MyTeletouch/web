using MyTeletouch.Entities;
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
        /// Try insert country in database, if you country code doesn't exist.
        /// </summary>
        /// <param name="country"></param>
        /// <returns>Give us information for country database id.</returns>
        int AddCountry(CountryInfo country);
    }
}
