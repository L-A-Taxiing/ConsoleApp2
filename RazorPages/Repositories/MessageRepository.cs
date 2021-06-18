using RazorPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Repositories
{
    public class MessageRepository
    {

        private static IList<Message> messages;
        static MessageRepository()
        {
            messages = new List<Message>
            {
                new Message
                {
                  Id=1,
                  Content="你因为登录获得系统随机分配给你的 帮帮豆 2 枚，可用于感谢赞赏等。",
                  CreateTime=DateTime.Now,
                },
                new Message
                {
                  Id=2,
                  Content="你因为登录获得系统随机分配给你的 帮帮豆 4 枚，可用于感谢赞赏等。",
                  CreateTime=DateTime.Now.AddHours(3),
                },


            };
        }
        public IList<Message> GetMine()
        {
            return messages;
        }

        public Message Find(int id)
        {
            return messages.Where(m => m.Id == id).SingleOrDefault();
        }
    }
}
