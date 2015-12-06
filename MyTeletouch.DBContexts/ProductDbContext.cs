using MyTeletouch.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.DBContexts
{
    public class ProductDbContext : ApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductText> ProductLocales { get; set;  }

        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
