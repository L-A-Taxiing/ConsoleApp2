using Microsoft.EntityFrameworkCore;
using RazorPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages
{
    public class SqlDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB; 
             Initial Catalog = 18bang;
             Integrated Security = True; ";
            optionsBuilder.UseSqlServer(conStr);
            base.OnConfiguring(optionsBuilder);
        }

      
    }
}
