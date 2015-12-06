using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedStruct
{
    public class ProductInfo
    {
        public string ProductInternalCode { get; set; }

        public double ProductUnitPrice { get; set; }

        public string ProductName { get; set;  }

        public string ProductSlogon { get; set; }

        public string ProductDescription { get; set; }

        public ProductInfo(string InternalCode, double UnitPrice, string Name, string Slogon, string Description)
        {
            this.ProductInternalCode = InternalCode;
            this.ProductUnitPrice = UnitPrice;
            this.ProductName = Name;
            this.ProductSlogon = Slogon;
            this.ProductDescription = Description;
        }
    }
}
