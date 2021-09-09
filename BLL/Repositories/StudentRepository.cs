using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class StudentRepository
    {
        public Student Find(int id)
        {

            throw new NotImplementedException();

        }

        public Student GetByName(string name)
        {
            //IDataReader reader = new StudentFascade().GetByName(name);
            //Student student = new Student();
            //while (reader.Read())
            //{
            //    student.Score = (double)reader["Score"];
            //}
            //return student;




        }





    }
}
