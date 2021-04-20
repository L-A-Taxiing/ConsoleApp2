using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Note
    {

        /// 面向对象   ||  (一)类和对象
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
        /// 面向对象  ||   (二)引用类型和值类型
        ///1.Student wx = new Student(); 这行代码的三步:
        ///生成一个对象（new Student()），获得该对象的存储地址;
        ///声明一个Student的变量wx;
        ///将在1中生成的对象存储地址赋值给2中的变量wx，从而把变量wx和对象关联起来;
        ///wx中存储的不是对象本身，而是对象的地址。在C#中，对象的地址又被称之为“引用”，所以凡是以这种形式存放的类型，都被称之为
        ///2.引用类型;凡是由class声明的类型，都是引用类型；“指向”引用类型（存放引用类型对象的地址）的变量，就被称之为引用类型变量;
        ///3.null值上不能进行任何运算，由于对象为null值而报的错误NullReferenceException是程序中最常见的错误;
        ///4.值类型:目前学过的值类型——nt,float,bool等;学过的引用类型——string,数组;
        //// 特点:变量存放的不是地址，而是"值",如int i=18;值类型变量不能为null,没有赋值为默认值;
        ///5.引用传递和值传递的区别: 
        ///Student wx = new Student();
        ///wx.age = 18;                         结果为20;
        ///Student clone = wx;           =>>
        ///clone.age = 20;
        ///Console.WriteLine(wx.age);
        ///6.值类型参数的值传递  值类型参数的引用传递  引用类型参数的值传递  引用类型参数的引用传递
        /// 引用类型参数的值传递;
        /// static void grow(Student student)                   
        ///{
        /// student=new student();   // 加这一行代码结果为18;
        /// student.age++;
        ///}
        ///调用:(结果为19)                                               
        ///Student wx = new Student();
        ///wx.age = 18;
        ///grow(wx);
        ///Console.WriteLine(wx.age); 
        ///引用类型参数的引用传递;   引用类型的"值"是对象地址
        ///static void grow(ref Student student)  
        ///{
        ///student = new Student();
        ///student.age++;
        ///}
        ///调用:(结果为1)
        ///Student wx = new Student();                 ////因为这一次，引用传递会将变量wx直接传递给grow()方法，
        ///wx.age = 18;                                ///也就是说，student参数就是wx本身，那么在方法中新new出来的对象地址也就直接赋值给了wx，
        ///grow(ref wx);                               ///所以现在wx.age就是0了（字段的默认值），++之后就变成了1;
        ///Console.WriteLine(wx.age); 
        ///因为引用类型的引用传递在复杂的代码环境中容易让人懵逼，所以微软官方并不推荐使用。通常，我们应该使用return来实现类似效果：
        ///static Student grow(Student student)
        ///{
        ///student = new Student();
        ///student.age++;                              ///使用自定义class作为参数和返回值的用法;
        ///return student;
        ///}
        ///调用:
        ///  Student wx = new Student();
        ///  wx = grow(wx); 
        ///  Console.WriteLine(wx.age);
        ///  或者//Console.WriteLine(grow(wx).age);
        ///  引用类型存放在堆里;而值类型存放在栈或者堆中
        ///  
        /// 面向对象 ||    (三)堆和栈 
        ///1.堆:无序的数据集合,粗糙理解——新建一个对象，编译器随便地找一块内存就开始使用，哪里有就用哪里(一开始有序);
        ///  栈:"先进后出的数据结构",栈顶、栈底、栈深、出栈、入栈;
        ///2.为什么需要栈:变量存放在栈中;引用类型的实例存放在堆里;Call stack(Debug-Windows);递归-overflow;0.
        ///3.为什么要设计引用两种类型:引用类型,提高性能,与其移动对象不如移动对象的地址;值类型,适合小的数据,寻址耗性能,不需要到堆里查找;
        ///
        ///面向对象  ||    (四)面向对象:其他类成员:构造函数/属性/索引器/析构函数
        ///1.字段前面一般设为private,加一个下划线 _ 用来区分不会和传入的参数冲突;
        ///2.类的内部成员之间可以相互访问;
        ///3.new和构造函数:当运行new student()就是在调用student类中的构造函数(和类相同，但没有返回，可带参数，用于创建类的实例)
        ////类默认自带一个无参的无内容的构造函数(没有返回因为它必然返回当前类的一个实例)
        ////一个类中可以有多个参数不同的构造函数;调用的时候按方法重载进行匹配;
        ////给构造函数传参通常用于给字段赋值;
        ///4.this和构造函数:在字段的前面显示地加一个this(在类中使用实例成员，都隐式地自带，一般可以省略);this 只读,不能复制;
        ////this可以用于构造函数的赋值
        ///当运行Student(name, age)之前，会首先运行Student(name);
        ///public Student(string name)    // 构造函数 1
        ///{
        ///    this.name = name;
        ///}
        ///+++++
        ///public Student(string name, int age)
        ///   : this(name)               // 使用this()调用构造函数 1
        ///{
        ///   this.age = age;
        ///}
        ///方法里面重载,在方法里面调用方法,以减少重复;
        ///5.只读(readonly)和常量(const)——只是让字段被读取但是不能被修改;
        ////直接在字段里赋值——写死了，任何一个对象都是同样的name;
        ///一般来说，常量名称全大写;常量声明时就必须赋值;const编译时确定,new运行时确定；
        ///const和readonly区别:I.const一旦声明，就要赋值；readonly可用延后到constructor  II.const只能是int/bool/string等基本类型；readonly可以是其他类型（如Teacher）
        ///                   III.const默认static，由类名直接调用；readonly默认是实例成员，由对象调用; IV.const还可用于方法体内修饰变量，readonly不行;
        ///                   V:const是在编译时完成赋值，而readonly是在运行时赋值.
        ///6.属性(property)
        ///set()和get()方法进行赋值和取值;方法是对象的行为（动作），属性是对象的状态(数据);属性是对字段的封装；属性一般是public;
        ///set
        ///     {
        ///       if (value< 0 || value> 100)      //用value代表付给属性的值
        ///       {
        ///           Console.WriteLine("给age的赋值超过了合理范围");
        ///           return;                        //结束赋值过程
        ///       }
        ///           age = value;
        ///     }
        ///get  {
        ///        return _name + "(源栈)";
        ///     }
        ///只有get没有set，这样属性就只能读不能写；只有set没有get，这样属性就只能写不能读；
        ///自动属性:public int Score { get; set; }——不能写逻辑；还可以只写get(set)或者在前面添加修饰符public int Score { get; private set; };
        ///如果get只有一行,可以用表达式体  
        ///private int _score;
        ///public int Score
        ///{
        ///  get => _score;           //等同于： get { return _score; }
        ///}
        ///属性也可以不和字段绑定；
        ///还可以在实例化类的同时，给属性赋值（语法上公开字段也可以，但字段不建议暴露）：
        ///Student zjq = new Student
        ///{
        ///   Name = "曾俊清",
        ///   Age = 23,    //多个属性之间用逗号隔开
        ///};
        ///7.匿名类(即没有类名，也不需要声明，可以直接使用的类)
        /// var zjq = new  /*注意：没有类名了*/                       语法及其特点:其变量类型只能用var，否则你也没法写;
        /// {                                                                   所有属性只能是只读的;只是"匿名"而已，本质上还是一个类;
        ///   Name = "曾俊清",                                                   拥有相同（名称+类型+次序）属性的匿名类会被当做同一个类(可以相互赋值);
        ///   Age = 23,
        /// };
        /// Console.WriteLine(zjq.Name);
        ///8.索引器,通常用于封装具有多个元素的数组
        ///声明语法:也需要一个字段来实质上保存数据
        ///private string[] _courses = { "SQL", "C#", "JavaScript" };
        ///和属性一样可以指定访问修饰符，需要指定返回类型                         和属性相比，它没有名称，使用this
        ///public string this[int index]                                      多了一个[]，里面指明索引器参数（有时又被成为“下标”）
        ///index还可以是其他类型，比如string                                    参数必须要有类型和名字，可以有多个，多个参数见用逗号分开（和方法参数一样）
        ///不同：this关键字和[]运算符                                           调用时:
        ///{                                                                  Student wx = new Student();
        ///get和set的使用和属性几乎一样                                         Console.WriteLine(wx[1]);
        ///get { return _courses[index]; }                                    使用的运算符是[];必须有(至少一个)参数
        ///一样可以只读只写
        ///set { _courses[index] = value; }
        ///}
        ///9.析构函数；默认自带，不需要显示声明，在对象被销毁时调用；加前缀‘~’
        ///内存泄漏(memory leak)
        ///Main函数调用:gcShow();  GC.Collect();


















































    }
}
