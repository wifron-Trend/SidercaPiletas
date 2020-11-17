using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class StatusEmailType
    {
        [Key]
        [Required]
        public Int64 idStatusEmailType { get; set; }
        public int idStatus { get; set; }
        public int? idProperty { get; set; }
        public Int64 idEmailType { get; set; }
        public TimeSpan interval { get; set; }
        public int? idStatusNextPool { get; set; }

    }
}
