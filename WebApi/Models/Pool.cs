using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Pool
    {
        [Key]
        [Required]
        public int idPool { get; set; }
        public string Identification { get; set; }
        public Boolean? Active { get; set; }
        public int idStatus { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }
        public Boolean? SentEmail { get; set; }
        public DateTimeOffset? LastEmail { get; set; }
        public DateTimeOffset? DateTimeToAlarm { get; set; }

    }
}
