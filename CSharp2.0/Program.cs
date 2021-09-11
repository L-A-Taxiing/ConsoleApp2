using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CSharp2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Student wxy = new Student();
            Console.WriteLine(wxy.GetType()
                .GetField("Name",
                BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(wxy)); 







        }
    }
}
