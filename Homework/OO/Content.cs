using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{    internal /*abstract*/ class Content :Entity<int>      //思考之前的Content类，该将其抽象成抽象类还是接口？为什么？并按你的想法实现。
    {
        protected string kind { get; set; }  //Content中有一个字段：kind，记录内容的种类（problem/article/suggest等），只能被子类使用
        public Content(string _kind)         // 确保每个Content对象都有kind的非空值
        {
            if (_kind == null)   ////之前的Content类，其中的CreateTime（创建时间）和PublishTime（发布时间）都是只读的属性，
                                 //想一想他们应该在哪里赋值比较好，并完成相应代码
            {
                return;
            }
            else
            {
                _kind = kind;
            }
            
        }
        public Content(DateTime CreateTime)
        {
            this.CreateTime = DateTime.Now;
        }
        public DateTime CreateTime  { get; set; }//Content中的createTime，不能被子类使用，但只读属性PublishTime使用它为外部提供内容的发布时间
        public DateTime PublishTime { get; set; }

        private string _Title { get; set; }       //其他方法和属性请自行考虑，尽量贴近一起帮的功能实现     
        public User Author { get; set; }

        public Content()
        {

        }
       internal virtual void change()
        {
        
        }

        //1.确保文章（Article）的标题不能为null值，也不能为一个或多个空字符组成的字符串，而且如果标题前后有空格，也予以删除
        public string Title 
        {
            //get { return _Title; }
            //set
            //{
            //    _Title = value;
            //    if (string.IsNullOrWhiteSpace(value))
            //    {
            //        Console.WriteLine("标题不能为null值或者空字符串！");
            //        return;
            //    }
            //    else 
            //    {
            //        Console.WriteLine(value.Trim());
            //    }

            //}
            get;set;
        }
        //内容（Content）发布（Publish）的时候检查其作者（Author）是否为空，如果为空抛出“参数为空”异常
        public virtual void Publish()
        {
            if (this.Author.Name == null)
            {
                throw new ArgumentNullException("作者不能为空");
            }
        }




    }
}


