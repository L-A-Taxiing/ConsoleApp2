using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    //声明一个委托：打水（ProvideWater），可以接受一个Person类的参数，返回值为int类型
    //使用：
    //方法
    //匿名方法
    //lambda表达式
    //给上述委托赋值，并运行该委托
    //声明一个方法GetWater()，该方法接受ProvideWater作为参数，并能将ProvideWater的返回值输出

    public delegate int ProvideWater(Person person);//声明委托
    public class Person
    {
        public string Name { get; set; }
        public static int SetValue(Person person)   //声明一个方法
        {
            person.Name = "不自由飞";
            return -1;
        }

        public int GetWater(ProvideWater provide)   //GetWater()方法
        {
            Person person = new Person();
            return provide(person);
        
        }

        public static void InvokeDelegate()        
        {
            ProvideWater provide = new ProvideWater(SetValue);//方法个委托赋值

            provide += delegate (Person person)               //匿名方法赋值
            {
                return -1;
            };

            provide += person => -1;                          //Lambda赋值

            provide(new Person());

        }








    }
}
