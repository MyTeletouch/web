using MyTeletouch.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyTeletouch.DBContexts
{
    public class CountryDbContext : ApplicationDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryText> CountryLocales { get; set; }
    }
}