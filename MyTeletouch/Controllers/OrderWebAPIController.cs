using MyTeletouch.Entities;
using MyTeletouch.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MyTeletouch.Controllers
{
    public class OrderWebAPIController : ApiController
    {
        private ShoppingCartRepository _shoppingCartRepository = new ShoppingCartRepository();
        private ApplicationUserRepository _applicationUserRepository = new ApplicationUserRepository();

        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Create()
        {
            return this.Ok<bool>(true);
        }
    }
}
