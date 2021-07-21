using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.连接数据库
            string connectionSting = @"Data Source = (localdb)\MSSQLLocalDB; 
             Initial Catalog = 17bang;
             Integrated Security = True; ";
            using (SqlConnection connection = new SqlConnection(connectionSting))
            {
                connection.Open();
                //2.生成数据库对象
                string Id = Console.ReadLine();
                DbCommand command = new SqlCommand(
                    $"SELECT * FROM [User] WHERE Id=@Id;", connection);
                DbParameter Uid = new SqlParameter("@Id",Id);
                command.Parameters.Add(Uid);
                //command.Connection = connection;
                //command.CommandText = "SELECT * FROM [User];";
                //3.执行
                DbDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id={reader[0]},UserName={reader["UserName"]}," +
                            $"Password={reader[2]},ProfileId={reader[3]},InvitedBy={reader[4]}");
                    }
                }
            }









            //不使用using
            //DbConnection connection = new SqlConnection(connectionSting);
            //try
            //{
            //    connection.Open();
            //}
            //catch(Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    connection.Close();
            //}





        }
    }
}
