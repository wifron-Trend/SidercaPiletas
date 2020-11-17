using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Status
    {
        [Key]
        [Required]
        public int idStatus { get; set; }
        public string Name { get; set; }
        public Boolean? EmailAlert { get; set; }
        public Boolean? Active { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }
        public string Color { get; set; }


    }
}
