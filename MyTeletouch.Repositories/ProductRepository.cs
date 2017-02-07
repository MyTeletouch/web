using MyTeletouch.DBContexts;
using MyTeletouch.Entities;
using MyTeletouch.Repositories.Intefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharedStruct;
using MyTeletouch.Entities.ViewModels.ProductViewModel;

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

        /// <summary>
        /// <see cref="IProductRepository.AddProduct(ProductInfo)"/>
        /// </summary>
        /// <param name="country"></param>
        /// <returns>Give us information for product database id.</returns>
        public int AddProduct(ProductInfo product)
        {
            Product dbProduct = FindProductByInternalCode(product.ProductInternalCode);

            if (dbProduct == null)
            {
                var myDbProduct = new Product(product.ProductInternalCode, product.ProductUnitPrice);
                this.Insert(myDbProduct);

                return myDbProduct.Id;
            }
            else
            {
                return dbProduct.Id;
            }
        }

        public Product FindProductByInternalCode(string internalCode)
        {
            Product dbProduct = _db.Products
                .FirstOrDefault(p => p.InternalCode.Equals(internalCode));

            return dbProduct;
        }

        /// <summary>
        /// <see cref="IProductRepository.FindProductByLocaleAnFindProductByLocaleAndInternalCodedInternalCode(string, string)"/>
        /// 
        /// Ideas: 
        /// <seealso cref="http://stackoverflow.com/questions/5207382/get-data-from-two-tablesjoin-with-linq-and-return-result-into-view"/>
        /// <seealso cref="http://stackoverflow.com/questions/201830/linq-to-sql-firstordefault-not-applicable-to-select-new"/>
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="internalCode"></param>
        /// <returns></returns>
        public ProductViewModelItem FindProductByLocaleAnFindProductByLocaleAndInternalCodedInternalCode(string locale, string internalCode)
        {
            ProductViewModelItem dbProduct = (
                from c in _db.Products
                join l in _db.ProductLocales on c.Id equals l.ProductId
                where l.Locale.Equals(locale) && c.InternalCode == internalCode
                select new ProductViewModelItem
                {
                    Id = c.Id,
                    ImagePath = c.ImagePath,
                    UnitPrice = (c.UnitPrice.HasValue ? c.UnitPrice.Value : 0),
                    Name = l.Name
                }
            ).FirstOrDefault();

            return dbProduct;
        }

        public void AddOrUpdateProductLocale(ProductText productLocale)
        {
            System.Linq.Expressions.Expression<Func<ProductText, bool>> expresion =
                (p => p.ProductId == productLocale.ProductId && p.Locale.Equals(productLocale.Locale));

            _dbLocaleRepository.AddOrUpdateRecord(productLocale, expresion);
        }
    }
}