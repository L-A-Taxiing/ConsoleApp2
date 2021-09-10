using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLL.Repositories
{
    public class UserRepository:BaseRepository<User>
    {
        public UserRepository(SqlDbContext context):base(context)
        {

        }
        public User Find(int Id)
        {
            return dbset.Find(Id);
            //throw new NotImplementedException();

        }



        public User GetByName(string name)   //子类需要Context
        {
            //SqlDbContext context = new SqlDbContext();
            return dbset/*context.Set<User>()*/
                .Where(s => s.Name == name)
                .SingleOrDefault();



        }

    }
}
