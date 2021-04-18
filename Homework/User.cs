using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class User
    {
        private static string Name;
        private static string Password;
        private static User InvitedBy;

        public static bool Register(){ }
        public static bool Login() { }
        
    }
}
//   观察“一起帮”的：
//1. 注册 / 登录功能，定义一个User类，包含字段：Name（用户名）、Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()
//   为这些类的字段和方法设置合适的访问修饰符。