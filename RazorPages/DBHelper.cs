using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages
{
    public class DBHelper
    {
        private const string connectionString= @"Data Source = (localdb)\MSSQLLocalDB; 
             Initial Catalog = 17bang;
             Integrated Security = True; ";
        public SqlConnection GetNewConnetion()
        {
            return new SqlConnection(connectionString);
        }

        private int ExecuteNonQuery(string cmdText, params IDataParameter[] parameters)
        {
            //using (DbConnection connection = GetNewConnetion())
            //{
            //    try
            //    {
            //        connection.Open();
                    DbCommand command = new SqlCommand(cmdText);
                    //command.Connection = connection;
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add(parameters[i]);
                    }
                    return ExecuteNonQuery(command);
                //}
            //    catch (Exception)
            //    {

            //        throw;
            //    }
               
            //}
        }
        private int ExecuteNonQuery(IDbCommand command)
        {
            using (DbConnection connection = GetNewConnetion())
            {
                try
                {
                    connection.Open();
                    //DbCommand command = new SqlCommand(cmdText);
                    command.Connection = connection;
                    //for (int i = 0; i < parameters.Length; i++)
                    //{
                    //    command.Parameters.Add(parameters[i]);
                    //}
                    return command.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public object Insert(string cmdText, params IDataParameter[] parameters)
        {
            return ExecuteNonQuery(cmdText,parameters);
        }
        public int Delete(string cmdText, params IDataParameter[] parameters)
        {
            return ExecuteNonQuery(cmdText,parameters);
        }
        public int Update(string cmdText, params IDataParameter[] parameters)
        {
            return ExecuteNonQuery(cmdText,parameters);

        }

        public object ExecuteScalar(string cmdText, params IDataParameter[] parameters)
        {
            DbCommand command = new SqlCommand();
            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.Add(parameters[i]);
            }
            return ExecuteScalar(command);

        }
        public object ExecuteScalar(IDbCommand command)
        {
            using(DbConnection connection=GetNewConnetion())
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    object result= command.ExecuteScalar();
                    return result;
                    //if (result==DBNull.Value)
                    //{
                    //    return null;
                    //}
                }
                catch (Exception)
                {

                    throw;
                }


            }

        }
    }
}
