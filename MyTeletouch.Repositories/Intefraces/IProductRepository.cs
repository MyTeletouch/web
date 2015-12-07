using MyTeletouch.Entities;
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
        Product FindProductByInternalCode(string internalCode);

        /// <summary>
        /// We try to insert product in databae, if you product internal code doesn't exist.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        int AddProduct(ProductInfo product);

        void AddOrUpdateProductLocale(ProductText productLocale);
    }
}