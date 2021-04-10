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
            string captcha = "999", username = "张三", password = "1000";
            Console.WriteLine("请输入验证码");
            string answer1 = Console.ReadLine();

            if (captcha != answer1)
            {
                Console.WriteLine("验证码错误");
            }
            else
            {
                Console.WriteLine("请输入用户名");
                string answer2 = Console.ReadLine();
                if (username != answer2)
                {
                    Console.WriteLine("用户名不存在");
                }
                else
                {
                    Console.WriteLine("请输入密码");
                    string answer3 = Console.ReadLine();
                    if (password != answer3)
                    {
                        Console.WriteLine("用户名或密码错误");
                    }
                    else
                    {
                        Console.WriteLine("恭喜！登陆成功!");
                    }
                }

                }
            }


































        }
    }

