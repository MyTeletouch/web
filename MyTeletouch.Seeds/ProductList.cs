using MyTeletouch.Entities;
using MyTeletouch.Repositories;
using MyTeletouch.Repositories.Intefraces;
using Resources;
using SharedStruct;
using System.Collections.Generic;

namespace MyTeletouch.Seeds
{
    public class ProductList
    {
        private readonly IProductRepository _dbRepository = new ProductRepository();

        public struct ProductLocaleList
        {
            public string Locale { get; set; }

            public List<ProductInfo> Products { get; set; }

            public ProductLocaleList(string InputLocale, List<ProductInfo> InputProducts)
            {
                this.Locale = InputLocale;
                this.Products = InputProducts;
            }
        }

        /// <summary>
        /// Method will insert only products, who don't exist in database.
        /// </summary>
        public void InsertProducts()
        {
            HashSet<string> locales = CultureHelper.GetSupportedLocales();
            List<ProductLocaleList> availableProducts = new List<ProductLocaleList>();

            foreach (var locale in locales)
            {
                // Get information for english speakers in our system
                if (locale.Equals("en"))
                {
                    List<ProductInfo> englishLocales = GenerateProductsForEnglishCulture();
                    availableProducts.Add(new ProductLocaleList(locale, englishLocales));
                }
            }

            InsertAvailableProducts(availableProducts);
        }

        private void InsertAvailableProducts(List<ProductLocaleList> availableProducts)
        {
            ProductText productLocale;
            foreach (ProductLocaleList productRowRecord in availableProducts)
            {
                // Insert for each locale product information.
                foreach (ProductInfo productInfo in productRowRecord.Products)
                {
                    productLocale = new ProductText();

                    // Insert product
                    productLocale.ProductId = _dbRepository.AddProduct(productInfo);
                    productLocale.Locale = productRowRecord.Locale;
                    productLocale.Name = productInfo.ProductName;
                    productLocale.Slogon = productInfo.ProductSlogon;
                    productLocale.Description = productInfo.ProductDescription;

                    _dbRepository.AddOrUpdateProductLocale(productLocale);
                }
            }
        }

        /// <summary>
        /// Generate list, who will be to use from English speakers in our system
        /// </summary>
        /// <returns></returns>
        private static List<ProductInfo> GenerateProductsForEnglishCulture()
        {
            List<ProductInfo> englishLocales = new List<ProductInfo>();

            englishLocales.Add(new ProductInfo(
                "MyTeletouch", // Internal Code 
                19.90, // Unit Price
                "MyTeletouch",  // Product Name
                "Take control in your hands!", // Product Slogon
                "The easiest way to turn your phones into universal controller for your smart devices.")); // Product Description

            return englishLocales;
        }
    }
}