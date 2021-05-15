using Homework.OO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    internal class Article:Content,IAttitude
    {
        //public User Author { get; set; }

        public Article()
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

        //一篇文章可以有多个评论
        public IList<Comment<Article>> Comments { get; set; }


        //每个文章和评论都有一个评价
        public Appraise Appraise { get; set; }

        //一篇文章可以有多个关键字
        public IList<KeyWord> KeyWords { get; set; }
        public string Name { get; internal set; }
    }
}
//3.实例化文章和意见建议，调用他们:继承自父类的属性和方法;自己的属性和方法
