using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class StudentRepository
    {
        public Student Find(int Id)
        {
            throw new NotImplementedException("");

        }
        public Student GetByName(string name)
        {
            SqlDbContext context = new SqlDbContext();
            return context.Students
                .Where(s => s.Name == name)
                .SingleOrDefault();



        }

        public int Save(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
