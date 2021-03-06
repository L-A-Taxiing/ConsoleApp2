using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class MimicStack<T>
    {
        //使用object改造数据结构栈（MimicStack），并在出栈时获得出栈元素
        public static T[] database;           //声明一个用来装的数组
        static int top = 0;             
        public MimicStack(int length)
        {
            database =new T [length];         //数组长度
        }    
        public int Push(T data)              //单个数据压入
        {
            if (top<=database.Length-1)
            {
                database[top] = data;
                top++;
                return top;
            }
            else
            {
                Console.WriteLine("栈溢出");
                return -1; 
            }
        }
        public void Push(T[] Array)               //多个数据压入
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Push(Array[i]);
            }
        }
        public bool Pop( out T element)             //压出
        {
            if (top>0)
            {
                top--;
                element= database[top];
                return true;
            }
            else
            {
                element = default(T);
                return false;
            }
        }
    }
}
//自己实现一个模拟栈（MimicStack）类，入栈出栈数据均为int类型，包含如下功能
//出栈Pop();弹出栈顶数据;入栈Push();可以一次性压入多个数据;出/入栈检查，如果压入的数据已超过栈的深度（最大容量），提示“栈溢出”,如果已弹出所有数据，提示“栈已空”
