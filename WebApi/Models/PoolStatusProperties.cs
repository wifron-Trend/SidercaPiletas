using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PoolStatusProperties
    {
        [Key]
        [Required]
        public int idStatus { get; set; }
        public int idPool { get; set; }
        public int idProperty { get; set; }
        public Boolean? Active { get; set; }
        public string Value { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }
        public Boolean IsCountDown { get; set; }

    }
}
