﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTeletouch.Entities
{
    public class Country : BaseModel
    {
        public Country(string ExternalCountryCode)
        {
            this.CountryCode = ExternalCountryCode;
        }

        [Key]
        public int CountryId { get; set; }

        [Required]
        [Index("CountryCode", IsUnique = true)]
        public string CountryCode { get; set; }
    }
}