using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class MimicStack
    {
        //使用object改造数据结构栈（MimicStack），并在出栈时获得出栈元素
        public object[] database;
        static int top = 0;
        public MimicStack(int length)
        {
            database =new object[length];
        }    
        public void Push(object data)
        {
            if (top<=database.Length-1)
            {
                database[top] = data;
                top++;
            }
            else
            {
                Console.WriteLine("栈溢出"); 
            }
        }
        public void Pop(object data) 
        {
            if (top!=0)
            {
                top--;
                Console.WriteLine(database[top]); 
            }
            else
            {
                Console.WriteLine("栈已空"); 
            }
        }
    }
}
//自己实现一个模拟栈（MimicStack）类，入栈出栈数据均为int类型，包含如下功能
//出栈Pop();弹出栈顶数据;入栈Push();可以一次性压入多个数据;出/入栈检查，如果压入的数据已超过栈的深度（最大容量），提示“栈溢出”,如果已弹出所有数据，提示“栈已空”
