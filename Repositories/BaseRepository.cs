using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLL.Repositories
{
    public class BaseRepository<T> where T: Entities.BaseEntity,new()//必须有构造函数
    {
        protected SqlDbContext context;

        protected DbSet<T> dbset;

        public BaseRepository(SqlDbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }

        public int Save(T entity)
        {
            //context.Set<T>().Add(entity);
            ////context.Entities.Add(entity);//EF必须点出dbset才能add
            //context.SaveChanges();
            dbset.Add(entity);
            context.SaveChanges();
            return entity.Id;

        }

        public void Remove(T entity)
        {


        }

        public T LoadProxy(int id)
        {

            T entity = new T { Id = id };
            dbset.Attach(entity);
            return entity;

        }

    }
}
