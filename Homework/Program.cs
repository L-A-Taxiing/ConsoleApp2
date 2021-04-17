﻿using System;
using System.Linq;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //函数作业：方法基础、声明、调用、返回值；第二题的调用
            //Double[] grade = new double[] { 59.9, 78.5, 82.68, 99.9, 56.5, 72.9 };
            //Console.WriteLine(Math.Round(GetAverage(grade), 2));
            //第三题的调用
            //GuessMe();

            //二分查找：调用
            //Console.WriteLine(FindNum(new int[] { 2, 7, 8, 9, 21, 43, 95 }, 7));

            //快速排序
            //quickSort(new int[] { 23, 15, 37, 89, 2, 21, 43, 9, 56 }, 0, 8);


            //C#：面向过程：方法进阶：值/引用传递
            //1.利用ref调用Swap()方法交换两个同学的床位号
            //int a = 201, b = 202;
            //Swap(ref a, ref b);
            //Console.WriteLine("夏康平的床号是：" + a);
            //Console.WriteLine("姜鹏的床号是:" + b);
            //2.将登陆的过程封装成一个方法LogOn()，调用之后能够获得：
            //  1.true / false，表示登陆是否成功
            //  2.string，表示登陆失败的原因
            //if (LogOn("姜鹏","0000",out string reason))
            //{
            //    Console.WriteLine("登录成功");
            //}
            //else
            //{
            //    Console.WriteLine(reason);
            //}
            //C#：面向过程：方法进阶：参数：重载/可选/params
            //1.定义一个生成数组的方法：int[] GetArray()，其元素随机生成从小到大排列。利用可选参数控制：
            //  最小值min（默认为1）
            //  相邻两个元素之间的最大差值gap（默认为5）
            //  元素个数length（默认为10个）
            //Getarray();
            //2.实现二分查找，方法名BinarySeek(int[] numbers, int target)：
            //  传入一个有序（从大到小 / 从小到大）数组和数组中要查找的元素
            //  如果找到，返回该元素所在的下标；否则，返回 - 1
            //int end=BinarySeek(new int[] { 1, 2, 3, 4, 5, 6, 7, 8,9 }, 7);
            //Console.WriteLine(end);
        }





        static void homework()
        {
            //1.分别用for循环和while循环输出：1,2,3,4,5 和 1,3,5,7,9
            //    int[] names = { 1, 2, 3, 4, 5 };
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}

            //int[] names1 = { 1, 3, 5, 7, 9 };
            //int i = 0;
            //while (i < names1.Length)
            //{
            //    Console.WriteLine(names1[i]);
            //    i++;
            //}
            //2.用for循环输出存储在一维 / 二维数组里的源栈所有同学姓名 / 昵称
            //    string[] names = { "夏康平", "胡涛", "姜鹏", "龚廷义", "刘佳宝", "刘盛民", "秦慧" };
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}
            //string[,] names1 = new string[7, 1];
            //names1[0, 0] = "夏康平";
            //names1[1, 0] = "胡涛";
            //names1[2, 0] = "姜鹏";
            //names1[3, 0] = "龚廷义";
            //names1[4, 0] = "刘佳宝";
            //names1[5, 0] = "刘盛民";
            //names1[6, 0] = "秦慧";
            //for (int i = 0; i < names1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < names1.GetLength(1); j++)
            //    {
            //        Console.WriteLine(names1[i, j]);
            //    }
            //}


            //3.让电脑计算并输出：99 + 97 + 95 + 93 + ...+1的值
            //    int sum = 0;
            //for (int i = 1; i < 100; i += 2)
            //{
            //    sum += i;
            //}
            //Console.WriteLine(sum);


            //4.将源栈同学的成绩存入一个double数组中，用循环找到最高分和最低分
            //    double[] score = { 66.6, 59.9, 74.28, 82.34, 99.9 };
            //double max = score[0];
            //for (int i = 0; i < score.Length; i++)
            //{
            //    if (max < score[i])
            //    {
            //        max = score[i];
            //    }/*else continue*/
            //}
            //Console.WriteLine(max);

            //double min = score[0];
            //for (int i = 0; i < score.Length; i++)
            //{
            //    if (min > score[i])
            //    {
            //        min = score[i];
            //    }
            //}
            //Console.WriteLine(min);


            //5.找到100以内的所有质数（只能被1和它自己整除的数）
            //    for (int j = 2; j <= 100; j++)
            //{
            //    bool found = true;
            //    for (int i = 2; i < j; i++)
            //    {
            //        if (j % i == 0)
            //        {
            //            found = false;
            //            break;
            //        }
            //    }
            //    if (found)
            //    {
            //        Console.WriteLine(j);
            //    }
            //}

            ////6.生成一个元素（值随机）从小到大排列的数组

            //int[] nums = new int[10];
            //Random elements = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    nums[i] = elements.Next(0, 100);
            //}
            //for (int i = 0; i < 9; i++)
            //{
            //    for (int j = i + 1; j < 10; j++)
            //    {
            //        if (nums[j] < nums[i])
            //        {
            //            int temp = nums[i];
            //            nums[i] = nums[j];
            //            nums[j] = temp;
            //        }
            //    }
            //}
            //foreach (int value in nums)
            //{
            //    Console.WriteLine(value);
            //}
            //foreach (数据类型 变量名 in 数组名),遍历数组中的元素
            //订正：
            //    int[] nums = new int[10];
            //int sum = 0;
            //Random elements = new Random();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    nums[i] = elements.Next(0, 100);
            //    sum += nums[i];
            //    Console.WriteLine(sum);
            //}




            ////7.设立并显示一个多维数组的值，元素值等于下标之和。Console.Write()
            //int[,] names = new int[3, 4];
            //for (int i = 0; i < names.GetLength(0); i++)
            //{
            //    for (int j = 0; j < names.GetLength(1); j++)
            //    {
            //        int a = i + j;
            //        names[i, j] = a;
            //        Console.Write(names[i, j] + " ");
            //        if (j == 3)
            //        {
            //            Console.WriteLine();
            //        }
            //    }
            //}
        }

        static int FindNum(int[] ids, int target)
        {
            //int[] ids = { 2, 7, 8, 9, 21, 43, 95 };
            int left = 0, right = ids.Length - 1;
            int result = -1;
            //target = 7;
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (target == ids[middle])
                {
                    result = middle;
                    break;
                }

                else if (target > ids[middle])
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
                return (result);
            }
            else
            {
                return -1;
            }
        }


        static double GetAverage(double[] grade)
        {
            //2.计算得到源栈同学的平均成绩(精确到两位小数)

            double sum = 0;
            for (int i = 0; i < grade.Length; i++)
            {
                sum += grade[i];
            }
            double average = sum / grade.Length;
            return average;
        }


        static void GuessMe()
        {
            //3.完成“猜数字”游戏，方法名GuessMe()：
            //随机生成一个大于0小于1000的整数
            //用户输入一个猜测值，系统进行判断，告知用户猜测的数是“大了”，还是“小了”
            //没猜中可以继续猜，但最多不能超过10次
            //如果5次之内猜中，输出：你真牛逼！
            //如果8次之内猜中，输出：不错嘛！
            //10次还没猜中，输出：(～￣(OO)￣)ブ

            //Random nums = new Random();
            //int random = nums.Next(1, 1000);
            //Console.WriteLine("随机数是:"+random);
            //Console.WriteLine("请输入一个不超过1000的自然数");
            //for (int i = 1; i <= 10; i++)
            //{

            //    int Guessnum = Convert.ToInt32(Console.ReadLine());
            //    if (Guessnum != random)
            //    {
            //        if (i == 10)
            //        {
            //            Console.WriteLine("(～￣(OO)￣)ブ");
            //            return;
            //        }
            //        if (Guessnum > random)
            //        {
            //            Console.WriteLine($"太大了哟！(还剩{10 - i}次)");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"太小了呢!（还剩{10 - i}次）");
            //        }

            //    }
            //    else
            //    {
            //        if (i <= 5)
            //        {
            //            Console.WriteLine("你真牛逼！");
            //            Console.WriteLine($"恭喜你，答对了！只用了{i}次呢，棒棒哒！");
            //            return;
            //        }
            //        else if (i < 8)
            //        {
            //            Console.WriteLine("不错嘛！");
            //            Console.WriteLine($"恭喜你，答对了！只用了{i}次呢，棒棒哒！");
            //            return;

            //        }
            //        else
            //        {
            //            Console.WriteLine($"恭喜你，答对了！只用了{i}次呢，棒棒哒！");
            //            return;
            //        }
            //    }

            //}   
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static bool LogOn(string username, string password,out string reason)
        {
            reason = "用户名或者密码错误";
            if (username=="姜鹏"&&password=="0000")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        static int[] Getarray(int min=1,int gap=5,int length=10)
        {
            Random value = new Random();
            int[] array = new int[length];
            for (int i = 0; i <array.Length; i++)
            {
                if (i==0)
                {
                    array[i] = min;
                }
                else
                {
                    array[i] = array[i-1] + value.Next(gap + 1);
                }
                Console.Write(array[i]+",");
            }
            return array;
        }



        static int BinarySeek(int[] numbers, int target) 
        {
            int left = 0, right = numbers.Length - 1;
            int result=-1;
            while (left<=right)
            {
                int middle = left + (right - left) / 2;
                if (target==numbers[middle])
                {
                    result = middle;
                    break;
                }
                else if (target>numbers[middle])
                {

                    left = middle + 1;
                }
                else
                {
                    right = middle -1;
                }
            }
            if (result!=-1)
            {
                return result;
            }
            else
            {
                return -1;
            }














        }




        static void quickSort(int[] array, int low, int high)
        {
            if (low >= high)
            {
                return;
            }
            int i = low, j = high, index = array[i];
            while (i < j)
            {
                while (i < j && array[j] >= index)
                { 
                    j--;
                }
                if (i < j)
                {
                    array[i++] = array[j]; 
                }
                while (i < j && array[i] < index)
                {
                    i++;
                }
                if (i < j)
                {
                    array[j--] = array[i]; 
                }
            }
            array[i] = index; 
            quickSort(array, low, i - 1); 
            quickSort(array, i + 1, high); 
        }

       











    }


















}
        





















































        //之前的作业
        ////1+2+3+4
        //累计求和
        //int sum = 0;
        //for (int i = 1; i < 5; i++)
        //{
        //    sum += i;
        //}
        //Console.WriteLine(sum);

        //int[] studentids = { 8, 7, 9, 10, 2, 4, 5 };
        //int sum = 0;
        //for (int i = 0; i < studentids.Length; i++)
        //{
        //    sum += studentids[i];
        //}
        //Console.WriteLine(sum);

        //求最大/小值
        //int[] names = { 1, 2, 5, 7, 9, 11,-999 };
        //int min = names[0];
        //for (int i = 1; i < names.Length; i++)
        //{
        //    if (min>names[i])
        //    {
        //        min = names[i];
        //    }/*else continue*/
        //}
        //Console.WriteLine(min);

        //int[] studentids = { -88, 7, 9, 10, 2, 4, -500 };
        //[2]--[4]
        //int temp = studentids[4];
        //studentids[4] = studentids[2];
        //studentids[2] = temp;
        //Console.WriteLine("studentids[2]:" + studentids[2] );
        //Console.WriteLine("studentids[4]:" + studentids[4] );
        //从大到小

        //for (int i = 1; i < studentids.Length; i++)
        //{
        //    for (int j = 0; j < studentids.Length - i; j++)
        //    {
        //        if (studentids[j] < studentids[j + 1])
        //        {
        //            int temp = studentids[j];
        //            studentids[j] = studentids[j + 1];
        //            studentids[j + 1] = temp;
        //        }
        //    }
        //}

        //for (int i = 0; i < studentids.length; i++)
        //{
        //    Console.WriteLine (studentids[i]);
        //}



        //在数组中查找某个值，比如在int[]{ 1,2,8,4,5}; 找到8；
        //找到了，输出：找到了，在数组中第几位；
        //找不到，输出：没找到；
        //int[] studentids = { 1, 2, 4, 4, 5 };
        //bool found = false;
        //for (int i = 0; i < studentids.Length; i++)
        //{
        //    if (studentids[i] == 4)
        //    {
        //        Console.WriteLine($"找到了，在数组中第{(i + 1)} 位");
        //        found = true;
        //    }/*else continue*/
        //}
        //if (!found)
        //{
        //    Console.WriteLine("没找到");
        //}/*else nothing*/
        //int[] studentids = { 1, 2, 8, 4, 5 };
        //for (int i = 0; i < studentids.Length; i++)
        //{
        //    if (studentids[i] == 8)
        //    {
        //        Console.WriteLine($"找到了，在数组中第{(i + 1)} 位");
        //        break; continue;
        //    }
        //    else
        //    {
        //        if (i == studentids.Length - 1)
        //        {
        //            Console.WriteLine("没找到");
        //        }/*else nothing*/
        //    }
        //}


        //观察一起帮登录页面，用if...else ...完成以下功能。
        //用户依次由控制台输入：验证码、用户名和密码：
        //如果验证码输入错误，直接输出：“*验证码错误”；
        //如果用户名不存在，直接输出：“*用户名不存在”；
        //如果用户名或密码错误，输出：“*用户名或密码错误”
        //以上全部正确无误，输出：“恭喜！登录成功！”
        //string captcha = "999";
        //Console.WriteLine("请输入验证码");
        //if (captcha != (Console.ReadLine()))
        //{
        //    Console.WriteLine("验证码错误");
        //}
        //else
        //{
        //    Console.WriteLine("Nothing");
        //}
        //string answer2 = Console.ReadLine();
        //if (username != answer2)
        //{
        //    Console.WriteLine("用户名不存在");
        //}
        //else
        //{
        //    Console.WriteLine("请输入密码");
        //    string answer3 = Console.ReadLine();
        //    if (password != answer3)
        //    {
        //        Console.WriteLine("用户名或密码错误");
        //    }
        //    else
        //    {
        //        Console.WriteLine("恭喜！登陆成功!");
        //    }

        //作业：
        //将源栈同学姓名 / 昵称分别：
        //按进栈时间装入一维数组，
        //按座位装入二维数组，
        //并输出共有多少名同学。
        //string[] students = new string[] { "阿泰", "母鸡","夏康平", "胡涛", "姜鹏", "周丁浩", "韩佳宝", "秦慧", "刘伟" };
        //string[,] names = new string[4, 4];
        //names[0, 0] = "阿泰";
        //names[0, 1] = "母鸡";
        //names[0, 2] = "夏康平";
        //names[1, 1] = "胡涛";
        //names[1, 2] = "姜鹏";
        //names[1, 3] = "周丁浩";
        //names[2, 0] = "韩佳宝";
        //names[2, 2] = "秦慧";
        //names[3, 3] = "刘伟";
        //Console.WriteLine(students.Length);
        //Console.WriteLine(names.Length);}


 