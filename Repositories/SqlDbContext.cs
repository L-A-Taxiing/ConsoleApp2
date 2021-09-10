using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class SqlDbContext<T> : SqlDbContext where T : BaseEntity
    {
        public DbSet<T> Entities { get; set; }

    }
    public class SqlDbContext : DbContext
    {
        public SqlDbContext() : base("21bang")
        {

        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Article> Articles { get; set; }
        //如果这样写就会让所有的仓库都乱了

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Article>(); 

            base.OnModelCreating(modelBuilder);
        }


    }
}
       




