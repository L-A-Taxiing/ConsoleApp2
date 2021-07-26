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
            var db = context.Database;  //DataBase�Ӻ���

            //Create���ݿ��ͬʱ������ṹ��
            db.EnsureCreated();

            //Enusure�����ڲ�ɾ���������ڲŴ���
            db.EnsureDeleted();

            db.Migrate();
            //������Update-Database: apply all pending migrations
            //��������Migrations






        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        



    }
}
