using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PoolAction
    {
        [Key]
        [Required]
        public int idPool { get; set; }
        public int idStatus { get; set; }
        public int idProperty{ get; set; }
        public string Value { get; set; }
        public DateTimeOffset? ValueDateTime { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }
        public int idUser { get; set; }
    }
}
