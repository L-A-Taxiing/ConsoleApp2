using System;
using System.Linq;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //C#循环作业
            //1.分别用for循环和while循环输出：1,2,3,4,5 和 1,3,5,7,9
            //int[] names = { 1, 2, 3, 4, 5 };
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
            //string[] names = { "夏康平", "胡涛", "姜鹏","龚廷义", "刘佳宝", "刘盛民","秦慧" };
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
            //int sum = 0;
            //for (int i = 1; i < 100; i+=2) 
            //{
            //    sum += i;
            //}
            //Console.WriteLine(sum);


            //4.将源栈同学的成绩存入一个double数组中，用循环找到最高分和最低分
            //double[] score = { 66.6, 59.9, 74.28, 82.34, 99.9, };
            //double max = score[0];
            //for (int i = 0; i < score.Length; i++)
            //{
            //    if (max<score[i])
            //    {
            //        max = score[i];
            //    }/*else continue*/
            //}
            //Console.WriteLine(max);

            //double min = score[0];
            //for (int i = 0; i < score.Length; i++)
            //{
            //    if (min>score[i])
            //    {
            //        min = score[i];
            //    }
            //}
            //Console.WriteLine(min);


            ////5.找到100以内的所有质数（只能被1和它自己整除的数）
            //for (int j = 2; j <= 100; j++)
            //{
            //    bool found = false;
            //    for (int i = 2; i < j; i++)
            //    {
            //        if (j % i == 0)
            //        {
            //            found = true;
                        
            //        }
            //    }
            //    if (!found)
            //    {
            //        Console.WriteLine(j);
            //    }
            //}


            ////6.生成一个元素（值随机）从小到大排列的数组
            //int[] arr = new int[100];
            //for (int i = 1; i <= 100; i++)
            //{
            //    arr[i] = i;
            //}














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

            int[] studentids = { -88, 7, 9, 10, 2, 4, -500 };
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

           




            //在数组中查找某个值，比如在int[]{ 1,2,8,4,5};找到8；
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
        }/*else nothing*/
            //int[] studentids = { 1, 2, 8, 4, 5 };
            //for (int i = 0; i < studentids.Length; i++)
            //{
            //    if (studentids[i]==8)
            //    {
            //        Console.WriteLine($"找到了，在数组中第{(i + 1)} 位");
            //        break;continue;
            //    }
            //    else 
            //    {
            //        if (i == studentids.Length - 1)
            //        {
            //            Console.WriteLine("没找到");
            //        }/*else nothing*/

            //    }

        }
     



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
            //string[] names = {"迪迦", "高斯", "赛罗" };
            ////Console.WriteLine(names[1]);
            //Console.WriteLine(names.Length);
            //数组从0开始
            //int[][] students = new int[3][];
            //students[0] = new int[] { 1, 2 };
            //students[1] = new int[] { 3, 4, 5 };
            //students[2] = new int[5];
            //int[] i = students[1];
            //Console.WriteLine(i[1]);
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
            //Console.WriteLine(names.Length);
            //int[] age;
            //age = new int[1];
            //int[] age = new int[1];
            //age[0] = 15;
            //int[] age = new int[] { 12, 22, 34, 23 };
            ////int[] age = { 12, 22, 34, 23 };//简写
            //string[] username;
            //username = new string[3] { "alxe", "bill","c"};
            //string[] username = { "alxe", "bill", "c" };
            //string[] username = new string[] { "alxe", "bill", "c" };
            //int[,] mda = new int[2, 1];
            //mda[0, 0] = 1;
            //mda[1, 1] = 2;
            //Console.WriteLine(mda.Length);
            //int[,] mda = { { 1, 2, 3 }, { 4, 5, 6 } };
            //Console.WriteLine(mda.Length);
            //Console.WriteLine(mda.Rank);
            //int[][] age = new int[4][];
            //int[][] age = new int[2][] { new int[]{ 1, 2, 3 }, new int[]{ 5, 6, 7 } };
            //string[][] password = new string[2][] { new string[] { "am", "is", "are" }, new string[] { "wu" };
            //string[] names = new string[] { "火" };
            //string[,] location = new string[2, 4];
            //string[][] password = new string[2][] { new string[] { "qaq" }, new string[] { "qwq" } };
            //int i = 0;
            //while (i<5)
            //{
            //    i++;
            //    Console.WriteLine("源栈欢迎你！");
            //}
            //int[] age ={ 1, 2, 3 ,4,5};
            //int i = 0;
            //while (i<age.Length)
            //{
            //    Console.WriteLine(age[i]);
            //    i++;
            //}
            //int[] age = { 5, 6, 7, 12, 10 };
            //int i = 0;
            //do
            //{
            //    Console.WriteLine(age[i]);
            //    i++;
            //} while (i<age.Length);
            //string[] name = { "alex", "bills", "cat" };
            //int i = name.Length;
            //do
            //{
            //    i--;
            //    Console.WriteLine(name[i]);
            //} while (i>0);
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("卢本伟牛逼");
            //}
            //int i = 0;
            //for (
            //    ; 
            //    ;
            //    i+=2)
            //{
            //    Console.WriteLine(i);
            //}
            //string[] name = { "卢本伟", "Pdd", "大司马" };
            //for (int i = 0; i < name.Length; i++)
            //{
            //    Console.WriteLine(name[i]);
            //}
            //i++不在作用域内{ }
            //int[] studentIds = { 8, 7, 9, 10, 2, 4, 5 };
            //for (int i = 0; i < studentIds.Length; i++)
            //{
            //    if ((studentIds[i] == 10))
            //    {
            //        Console.WriteLine(studentIds[i]);
            //    }
            //string name = "源栈", greet = "欢迎您";
            //Console.WriteLine(name+","+greet+"!");拼接
            //Console.WriteLine($"{name},{greet}!");内插
            //Console.WriteLine($"\"{name}\",{greet}!");转义
            //Console.WriteLine($"\\{name}\\,{greet}!");
            //Console.WriteLine(@"\\{name}\\,{greet}!");
            //Console.WriteLine(@$"\\{name}\\,{greet}!");
            //\r\n==》"+Environment NewLine+";\t
            //Console.WriteLine(17+"bang"+true);
















    }












          




    


































