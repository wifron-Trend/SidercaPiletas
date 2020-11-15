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
        [Required]
        public int idEmail{ get; set; }
        public string EmailAddress { get; set; }
        public Boolean? Active { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }

//[idEmail] [int] IDENTITY(1,1) NOT NULL,  
//[EmailAddress] [nvarchar] (150) NOT NULL,
//[Active] [bit] NULL,
//[InsDateTime] [datetimeoffset] (7) NULL,
//[UpdDateTime] [datetimeoffset] (7) NULL,
    }
}
