using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    internal class Suggest:Content,IAttitude
    {
        public Suggest(string _kind)
            : base(_kind)
        {

        }
        public Suggest()
        {

        }

        internal override void change()
        {
            Console.WriteLine("不需要消耗帮帮币");
        }
        public int Agreechange { get; set; }
        public int Disagreechange { get; set; }
        public void Agree(User Netfriend) 
        {
            Console.WriteLine("帮帮币增加");
            Netfriend.HelpPoint++;
            Author.HelpPoint++;
            Agreechange++;
        }

        public void Disagree(User Netfriend) 
        { 
            Console.WriteLine("帮帮币减少");
            Netfriend.HelpPoint--;
            Author.HelpPoint--;
            Disagreechange--;

        }

       public User Author { get; set; }


    }
}
