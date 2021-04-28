using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    //将HelpMoneyChanged应用于Publish()方法
    //用反射获取Publish()上的特性实例，输出其中包含的信息


    [AttributeUsage(AttributeTargets.Method)]   ////该特性只能用于方法
    public class HelpMoneyChangedAttribute: Attribute//自定义一个特性HelpMoneyChanged（帮帮币变化）：
    {

        public HelpMoneyChangedAttribute(int amount)//有一个构造函数，可以接受一个int类型的参数amount，表示帮帮币变化的数量
        {
            Amount = amount;
        }
        public string Message { get; set; } //有一个string类型的Message属性，记录帮帮币变化的原因

        public int Amount { get; set; }

    }
}
