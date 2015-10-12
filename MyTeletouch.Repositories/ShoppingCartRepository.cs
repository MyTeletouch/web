using MyTeletouch.Entities;
using MyTeletouch.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Repositories
{
    public class ShoppingCartRepository : Repository<CartItem>
    {
        public ShoppingCartRepository() : base(new ProductDbContext())
        {
        }
    }
}
