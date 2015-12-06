using MyTeletouch.DBContexts;
using MyTeletouch.Entities;
using MyTeletouch.Repositories.Intefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTeletouch.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private class ProductLocaleRepository : RepositoryLocale<ProductText>
        {
            public ProductLocaleRepository() : base(new ProductDbContext())
            {

            }
        }

        private ProductDbContext _db;
        private readonly ProductLocaleRepository _dbLocaleRepository = new ProductLocaleRepository();

        public ProductRepository() : base(new ProductDbContext())
        {
            _db = Context as ProductDbContext;
        }


    }
}