using MyTeletouch.Entities;
using System.Data.Entity;

namespace MyTeletouch.DBContexts
{
    public class OrderDbContext : ApplicationDbContext
    {
        // Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // Product
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductText> ProductLocales { get; set; }

        // User information
        public DbSet<ApplicationUserShippingAddress> ApplicationUserShippingAddresses { get; set; }

        // Shopping Basket
        public DbSet<CartItem> ShoppingCartItems { get; set; }
    }
}