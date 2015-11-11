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
        // https://msdn.microsoft.com/en-us/library/51y09td4.aspx
        // new Modifier
        // Used to hide an inherited member from a base class member.
        [Key]
        public new string Id { get; set; }

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
    }
}
