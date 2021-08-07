using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RazorPages.Entities;
using RazorPages.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            //用事务实现帮帮币出售的过程
            //卖方帮帮币足够，扣减数额后成功提交。
            //卖房帮帮币不够，事务回滚，买卖双方帮帮币不变。

            //SqlDbContext context = new SqlDbContext();
            //context.AddRange(
            //    new User
            //    {
            //        Name="fg",
            //        Password=1234,
            //        IsMale=true,
            //        BCredit=10,
            //        CreateTime=new DateTime(2021,10,10),
            //        EmailAddressId=2,
            //        HelpBean=50

            //    },
            //    new User 
            //    {
            //        Name = "fd",
            //        Password = 2345,
            //        IsMale = false,
            //        BCredit = 10,
            //        CreateTime = new DateTime(2021, 10, 11),
            //        EmailAddressId = 1,
            //        HelpBean = 20

            //    }
            //    );
            //context.SaveChanges();
            //using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        User fg = context.Users.Where(u => u.Name == "fg")
            //            .SingleOrDefault();
            //        fg.HelpBean -= 10;
            //        context.SaveChanges();
            //        transaction.Commit();

            //    }
            //    catch (Exception)
            //    {
            //        transaction.Rollback();
            //        throw;
            //    }


            //}









            //context.AddRange(
            //    new Suggest { Suggestions = "ErrorList" },
            //    new Paper { AuthorName = "李腾" },
            //    new Question { QuestionNum = 10 }

            //    );

            //context.SaveChanges();


            //利用Linq to EntityFramework，实现方法：
            //GetBy(IList < ProblemStatus > exclude, bool hasSummary, bool descByPublishTime)，
            //该方法可以根据输入参数：
            //1.IList<ProblemStatus> exclude：不显示（排除）某些状态的求助
            //2.bool hasSummary：只显示已有总结的求助（如果传入值为true的话）
            //3.bool descByPublishTime：按发布时间正序还是倒序

            //实现方法：GetMessage()，靠将消息列表：
            //1.所有未读在已读前面
            //2.未读和已读各自按生成时间排序

            //MessageRepository message = new MessageRepository();
            //IList<Message> messages = message.GetMessage();

            //ProblemRepository problem = new ProblemRepository();
            //IList<Problem> problems = problem.GetBy(new List<ProblemStatus> {ProblemStatus.canceled}, true, true);



            //SqlDbContext context = new SqlDbContext();
            //var db = context.Database;  //DataBase从何来

            ////Create数据库的同时建立表结构，
            //db.EnsureCreated();

            ////Enusure：存在才删除，不存在才创建
            //db.EnsureDeleted();

            //db.Migrate();
            //类似于Update-Database: apply all pending migrations
            //本身不生成Migrations



            //利用EF，插入3个User对象
            //SqlDbContext context = new SqlDbContext();
            //User user1= new User
            //{
            //    Name = "叶飞",
            //    Password = 1234,
            //    IsMale = true,
            //    BCredit = 12,
            //    CreateTime = new DateTime(2021, 7, 27)

            //};
            //User user2 = new User
            //{
            //    Name = "韩佳宝",
            //    Password = 2345,
            //    IsMale = true,
            //    BCredit = 20,
            //    CreateTime = new DateTime(2021, 7, 1)
            //};
            //User user3 = new User
            //{
            //    Name = "夏康平",
            //    Password = 3456,
            //    IsMale = true,
            //    BCredit = 25,
            //    CreateTime = new DateTime(2021, 8, 1)
            //};
            //context.Add(user1);
            //context.Add(user2);
            //context.Add(user3);

            //通过主键找到其中一个User对象
            //User user = context.Find<User>(2);

            //修改该User对象的Name属性，将其同步到数据库
            //user.Name = "李腾";



            //不加载User对象，仅凭其Id用一句Update SQL语句完成上题
            //User user = new User { Id = 1 };
            //context.Attach<User>(user);
            //user.Name = "马云";

            //User user = new User { Id = 1 };
            //user.Name = "马花藤";
            //user.CreateTime = new DateTime(2021, 7, 27);
            //context.Update<User>(user);




            //删除该用户
            //User user = context.Find<User>(3);
            //context.Remove<User>(user);

            //context.SaveChanges();




        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });






    }
}
