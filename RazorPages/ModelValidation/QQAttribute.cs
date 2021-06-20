using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace System.ComponentModel.DataAnnotations
{
    public class QQAttribute : RegularExpressionAttribute 
    {
        public QQAttribute():base(@"[1-9]\d{4,}")
        {
            



        }

        //返回ErrorMessage的方法
        public override string FormatErrorMessage(string name)//name不设置默认就是属性名
        {
            return "QQ格式不正确";   
        }



    }


}
