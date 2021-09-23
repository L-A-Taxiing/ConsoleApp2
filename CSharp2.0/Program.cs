using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
            //int j;
            //for (int i = 1; i <= 100 / 4; i++)
            //{
            //    if (i % 2 != 0)
            //    {
            //        j = 4 * (i - 1) + 1;
            //        //for (int k = j; k <= j+6;)
            //        //{
            //        //    if (k>100)
            //        //    {
            //        //        return;
            //        //    }
            //        //    Console.Write(k+" ");
            //        //    k += 2;
            //        //}
            //        //Console.WriteLine();
            //    }
            //    else
            //    {
            //        j = 4 * (i - 2) + 2;
            //        //for (int k = j; k <= j + 6;)
            //        //{
            //        //    if (k > 100)
            //        //    {
            //        //        return;
            //        //    }
            //        //    Console.Write(k + " ");
            //        //    k += 2;
            //        //}
            //        //Console.WriteLine();
            //    }
            //    for (int k = j; k <= j + 6;)
            //    {
            //        if (k > 100)
            //        {
            //            return;
            //        }
            //        Console.Write(k + " ");
            //        k += 2;
            //    }
            //    Console.WriteLine();

            //}

            //3.写一个自定义方法，该方法接受一个数字形式的字符串参数，例如"135792468",返回该字符串中每一个单个数字
            //的和，如上例中返回"1+3+5+..."的和
            Console.WriteLine(GetSum("125792468"));


            //4.写一个自定义方法，该方法接受一个身份证号码，解析得到出生年月日
            Console.WriteLine(GetBirthDay("321281199803085917"));

        }
        public static int GetSum(string number)
        {
            int sum = 0;
            char[] array = number.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
               sum+= int.Parse(array[i].ToString());
            }
            return sum;
        }

        public static Object GetBirthDay(String Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return "身份证不能为空!";
            }
            if (Id.Length!=18)
            {
                return "身份证号必须为18位!";
            }
            string birthday = "";
            birthday = Id.Substring(6, 4) + "-" + Id.Substring(10, 2) + "-" + Id.Substring(12, 2);
            DateTime b = Convert.ToDateTime(birthday);
            return b.ToString("yyyy年MM月dd日");
        }


    }
}
