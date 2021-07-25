using RazorPages.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Repositories
{
    public class MessageRepository
    {

        private static IList<Message> messages;
        //static MessageRepository()
        //{
        //    messages = new List<Message>
        //    {
        //        new Message
        //        {
        //          Id=1,
        //          Content="你因为登录获得系统随机分配给你的 帮帮豆 2 枚，可用于感谢赞赏等。",
        //          CreateTime=DateTime.Now,
        //        },
        //        new Message
        //        {
        //          Id=2,
        //          Content="你因为登录获得系统随机分配给你的 帮帮豆 4 枚，可用于感谢赞赏等。",
        //          CreateTime=DateTime.Now.AddHours(3),
        //        },


        //    };
        //}
        public IList<Message> GetMine(bool onlyNotRead = false)
        {

            string querystr = $"SELECT * FROM Message";
            DBHelper helper = new DBHelper();
            IDbDataAdapter adapter = new SqlDataAdapter(querystr, helper.GetNewConnetion());
            DataSet Messages = new DataSet();
            adapter.Fill(Messages);
            //using (DbConnection connection = helper.GetNewConnetion())
            //{
            //connection.Open();
            //DbCommand command = new SqlCommand(
            //    $"SELECT [Id],Content,PublishDateTime FROM Message"
            //    );
            //command.Connection = connection;
            //DbDataReader reader = command.ExecuteReader();
            //reader.Read();
            if (onlyNotRead)
            {
                messages = new List<Message>();
                for (int i = 0; i < Messages.Tables[0].Rows.Count; i++)
                {
                    Message message = new Message();
                    message.Id = Convert.ToInt32(Messages.Tables[0].Rows[i]["Id"]);
                    message.Content = Convert.ToString(Messages.Tables[0].Rows[i]["Content"]);
                    message.PublishDateTime = Convert.ToDateTime(Messages.Tables[0].Rows[i]["PublishDateTime"]);
                    messages.Add(message);
                }
            }
            return messages;
            //var result = messages;
            //if (onlyNotRead)
            //{
            //    result = messages.Where(m => !m.HasRead).ToList();
            //}//else nothing
            //return result;
            //}
        }

        public Message Find(int id)
        {
            DBHelper helper = new DBHelper();
            using (DbConnection connection = helper.GetNewConnetion())
            {
                connection.Open();
                DbCommand command = new SqlCommand(
                    $"SELECT Id,Content,PublishDateTime FROM Message WHERE Id=@Id"
                    );
                command.Connection = connection;

                DbParameter PID = new SqlParameter("@Id", id);
                command.Parameters.Add(PID);
                DbDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                else
                {
                    Message message = new Message();
                    message.Id = Convert.ToInt32(reader[0]);
                    message.Content = Convert.ToString(reader[1]);
                    message.PublishDateTime = Convert.ToDateTime(reader[2]);
                    message.Read();
                    return message;
                }

            }
            //return messages.Where(m => m.Id == id).SingleOrDefault();
        }

    }
}
