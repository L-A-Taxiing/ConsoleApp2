using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    internal class Article:Content,IAttitude
    {
        //public User Author { get; set; }

        public Article(string _kind,DateTime CreateTime)
            : base(_kind)
        {

        }

        internal override void change()
        {
            Console.WriteLine("需要消耗一个帮帮币");
        }

        

        public int Agreechange { get; set; }
        public int Disagreechange { get; set; }
        public void Agree(User Netfriend) 
        {
            Console.WriteLine("帮帮点增加");
            Netfriend.HelpPoint++;
            Author.HelpPoint++;
            Agreechange++;

        }

        public void Disagree(User Netfriend) 
        {
            Console.WriteLine("帮帮点减少");
            Netfriend.HelpPoint--;
            Author.HelpPoint--;
            Disagreechange--;
        }
        public User Author { get; set; }

    }
}
//3.实例化文章和意见建议，调用他们:继承自父类的属性和方法;自己的属性和方法
