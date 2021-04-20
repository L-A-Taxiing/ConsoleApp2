using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class Helpmoney
    {
        private DateTime Time { get; set; }
        private int Usable { get; set; }
        private int Frozen { get; set; }
        private string Kind { get; set; }
        private int Change { get; set; }
        private string Note { get; set; }

        //public static bool GetBbmoney() { }  
        public void frozen() { }
        public Helpmoney(string kind)            //调用
        {
            Console.WriteLine($"种类有:{kind}");
        }
        Helpmoney type = new Helpmoney("");
    }
}
//3. 帮帮币版块，定义一个类HelpMoney，表示一行帮帮币交易数据，包含你认为应该包含的字段和方法

