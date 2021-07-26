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

            SqlDbContext context = new SqlDbContext();
            var db = context.Database;  //DataBase从何来

            //Create数据库的同时建立表结构，
            db.EnsureCreated();

            //Enusure：存在才删除，不存在才创建
            db.EnsureDeleted();

            db.Migrate();
            //类似于Update-Database: apply all pending migrations
            //本身不生成Migrations






        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        



    }
}
