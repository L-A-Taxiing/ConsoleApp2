using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    //引入两个子类EmailMessage和DBMessage，和他们继承的接口ISendMessage（含Send()方法声明），用Console.WriteLine() 实现Send()。
    interface ISendMessage
    {
        void Send();

    }
}
