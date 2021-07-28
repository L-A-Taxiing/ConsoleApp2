using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RazorPages.Entities;
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
            SqlDbContext context = new SqlDbContext();
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


            context.SaveChanges();




        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });






    }
}
