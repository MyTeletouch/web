﻿using ClientConfigurations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Entities
{
    public class Order : BaseModel
    {
        // Foreign Key
        [Required]
        [MaxLength(128, ErrorMessage = "Maximum length is {0} characters.")]
        public string UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = DateSettings.StandartDateFormat, ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public string PaymentTransactionId { get; set; }

        [ScaffoldColumn(false)]
        public bool HasBeenShipped { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
