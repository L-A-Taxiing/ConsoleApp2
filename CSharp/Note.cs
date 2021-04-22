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
        ///面向对象  ||    (五)静态和实例
        ///1.静态构造函数；  不能有访问修饰符，也不能有参数;
        ///2.静态类:通常用于将静态方法归类;静态类不能被实例化，其中只能有静态成员，不能有实例成员;但实例类中可以有静态成员
        ///3.公有和独有——静态成员是属于类的（公有），所以当然也就是属于由类实例化而生成的所有对象的;而实例成员是属于
        ////每一个具体的对象的（独有），所以它既不能属于其他对象，也不能属于类——因为属于类也就属于其他对象了;
        ///enroll;数组和方法前面加static;
        ///4.静态和实例:能实例不要静态
        ///面向对象  ||    (六)继承
        ///1.实现继承的语法很简单，关键就是冒号（:）。子类继承父类之后，就可以使用父类的成员；
        ///2.注意事项: I.继承发生在类和类之间，而不是对象之间;  II.访问级别的一致性(可以更低); III.一个父类可以有多个子类,但一个子类只能有一个父类；
        /////         IV.多层继承:一个子类可以作为其他子类的父类; V.静态类不能被继承，但实例类中的静态成员一样可以被继承;
        ///3.实例化一个子类，需要调用它所有的（即包含祖先的）父类构造函数; 如果父类只有一个无参构造函数（隐式/显式的均可),默认调用这个无参构造函数,
        /////没有无参构造函数，就需要在子类的构造函数中指定具体调用父类的哪一个构造函数;
        ///internal class Person
        ///{
        ///    父类没有无参构造函数了
        ///    public Person(string name) { }
        ///    internal string Name { get; set; }
        ///}
        ///internal class Student : Person
        ///{
        ///    子类必须显式地指明调用父类的某一个构造函数
        ///    public Student(string name)
        ///    使用base关键字，将子类实例化获得的name传递给父类
        ///    : base(name)
        ///    : base("飞哥")    //也可以传一个固定值 
        ///    { }
        ///}
        ///4.protected（受保护的):
        ///I.  父类私有的（private）成员，子类就不能访问（也只有private的父类成员，子类不能访问）;
        ///II. 父类的某个成员，除子类以外的其他地方都不能访问，或者说，只有在子类中才能访问——这时候，就需要使用protected访问修饰符;
        ///protected internal联合使用，当父类和子类不在同一个项目时有用,添加了protected的internal成员，可以被在另外一个项目中的子类使用.
        ///5.父类装子类
        /// Person ywq  = new Student();       //父类变量引用（指向）了一个子类对象
        /// 变量能够调用（.出来）什么，是由声明这个变量类型决定的，而不是变量所引用的对象类型决定的;
        /// 父类变量ywq不能调用子类Student的属性Score，所以可以保证无论如何使用ywq变量，都不会出事。哪怕以后ywq指向其他对象，都没有问题;——安全;
        ///6.is和as
        ///is用来进行类型判断:
        ///Person wx = new Person();
        ///Console.WriteLine(wx is Person);      //true：是自己的类型
        ///Console.WriteLine(wx is Student);     //false：不是子类型
        ///注意:如果变量和类型之间没有继承关系，结果必然为false；或者变量必然是该类型（比如值类型），结果必然为true，VS提示警告;
        ///    如果变量值为null（没有对象引用），总是返回false;
        ///继承关系也可以用强制性转换:
        ///Person wx = new Student();
        ///Console.WriteLine(wx.Score);   //报错：Score不是Person的属性
        ///但可以将wx强制转换成Student后当做Student对象使用
        ///Console.WriteLine(((Student) wx).Score);
        ///但强制类型转换不进行编译时检查,只在运行时报错,如果不想直接报错，就需要利用到is:
        ///if (pzq is Student)
        ///{
        ///   Console.WriteLine(((Student) pzq).Score);
        ///}
        ///还有另一种方式——as;
        ///Student converted = pzq as Student;
        ///if (converted != null)
        ///{
        ///   Console.WriteLine(converted.Score);
        ///}
        ///7.sealed（封闭的）: 标记某个类不能再被继承，比如：sealed class Student : Person {};
        ///8.允许多重继承只会进一步的鼓励继承的滥用;
        ///真正实现重用的：对行为而言，就是方法；对状态而言，应该是组合。即一个对象包含另外若干对象，或者若干对象组合成一个对象;
        ///面向对象要映射现实,让代码更加容易被人理解;继承本质上体现的是一种“是”的关系;共同/类似的行为（会跑会叫有生命），而不是属性（有一个脑袋四条腿)
        ///面向对象  ||  (七)多态
        ///1.子类和父类可以有相同签名，但会收到一个warning，需要添加new关键字：
        ///internal class Person
        ///{
        ///    internal void Eat()
        ///    {
        ///        Console.WriteLine("人吃饭");
        ///    }
        ///}                                                               //new Person().Eat();     //输出：人吃饭
        ///++++++++++++++++++++++++++++++++                                
        ///internal class Student : Person
        ///{
        ///    internal new void Eat()   //注意关键字new
        ///    {
        ///        Console.WriteLine("学生吃饭");
        ///    }
        ///}                                                              //new Student().Eat();    //输出：学生吃饭 
        ///new还可以作用于静态方法;   父类装子类；
        ///2.重写(Override)
        ///internal class Person
        ///{
        ///    internal virtual void Eat()     //注意关键字 virtual 
        ///    {
        ///        Console.WriteLine("人吃饭");
        ///    }
        ///}
        ///++++++++++++++++++++++++++++++++
        ///internal class Student : Person
        ///{
        ///    internal override void Eat()   //注意关键字 override
        ///    {
        ///        Console.WriteLine("学生吃饭");
        ///    }                                                          //Person ywq = new Student();
        ///}                                                              //ywq.Eat();        //结果为：学生吃饭
        ///实现多态:
        ///将ywq值赋值给一个person对象;
        ///Person ywq = new Student();
        ///ywq.Eat();     //代码第2行，输出：学生吃饭
        ///    ywq = new Person();
        ///ywq.Eat();     //代码第4行，输出：人吃饭
        ///子类可以使用base调用父类的方法。这在override虚方法中非常常见;其次，可以在多重virtual和override
        ///internal class Student : Person
        ///{
        ///    internal override void Eat()   //这里已经是override了
        ///    {
        ///        Console.WriteLine("学生吃饭");
        ///    }
        ///}
        ////+++++++++++++++++++++++++++++++                          //以在override方法前面使用sealed关键字，标识override到此为止，不能再被子类override了
        ///internal class AgileStudent : Student
        ///{
        ///    internal override void Eat()  //继续override
        ///    {
        ///        base.Eat();     //base仅指Student，不包含父类的父类
        ///    }
        ///}
        ///3.面向过程的思维:
        ///static void ServeLunch(string role)
        ///{
        ///    Console.WriteLine("开饭啦……");                          
        ///    if (role == "老师")                               static void ServeLunch(Person person)
        ///    {                                                {
        ///        new Teacher().Eat();                          Console.WriteLine("开饭啦……");
        ///    }                                                 person.Eat();   //不同的Person对象自然会调用不同的方法
        ///    else if (role == "学生")          ==>              其他代码……
        ///    {                                                }
        ///        new Student().Eat();
        ///    }                                           调用: ServeLunch(new Teacher{Name="飞哥"});
        ///    //else ignore                                    ServeLunch(new Student{Name="ppm"})
        ///    //其他代码……
        ///}
        ///4.多态减少if...else嵌套；让面向对象的设计成为可能;
        ///5.面向对象不考虑具体的实现细节，而是考虑对象的组织调用;















































    }
}
