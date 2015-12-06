using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Entities
{
    public class Product : BaseModel
    {
        [Required(ErrorMessageResourceName = "validation_required_field", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "product_code", ResourceType = typeof(Resources.Resources))]
        [MaxLength(128, ErrorMessageResourceName = "validation_max_field_lenght", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string InternalCode { get; set;  }

        [Display(Name = "product_image", ResourceType = typeof(Resources.Resources))]
        public string ImagePath { get; set; }

        [Display(Name = "unit_price", ResourceType = typeof(Resources.Resources))]
        public double? UnitPrice { get; set; }
    }
}
