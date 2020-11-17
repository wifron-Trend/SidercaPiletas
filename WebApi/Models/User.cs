using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class User
    {
        [Key]
        [Required]
        public int idUser { get; set; }
        public string Identification { get; set; }
        public string Password { get; set; }
        public Boolean Active { get; set; }
        public DateTimeOffset InsDateTime { get; set; }
        public DateTimeOffset UpdDateTime { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}
