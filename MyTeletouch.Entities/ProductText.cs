using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTeletouch.Entities
{
    public class ProductText : BaseModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "")]
        public string Locale { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(10000, ErrorMessage = "")]
        public string Description { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}