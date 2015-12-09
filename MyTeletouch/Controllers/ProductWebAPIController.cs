using MyTeletouch.Entities;
using MyTeletouch.Entities.ViewModels.ProductViewModel;
using MyTeletouch.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MyTeletouch.Controllers
{
    public class ProductWebAPIController : ApplicationWebAPIController<Product>
    {
        private ProductRepository _productRepository;

        public ProductWebAPIController() : base(new ProductRepository())
        {
            _productRepository = repository as ProductRepository;
        }

        [ResponseType(typeof(ProductViewModelItem))]
        public async Task<IHttpActionResult> GetProductByInternalCode(string locale, string internalCode)
        {
            ProductViewModelItem dbProduct = _productRepository
                .FindProductByLocaleAnFindProductByLocaleAndInternalCodedInternalCode(locale, internalCode);

            if (dbProduct != null)
            {
                return this.Ok<ProductViewModelItem>(dbProduct);
            }
            else
            {
                return this.BadRequest("Record doesnt exist in our system");
            }
        }
    }
}