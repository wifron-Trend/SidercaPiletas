using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Context
{
    public class DbPoolDbContext:DbContext
    {
        public DbPoolDbContext(DbContextOptions<DbPoolDbContext>options):base(options)
        {

        }
        public DbSet<Email>Emails{ get; set; }
    }
}
