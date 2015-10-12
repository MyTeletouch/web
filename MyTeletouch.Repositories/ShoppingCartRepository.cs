using MyTeletouch.Entities;
using MyTeletouch.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeletouch.Repositories.Intefraces;

namespace MyTeletouch.Repositories
{
    public class ShoppingCartRepository : Repository<CartItem>, IShoppingCartRepository
    {
        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public ShoppingCartRepository() : base(new ProductDbContext())
        {
            
        }
    }
}
