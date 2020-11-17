using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class EmailType
    {
        [Key]
        [Required]
        public Int64 idEmailType { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public Boolean? Active { get; set; }
        public DateTimeOffset InsDateTime { get; set; }
        public DateTimeOffset UpdDateTime{ get; set; }

    }
}
