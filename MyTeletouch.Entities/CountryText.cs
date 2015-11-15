using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTeletouch.Entities
{
    public class CountryText : BaseModel
    {
        [Required]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "")]
        public string Locale { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "")]
        public string Name { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}