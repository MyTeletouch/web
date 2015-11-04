using MyTeletouch.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Repositories.Intefraces
{
    /// <summary>
    /// Get idea from http://www.asp.net/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/checkout-and-payment-with-paypal
    /// </summary>
    public interface IShoppingCartRepository
    {
        string ShoppingCartId { get; set; }

        void AddToCart(int id);

        void Dispose();

        string GetCartId();

        List<CartItem> GetCartItems();

        decimal GetTotal();

        void RemoveItem(string removeCartID, int removeProductID);

        void UpdateItem(string updateCartID, int updateProductID, int quantity);

        void EmptyCart();

        int GetCount();

        //MigrateCart(string cartId, string userName);
    }
}
