using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class UserRepository:BaseRepository<User>
    {
        public User Find(int Id)
        {
            throw new NotImplementedException("");

        }



        public User GetByName(string name)   //子类需要Context
        {
            //SqlDbContext context = new SqlDbContext();
            return context.Entities
                .Where(s => s.Name == name)
                .SingleOrDefault();



        }

    }
}
