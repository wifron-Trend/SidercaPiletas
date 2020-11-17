using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PoolStatusEmailHistory
    {
        [Key]
        [Required]
        public Int64 idPoolStatusEmailHistory { get; set; }
        public int idPool { get; set; }
        public Int64 idStatusEmailType { get; set; }
        public DateTimeOffset? LastEmail { get; set; }
    }
}
