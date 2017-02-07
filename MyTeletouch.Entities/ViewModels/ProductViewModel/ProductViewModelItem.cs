using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTeletouch.Entities.ViewModels.ProductViewModel
{
    public class ProductViewModelItem
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public double UnitPrice { get; set; }

        public string Name { get; set; }
    }
}