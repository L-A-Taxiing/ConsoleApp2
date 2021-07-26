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

        //public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB; 
             Initial Catalog = 18bang;
             Integrated Security = True; ";
            optionsBuilder.UseSqlServer(conStr);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(U =>
            {
                U.ToTable("Register");
                U.Property(u => u.Name).HasColumnName("UserName");
                U.Property(u => u.Name).HasMaxLength(256);
                U.Property(u => u.Password).IsRequired();
                U.HasKey(u => u.Name);
                U.Ignore(u => u.FailedTry);
                U.HasIndex(u => u.CreateTime).IsUnique();
                U.HasCheckConstraint("CK_CreateTime", "CreateTime>2020-1-1");

            });



            base.OnModelCreating(modelBuilder);
        }
    }
}
