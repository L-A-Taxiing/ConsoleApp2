using System;
using System.Collections.Generic;
using System.Text;
using static Homework.Program;

namespace Homework
{
    internal class Problem:Content
    {
        private string _title { get; set; }
        private string _body  { get; set; }
        private DateTime _publishDateTime { get; set; }
        private User _auther { get; set; }

        //public void Publish() { }

       
       


        private int _reward;//problem.Reward不能为负数
        public int Reward 
        {
            get { return _reward; }
            set 
            {
                if (_reward < 0)
                {
                    throw new ArgumentOutOfRangeException("悬赏不能为负");
                }
                else
                {
                    _reward = value;
                }
            }
        }
        //一起帮的求助可以有多个（最多10个）关键字，请为其设置索引器，以便于我们通过其整数下标进行读写
        private string[] _keywords = new string[10];
        public string this[int index]
        {
            get { return _keywords[index - 1]; }
            set {_keywords[index - 1] = value; }
        }
        

        [HelpMoneyChanged(100)]
        public void Publish()     //发布一篇求助，并将其保存到数据库
        {
            _auther.HelpMoney--;
        
        }    
        internal void Load(int Id) { }  //根据Id从数据库获取一条求助
        internal void Delete(int Id) { }  //根据Id删除某个求助

        static Repoistory repoistory;    //可用于在底层实现上述方法和数据库的连接操作等


        internal override void change()
        {
            Console.WriteLine("需要消耗其设置悬赏数量的帮帮币");
        }



    }
}
