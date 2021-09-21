using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using static CSharp2._0.Enumrator;

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

            //1.实现乘法口诀表，正向和反向;
            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 9; j >= i; j--)
            //    {
            //        Console.Write("{0}*{1}={2}\t", i, j, i * j);
            //    }
            //    Console.WriteLine();
            //}

            //2.实现1-100排序，如下图
            //1 3 5 7
            //2 4 6 8
            //9 11 13 15
            //10 12 14 16
            int j;
            for (int i = 1; i <= 100 / 4; i++)
            {
                if (i % 2 != 0)
                {
                    j = 4 * (i - 1) + 1;
                    //for (int k = j; k <= j+6;)
                    //{
                    //    if (k>100)
                    //    {
                    //        return;
                    //    }
                    //    Console.Write(k+" ");
                    //    k += 2;
                    //}
                    //Console.WriteLine();
                }
                else
                {
                    j = 4 * (i - 2) + 2;
                    //for (int k = j; k <= j + 6;)
                    //{
                    //    if (k > 100)
                    //    {
                    //        return;
                    //    }
                    //    Console.Write(k + " ");
                    //    k += 2;
                    //}
                    //Console.WriteLine();
                }
                for (int k = j; k <= j + 6;)
                {
                    if (k > 100)
                    {
                        return;
                    }
                    Console.Write(k + " ");
                    k += 2;
                }
                Console.WriteLine();

            }














        }





    }
}
