using RazorPages.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Repositories
{
    public class UserRepository
    {
        DBHelper helper = new DBHelper();
        public void Save(User NewUser)
        {
            string UserName = NewUser.Name;
            string PassWord = NewUser.Password;
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; 
             Initial Catalog = 17bang;
             Integrated Security = True; ";
            using (DbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                DbCommand command = new SqlCommand(
                    $"INSERT [User](UserName,PassWord)Values(@UserName,@PassWord);"
                    );
                command.Connection = connection;
                DbParameter UName = new SqlParameter("@UserName", UserName);
                command.Parameters.Add(UName);

                DbParameter PWord = new SqlParameter("@PassWord", PassWord);
                command.Parameters.Add(PWord);

                DbDataReader reader = command.ExecuteReader();


            }



        }
        internal User GetByName(string name)
        {
            string UserName = name;
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; 
             Initial Catalog = 17bang;
             Integrated Security = True; ";
            using(DbConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                DbParameter UName = new SqlParameter("@Name", UserName);
                DbCommand command = new SqlCommand(
                    $"SELECT Id,UserName,PassWord FROM [User] WHERE UserName=@Name"
                    );
                command.Connection = connection;
                command.Parameters.Add(UName);
                DbDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                User user = new User();
                user.InvitedBy.Id = (int)reader["Id"];
                user.InvitedBy.Name = (string)reader["UserName"];
                return user;

            }
        }




        private static IList<User> users;

        static UserRepository()
        {
            users = new List<User>
            {
                new User
                {
                    Id=1,
                    Name="叶飞",
                    Password="1234"

                },
            };
        }

        internal IList<User> Get(int pageIndex, int pageSize)
        {
            return users.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public UserRepository()
        {

        }

        internal User Find(int id)
        {
            return users.Where(a => a.Id == id).SingleOrDefault();
        }

       

        void Delete()
        {

        }









    }
}
