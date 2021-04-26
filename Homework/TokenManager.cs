using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    internal class TokenManager
    {
        private Token _tokens;
        public void Add(Token token)
        {
            _tokens = _tokens | token;
        }

        public void Remove(Token token) 
        {
            if (Has(token))
            {
                _tokens = _tokens ^ token;
            }
            else
            {
                System.Console.WriteLine("Exception");
            }
        }

        public bool Has(Token token)
        {
           return token ==(_tokens & token);
        }

    }

    
    

}
//声明一个令牌管理（TokenManager）类：
//使用私有的Token枚举_tokens存储所具有的权限
//暴露Add(Token)、Remove(Token)和Has(Token)方法，可以添加、删除和判断其有无某个权限
