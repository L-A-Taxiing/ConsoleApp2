using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    sealed class User:ISendMessage,IChat
    {
        private static User InvitedBy;
        private string _password;
        //public static bool Register(){ }
        //public static bool Login() { }

        public User(string name, string password)    //每一个User对象一定有name和password赋值;
        {
            _name = name;
            _password = password;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == "admin")
                {
                    _name = "系统管理员";
                }
                else
                {
                    _name = value;
                }
            }
        }
        //user.Password在类的外部只能改不能读
        public string Password
        {
            set { _password = value; }
        }
        //public string Password { set; private get; }
        //调用:User dfg  =new User("大飞哥","1234")

         void IChat.Send()
        {
            Console.WriteLine("传入数据库");
        }
         void ISendMessage.Send()
        {
            Console.WriteLine("传入数据库");
        }
        public int HelpMoney { get; set; }
        public int HelpPoint { get; set; }

        public int HelpBean { get; set; }

    }
}
//   观察“一起帮”的：
//1. 注册 / 登录功能，定义一个User类，包含字段：Name（用户名）、Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()
//   为这些类的字段和方法设置合适的访问修饰符。