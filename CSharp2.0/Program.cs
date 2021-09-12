using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CSharp2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student wxy = new Student();
            //Console.WriteLine(wxy.GetType()
            //    .GetField("Name",
            //    BindingFlags.NonPublic | BindingFlags.Instance)
            //    .GetValue(wxy));

            //IList<Student> student = new List<Student>
            //{
            //    new Student{Name="123"},
            //    new Student{Name="234"},
            //    new Student{Name="345"},
            //    new Student{Name="456"}
            //};
            foreach (var item in new Student())
            {
                Console.WriteLine(((Student)item).Name);
            }

        }





        
    }
}
