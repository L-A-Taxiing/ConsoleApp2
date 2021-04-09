using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)

        {
            //1.输出两个整数/小数的和/差/积/商
            int a = 3, b = 4;
            Console.WriteLine(a+b);
            Console.WriteLine(a-b);
            Console.WriteLine(a*b);
            Console.WriteLine(a/b);

            float c = 1.2F, d = 0.2F;
            Console.WriteLine(c+d);
            Console.WriteLine(c-d);
            Console.WriteLine(c*d);
            Console.WriteLine(c/d);

            //电脑计算并输出：[(23 + 7)x12-8]÷6的小数值（挑战：精确到小数点以后2位）
            
            float result=(float)((23+7)*12-8)/6;
            string i = result.ToString("0.00");
            Console.WriteLine(i);

            //想一想以下语句输出的结果：
            //int i = 15;
            //Console.WriteLine(i++);
            //i -= 5;
            //Console.WriteLine(i);
            //Console.WriteLine(i >= 10);
            //Console.WriteLine("i值的最终结果为：" + i);
            //int j = 20;
            //Console.WriteLine($"{i}+{j}={i + j}");
            //15;11;true;11;20+11=31

            //想一想如下代码的结果是什么，并说明原因：
            //int a = 10;
            //Console.WriteLine(a > 9 && (!(a < 11) || a > 10));
            //false a>9==true;a<11==true,a>10==false,a<11和a>10，
            //"||"或，两个布尔值只要有一个是true即为true；"&&"且，两
            //个布尔值只要有一个是false即为false，最终结果即为false；

            //当a为何值时，结果为true？
            //bool result = (a + 3 > 12) && a < 3.14 * 4 && a != 11;
            //"&&",布尔值都为true，a + 3 > 12 == a > 9; a < 3.14 * 4 == a < 12.56;
            //a != 11,取反a不为11；所以a的取值范围为9 < a < 12.56且a≠11；

















        }
    }
}
