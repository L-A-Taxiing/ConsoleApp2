using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    class SqlDbContext:DbContext
    {
        public SqlDbContext():base("21bang")
        {

        }
        public DbSet<Student> Students { get; set; }


    }
}
