using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Message> Messages { get; set; }
        //public DbSet<Article> Articles { get; set; }
        //public DbSet<Entity> Entities { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Suggest> Suggests { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB; 
             Initial Catalog = 18bang;
             Integrated Security = True; ";
            optionsBuilder.UseSqlServer(conStr)

#if DEBUG
                 .EnableSensitiveDataLogging(true)
#endif
                //.LogTo(
                //(id, level) => level == LogLevel.Debug,
                //log => Console.WriteLine(log)
                //)
                ;
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(U =>
            //{
            //    //U.ToTable("User");
            //    //U.Property("Name").HasColumnName("UserName");
            //    //U.Property(u => u.Name).HasMaxLength(256);
            //    ////U.HasKey(u => u.Name);
            //    ////U.Ignore(u => u.Id);
            //    //U.Ignore(u => u.InvitedBy);
            //    //U.Ignore(u => u.FailedTry);
            //    //U.HasIndex(u => u.CreateTime).IsUnique();
            //    //U.HasCheckConstraint("CK_CreateTime", "CreateTime>'2020-1-1'");
            //    //U.HasKey(u => u.Id);

            //    //U.HasOne<Email>(u => u.EmailAddress)
            //    //.WithOne(e => e.Owner)
            //    //.HasForeignKey<User>(u => u.EmailAddressId);
            //});


        }
    }
}
