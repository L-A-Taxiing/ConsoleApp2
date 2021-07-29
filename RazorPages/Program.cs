using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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


            //����Linq to EntityFramework��ʵ�ַ�����
            //GetBy(IList < ProblemStatus > exclude, bool hasSummary, bool descByPublishTime)��
            //�÷������Ը������������
            //1.IList<ProblemStatus> exclude������ʾ���ų���ĳЩ״̬������
            //2.bool hasSummary��ֻ��ʾ�����ܽ���������������ֵΪtrue�Ļ���
            //3.bool descByPublishTime��������ʱ�������ǵ���

            //ʵ�ַ�����GetMessage()��������Ϣ�б�
            //1.����δ�����Ѷ�ǰ��
            //2.δ�����Ѷ����԰�����ʱ������

            MessageRepository message = new MessageRepository();
            IList<Message> messages = message.GetMessage();

            ProblemRepository problem = new ProblemRepository();
            IList<Problem> problems = problem.GetBy(new List<ProblemStatus> {ProblemStatus.canceled}, true, true);






























            //SqlDbContext context = new SqlDbContext();
            //var db = context.Database;  //DataBase�Ӻ���

            ////Create���ݿ��ͬʱ������ṹ��
            //db.EnsureCreated();

            ////Enusure�����ڲ�ɾ���������ڲŴ���
            //db.EnsureDeleted();

            //db.Migrate();
            //������Update-Database: apply all pending migrations
            //��������Migrations



            //����EF������3��User����
            //SqlDbContext context = new SqlDbContext();
            //User user1= new User
            //{
            //    Name = "Ҷ��",
            //    Password = 1234,
            //    IsMale = true,
            //    BCredit = 12,
            //    CreateTime = new DateTime(2021, 7, 27)

            //};
            //User user2 = new User
            //{
            //    Name = "���ѱ�",
            //    Password = 2345,
            //    IsMale = true,
            //    BCredit = 20,
            //    CreateTime = new DateTime(2021, 7, 1)
            //};
            //User user3 = new User
            //{
            //    Name = "�Ŀ�ƽ",
            //    Password = 3456,
            //    IsMale = true,
            //    BCredit = 25,
            //    CreateTime = new DateTime(2021, 8, 1)
            //};
            //context.Add(user1);
            //context.Add(user2);
            //context.Add(user3);

            //ͨ�������ҵ�����һ��User����
            //User user = context.Find<User>(2);

            //�޸ĸ�User�����Name���ԣ�����ͬ�������ݿ�
            //user.Name = "����";



            //������User���󣬽�ƾ��Id��һ��Update SQL����������
            //User user = new User { Id = 1 };
            //context.Attach<User>(user);
            //user.Name = "����";

            //User user = new User { Id = 1 };
            //user.Name = "����";
            //user.CreateTime = new DateTime(2021, 7, 27);
            //context.Update<User>(user);




            //ɾ�����û�
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
