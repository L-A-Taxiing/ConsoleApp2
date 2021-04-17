﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Note
    {

        ///面向对象
        ///1.面向对象的一个重要原因是管理、组织函数;
        ///2.类；和控制台相关、和计算相关的函数一类，比如Console类的WriteLine方法();
        ///3.F12可以查看方法  .相当于的;
        ///4.类文件.cs文件，一个文件一个类，二者名可以冲突，但最好一致，冲突时以class后面定义的类名为准;
        ///5.一个.cs可以有多个class;
        ///6.类可以放置在类中形成类中类;也可以用partial关键字生成部分类(编译时会被当作同一个类);
        ///7.class后面跟着的是部分名，类的全名：命名空间(由namespace定义)+.+部分名————避免重名
        ///8.命名空间，一般按层级组织(便于理解和记忆，无其他意义);
        ///9.每次使用全名很麻烦，因此C#提供了一个机制：当源代码找不到类名，编译器会依次将部分名
        /////与I.和当前代码所在的namespace组合orII.和using中的namespace组合（using后面也只能跟名称空间)生成全名;
        ///10.有时候还会出现部分类名可以和当前类文件中using的多个名称空间组合的情形,这时只能使用全名,
        /////有时候全名会很长，这时候可以使用名称空间别名：using yz = _17bang.feige.YuanZhan，new yuanzhan.user;
        ///11.Static(静态)——I.属于这个类II.可以直接由类名进行调用;
        ///12.访问修饰符：I.public(可以在外部任何地方使用) II.private（只能在自己类的内部使用） III.internal(可以在当前项目中使用);
        ///13.命名方法:private小驼峰;public大驼峰;
        ///14.访问修饰符除了可以修饰方法（以及后文讲到的其他类成员），也可以修饰类本身。但类不能使用private，且默认修饰符是internal;
        ///15.封装,目前记住两点:I.总是尽可能地给最低的访问权限 II.不要把访问修饰符当成“安全策略”使用（通过反射，即使private的类成员都可以被获取;
        ///16.字段:类中声明的是字段_类下面直接声明,可以在声明时赋值;
        /////字段与变量的区别:
        ///I.（静态）字段可以在类中任何地方声明，在任何地方使用；变量在方法中声明，作用域为自声明开始到声明位置对应的第一个花括号（}）结束;
        ///II.如果字段和变量同名，在同一个方法中，变量优先;
        ///III.字段被属于类，通过类调用；变量不属于任何成员，直接使用
        ///IV.变量未赋值不能使用；字段可以使用，值为默认值                             new student().age=23;
        ///17.实例:对象是类的实例,方法和字段前面没有static(静态)叫作实例;                        |
        /// new Student().age = 23;                  //结果不是23;      =>>       Student wx = new Student();            //结果是23;
        /// Console.WriteLine(new Student().age);                                wx.age = 23;             
        /// new Student().learn(85);                                             Console.WriteLine(wx.age);
        /// 
        ///





























    }
}
