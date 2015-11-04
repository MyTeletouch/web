using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Entities
{
    public class CartItem : BaseModel
    {
        [Key]
        public string ItemId { get; set; }

        // Foreign Key
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string CartId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public static string GenerateItemId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
