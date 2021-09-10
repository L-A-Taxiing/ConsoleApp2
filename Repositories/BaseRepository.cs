using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class BaseRepository<T> where T: Entities.BaseEntity
    {
        protected SqlDbContext<T> context;
        public BaseRepository()
        {
            context = new SqlDbContext<T>();
        }

        public int Save(T entity)
        {
            context.Entities.Add(entity);//EF必须点出dbset才能add
            return entity.Id;

        }

        public void Remove(T entity)
        {


        }



    }
}
