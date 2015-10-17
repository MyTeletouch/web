using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTeletouch.Entities
{
    public class Country : BaseModel
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public int CountryCode { get; set; }
    }
}