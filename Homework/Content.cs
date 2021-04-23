using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    internal abstract class Content                //思考之前的Content类，该将其抽象成抽象类还是接口？为什么？并按你的想法实现。
    {
        protected string kind { get; set; }  //Content中有一个字段：kind，记录内容的种类（problem/article/suggest等），只能被子类使用
        public Content(string _kind)// 确保每个Content对象都有kind的非空值
        {
            if (_kind == null)
            {
                return;
            }
            else
            {
                _kind = kind;
            }

        }
       
        private DateTime createtime { get; set; }//Content中的createTime，不能被子类使用，但只读属性PublishTime使用它为外部提供内容的发布时间
        public DateTime PublishTime { get => createtime;}

        private string title { get; set; }                  //其他方法和属性请自行考虑，尽量贴近一起帮的功能实现     
        private User auther { get; set; }


       internal virtual void change()
        {
        
        }

        public Content()
        {

        }






    }
}
//观察一起帮的求助（Problem）、文章（Article）和意见建议（Suggest），根据他们的特点，抽象出一个父类：内容（Content）

//引入两个子类EmailMessage和DBMessage，和他们继承的接口ISendMessage（含Send()方法声明），用Console.WriteLine()实现Send()。
//一起帮还可以在好友间发私信，所有又有了IChat接口，其中也有一个Send()方法声明。假设User类同时继承了ISendMessage和IChat，如何处理？
