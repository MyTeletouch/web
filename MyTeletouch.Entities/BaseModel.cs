using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Entities
{
    public class BaseModel
    {
        public BaseModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Key]
        public virtual int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime UpdatedAt { get; set; }

        public static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
