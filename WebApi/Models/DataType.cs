using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class DataType
    {
        [Key]
        [Required]
        public int idDataType { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Boolean? Active { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        

    }
}
