using MyTeletouch.DBContexts;
using MyTeletouch.Entities;
using MyTeletouch.Repositories.Intefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTeletouch.Repositories
{
    // public class CountryRepository : Repository<Country>, ICountryRepository

    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository()
        {
            _db = new ApplicationDbContext();
        }

        /// <summary>
        /// <see cref="IApplicationUserRepository.EmailIsUnique(emailAddress)"/>
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public bool EmailIsUnique(string emailAddress)
        {
            return true;
        }
    }
}