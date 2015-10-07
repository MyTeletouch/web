﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Entities
{
    class BaseModel
    {
        public BaseModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
