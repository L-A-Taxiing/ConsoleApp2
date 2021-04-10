using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
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
            string[] students = new string[] { "阿泰", "母鸡","夏康平", "胡涛", "姜鹏", "周丁浩", "韩佳宝", "秦慧", "刘伟" };
            string[,] names = new string[4, 4];
            names[0, 0] = "阿泰";
            names[0, 1] = "母鸡";
            names[0, 2] = "夏康平";
            names[1, 1] = "胡涛";
            names[1, 2] = "姜鹏";
            names[1, 3] = "周丁浩";
            names[2, 0] = "韩佳宝";
            names[2, 2] = "秦慧";
            names[3, 3] = "刘伟";
            Console.WriteLine(students.Length);
            Console.WriteLine(names.Length);

















            

        }

    }

}


    


































