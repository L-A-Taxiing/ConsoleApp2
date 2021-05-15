using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    sealed class User : ISendMessage, IChat
    {

        private static User InvitedBy;
        private string _password;
        //public static bool Register(){ }
        //public static bool Login() { }



        private string _Name;

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
        public string Name { get; set; }

        public TokenManager Tokens { get; set; }
        //User类中添加一个Tokens属性，类型为TokenManager

        //2.设计一个适用的机制，能确保用户（User）的昵称（Name）不能含有admin、17bang、管理员等敏感词。
        //    public string Name 
        //    {
        //        get { return _Name; }

        //        set 
        //        {
        //            if (value.Contains("admin")||value.Contains("17bang")||value.Contains("管理员"))
        //            {
        //                Console.WriteLine("您输入的名称含有敏感词汇！");
        //                return;
        //            }
        //            else
        //            {
        //                _Name = value;
        //                Console.WriteLine(_Name);
        //            }

        //        }
        //    }


        //    //3.确保用户（User）的密码（Password）：
        //    //   长度不低于6
        //    //   必须由大小写英语单词、数字和特殊符号（~!@#$%^&*()_+）组成

        //    public bool PassWordFormatIsTrue(string PassWord,string PassWordFormat ) 
        //    {
        //        char[] ofCharArray = PassWord.ToCharArray();

        //        if (ofCharArray.Length<6)
        //        {
        //            Console.WriteLine("密码长度不能低于6位!");
        //            return false;
        //        }
        //        for (int i = 0; i < ofCharArray.Length; i++)
        //        {
        //            if (PassWordFormat.Contains(ofCharArray[i]))
        //            {
        //                return true;
        //            }
        //        }
        //        return false; 
        //    }
        //    public bool PassWordHasTrue(string PassWord/*, string PassWordFormat*/)
        //    {
        //        return
        //        (
        //        PassWordFormatIsTrue(PassWord, "~!@#$%^&*()_+") &&
        //        PassWordFormatIsTrue(PassWord, "0123456789") &&
        //        PassWordFormatIsTrue(PassWord, "abcdefghijkopqrstuvwxyz") &&
        //        PassWordFormatIsTrue(PassWord, "ABCDEFGHIJKOPQRSTUVWXYZ")
        //        );
        //    }
        //    public void PassWordTrue(string PassWord) 
        //    {
        //        if (PassWordHasTrue(PassWord))
        //        {
        //            Console.WriteLine("密码输入正确!");
        //        }
        //        else
        //        {
        //            Console.WriteLine("密码必须由大小写英语单词、数字和特殊符号（~!@#$%^&*()_+）组成!");
        //        }
        //    }
        //}

    }
}
//   观察“一起帮”的：
//1. 注册 / 登录功能，定义一个User类，包含字段：Name（用户名）、Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()
//   为这些类的字段和方法设置合适的访问修饰符。