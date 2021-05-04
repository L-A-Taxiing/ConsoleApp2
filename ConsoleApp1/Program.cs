using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(MyClass.FindPrimeNum(1, 100));

        }
    }

    public class MyClass
    {
        //为之前作业添加单元测试，包括但不限于：
        //1.数组中找到最大值
        public static double FindMax(double[] nums)
        {
            double Max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (Max < nums[i])
                {
                    Max = nums[i];
                }
                //else continue
            }
            return Max;
        }

        //2.找到100以内的所有质数
        public static int[] FindPrimeNum(int first, int end)
        {
            int count = 0;
            for (int j = 2; j <= end - first; j++)
            {
                bool found = true;
                for (int i = 2; i < j; i++)
                {
                    if (j % i == 0)
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    //Console.WriteLine(j);
                    count++;
                }/*else nothing*/
            }
            int[] Nums = new int[count];
            for (int k = 0; k < count; k++)
            {
                for (int j = 2; j <= end - first; j++)
                {
                    bool found = true;
                    for (int i = 2; i < j; i++)
                    {
                        if (j % i == 0)
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        Nums[k] = j;
                    }/*else nothing*/
                }
            }
            return Nums;
        }
        public static bool IsPrimeNum(int nums)
        {
            bool found = true;
            for (int i = 2; i < nums; i++)
            {
                if (nums % i == 0)
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //3.猜数字游戏
        public static bool GuessMe(int num)
        {
            if (num <= 0 || num > 1000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool GuessResult(int target, int guess)
        {
            if (GuessMe(target) == true)
            {
                if (target == guess)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static string GuessTimes(int target, int guess, int times)
        {
            if (GuessResult(target, guess) == false)
            {
                return "false";
            }

            if (times == 10)
            {
                return "(～￣(OO)￣)ブ";
            }
            else if (times <= 5)
            {
                return $"你真牛逼!恭喜你，答对了！只用了{times}次呢，棒棒哒！";
            }
            else if (times < 8)
            {
                return $"不错嘛！恭喜你，答对了！只用了{times}次呢，棒棒哒！";

            }
            else
            {
                return $"恭喜你，答对了！只用了{times}次呢，棒棒哒！";
            }
        }

        //4.二分查找        
        public static int BinarySeek(int[] numbers, int target)
        {
            int left = 0, right = numbers.Length - 1;
            int result = -1;
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (target == numbers[middle])
                {
                    result = middle;
                    break;
                }
                else if (target > numbers[middle])
                {

                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            if (result != -1)
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

       

    }







}



    
