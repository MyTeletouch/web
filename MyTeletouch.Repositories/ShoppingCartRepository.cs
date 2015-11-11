using MyTeletouch.Entities;
using MyTeletouch.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeletouch.Repositories.Intefraces;
using System.Web;

namespace MyTeletouch.Repositories
{
    public class ShoppingCartRepository : Repository<CartItem>, IShoppingCartRepository
    {
        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        private ProductDbContext _db;

        public ShoppingCartRepository() : base(new ProductDbContext())
        {
            _db = dbSet as ProductDbContext;
        }

        /// <summary>
        /// Add a new product to Shopping Cart.
        /// If you product exist in shopping cart we only update quantity.
        /// Method will throw Exception if you product doesn't exist in database. 
        /// </summary>
        /// <param name="id"></param>
        public void AddToCart(int id)
        {
            // Retrieve from Session or create a new ShoppingCartId
            ShoppingCartId = GetCartId();

            var cartItem = _db.ShoppingCartItems.SingleOrDefault(c => c.CartId.Equals(ShoppingCartId) && c.ProductId == id);

            if (cartItem == null)
            {
                Product product = _db.Products.SingleOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    throw new Exception(string.Format("Product with '{0}' doesn't exist", id));
                }

                // Create a new cart item, if no cart item exists.
                cartItem = new CartItem
                {
                    Id = CartItem.GenerateItemId(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = product,
                    Quantity = 1
                };

                _db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity.
                cartItem.Quantity++;
            }

            _db.SaveChanges();
        }

        /// <summary>
        /// Destroy reference to <see cref="ProductDbContext"/>
        /// </summary>
        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        /// <summary>
        /// Method will generate a new session Session Cart Id, if you session is empty.
        /// </summary>
        /// <returns></returns>
        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        /// <summary>
        /// We get cartItems by specific <see cref="ShoppingCartId"/>
        /// </summary>
        /// <returns></returns>
        public List<CartItem> GetCartItems()
        {
            // Retrieve from Session or create a new ShoppingCartId
            ShoppingCartId = GetCartId();

            var items = _db.ShoppingCartItems.Where(c => c.CartId.Equals(ShoppingCartId)).ToList();

            return items;
        }

        /// <summary>
        /// Multiply product price by quantity of that product to get the current price for each of those products in the cart.  
        /// Sum all product price totals to get the cart total.   
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            // Retrieve from Session or create a new ShoppingCartId
            ShoppingCartId = GetCartId();

            decimal? total = decimal.Zero;
            total = (decimal?)(
                from cartItems in _db.ShoppingCartItems
                where cartItems.CartId.Equals(ShoppingCartId)
                select (cartItems.Quantity * cartItems.Product.UnitPrice)
            ).Sum();

            return total ?? decimal.Zero;
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {
            throw new NotImplementedException();
        }

        public void EmptyCart()
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void MigrateCart(string cartId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
