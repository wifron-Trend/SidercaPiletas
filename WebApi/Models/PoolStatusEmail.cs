using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PoolStatusEmail
    {
        [Key]
        [Required]
        public int idPool { get; set; }
        public int idStatusEmailType { get; set; }
        public DateTimeOffset? LastEmail { get; set; }
        public Boolean SendEmail { get; set; }
    }
}
