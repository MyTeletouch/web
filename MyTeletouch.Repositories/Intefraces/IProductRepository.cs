using MyTeletouch.Entities;
using MyTeletouch.Entities.ViewModels.ProductViewModel;
using SharedStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Repositories.Intefraces
{
    public interface IProductRepository
    {
        /// <summary>
        /// We try to insert product in databae, if you product internal code doesn't exist.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        int AddProduct(ProductInfo product);

        Product FindProductByInternalCode(string internalCode);

        /// <summary>
        /// Get Product information by internal code and locale and after that that generate list with <seealso cref="ProductViewModelItem"/>
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="internalCode"></param>
        /// <returns></returns>
        ProductViewModelItem FindProductByLocaleAnFindProductByLocaleAndInternalCodedInternalCode(string locale, string internalCode);

        void AddOrUpdateProductLocale(ProductText productLocale);
    }
}