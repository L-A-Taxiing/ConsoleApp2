using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)

        {
            //电脑计算并输出：[(23 + 7)x12-8]÷6的小数值（挑战：精确到小数点以后2位）

            float result = ((23 + 7) * 12 - 8) / 6F;
            
            //string i = result.ToString("0.00");
            Console.WriteLine(Math.Round(result, 2));






        }
    }
}
