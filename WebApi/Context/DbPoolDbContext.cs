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
        public DbSet<DataType> DataType { get; set; }
        public DbSet<Email> Email{ get; set; }
        public DbSet<EmailType> EmailType { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet <Pool> Pool { get; set; }
        public DbSet <PoolAction> PoolAction { get; set; }
        public DbSet<PoolActionHistory> PoolActionHistory { get; set; }
        public DbSet<PoolStatusEmail> PoolStatusEmail { get; set; }
        public DbSet<PoolStatusEmailHistory> PoolStatusEmailHistory { get; set; }

        public DbSet<PoolStatusProperties> PoolStatusProperties { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<StatusEmailType> StatusEmailType { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("Pool");
        }
    
        
       

       
    }
}
