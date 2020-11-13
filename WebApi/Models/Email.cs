using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Email
    {
        [Key]
        public int idEmail{ get; set; }
        public string EmailAddress { get; set; }
        public Boolean Active { get; set; }

        public DateTimeOffset InsDateTime { get; set; }

        public DateTimeOffset UpdDateTime { get; set; }

    }
}
