using MyTeletouch.Entities;
using MyTeletouch.Entities.ViewModels.CountryViewModel;
using MyTeletouch.Repositories;
using SharedStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyTeletouch.Controllers
{
    public class CountryWebAPIController : ApplicationWebAPIController<Country>
    {
        private CountryRepository _countryRepository;
    
        public CountryWebAPIController() : base(new CountryRepository())
        {
            _countryRepository = repository as CountryRepository;
        }

        /// <summary>
        /// Route: api/CountryWebAPI/GetCountryList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CountryListItem> GetCountryList()
        {
            string currrentLocale = "en";
            IEnumerable<CountryListItem> countries = _countryRepository.GetCountryList(currrentLocale);

            return countries;
        }
    }
}
