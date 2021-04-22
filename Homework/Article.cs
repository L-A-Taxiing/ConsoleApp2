using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    internal class Article:Content
    {

        //public Article(string _kind)
        //    : base(_kind)
        //{

        //}

        internal override void change()
        {
            Console.WriteLine("需要消耗一个帮帮币");
        }





    }
}
//3.实例化文章和意见建议，调用他们:继承自父类的属性和方法;自己的属性和方法
