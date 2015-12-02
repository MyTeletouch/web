using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Resources;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTeletouch.Entities
{
    /// <summary>
    /// Current Entity follow Amazon policy for Shipping Address
    /// </summary>
    [Table("ApplicationUserShippingAddresses")]
    public class ApplicationUserShippingAddress : BaseModel
    {
        // Foreign Key
        [Required]
        public string UserId { get; set; }

        // Foreign Key
        [Required]
        public int CountryId { get; set; }

        [Required(ErrorMessageResourceName = "validation_required_field", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "primary_address", ResourceType = typeof(Resources.Resources))]
        [MaxLength(128, ErrorMessageResourceName = "validation_max_field_lenght", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string PrimaryAddress { get; set; }

        [Display(Name = "secondary_address", ResourceType = typeof(Resources.Resources))]
        [MaxLength(128, ErrorMessageResourceName = "validation_max_field_lenght", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string SecondaryAddress { get; set;  }

        [Required(ErrorMessageResourceName = "validation_required_field", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "city", ResourceType = typeof(Resources.Resources))]
        [MaxLength(50, ErrorMessageResourceName = "validation_max_field_lenght", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string City { get; set; }

        [Display(Name = "state_province_region", ResourceType = typeof(Resources.Resources))]
        [MaxLength(80, ErrorMessageResourceName = "validation_max_field_lenght", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string State { get; set; }

        [Required(ErrorMessageResourceName = "validation_required_field", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "zip", ResourceType = typeof(Resources.Resources))]
        [MaxLength(15, ErrorMessageResourceName = "validation_max_field_lenght", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string ZIP { get; set; }

        [Required(ErrorMessageResourceName = "validation_required_field", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "phone_number", ResourceType = typeof(Resources.Resources))]
        [MaxLength(20, ErrorMessageResourceName = "validation_max_field_lenght", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string PhoneNumber { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}