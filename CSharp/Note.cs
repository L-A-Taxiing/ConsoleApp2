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
        ///4.值类型:目前学过的值类型——int,float,bool等;学过的引用类型——string,数组;
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
        /// var zjq = new  /*注意：没有类名了*/                                  语法及其特点:其变量类型只能用var，否则你也没法写;
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
        ///面向对象  ||  八(抽象类和接口)
        ///1.abstract(抽象)：由abstract定义的方法叫做抽象方法，抽象方法只能放置在被abstract修饰的抽象类中。抽象类有一个非常明显的特点：不能被实例化;
        ///要在类中声明abstract方法，类上就必须加abstract
        ///internal abstract class Person
        ///{
        ///    //abstract修饰的方法不能有方法体！
        ///    internal abstract void Eat();
        ///}
        ///因为抽象方法没有方法体，所以凡是继承自抽象方法的类，都要通过override实现抽象类的全部抽象方法。而且，override的方法体内，不能通过base调用其抽象类方法;
        ///2.接口(Interface):和抽象类相比，它内部只能有声明（方法和属性），不允许有任何实现;
        ///接口类型上可以加访问修饰符
        ///internal interface ILearn   //接口通常加“I”作为前缀
        ///{
        ///    //一些方法定义都是可行的：
        ///    //注意在接口中这不是自动属性，它仍然需要在子类中实现
        ///    int Score { get; set; }

        ///    //最常用的方法声明
        ///    void Practise();
        ///    int AttendExam(string major);                           //另外注意几个语法点：接口一样不能被实例化（所以也不能有构造函数）
        ///    void GoClass();                                         //接口可以被多重继承;
        //     接口可以也只可以继承接口;
        ///    //不允许有字段
        ///    //int score;

        ///    //不能有方法体（实现），哪怕“空”内容也不行
        ///    //void Practise() { }        

        ///   //不能有访问修饰符，接口成员默认public
        ///    //public int AttendExam(string major);

        ///    //也不要有其他访问修饰符，都是画蛇添足
        ///    //abstract void GoClass();
        ///}
        ///++++++++++++++++++++++++++++++++++++++
        ///   internal class Student : 
        ///    子类只能继承一个父类（Person），
        ///    但可以继承多个接口
        ///    还可以继承一个父类加多个接口
        ///    但是，父类必须放在最前面
        ///    Person, IYuanzhanLearn, IPlay
        ///{
        ///    需要实现IYuanzhanLearn
        ///    以及IYuanzhanLearn继承的ILearn
        ///    和IPlay的成员
        ///}
        ///实现接口:
        ///隐式实现，就是在子类中添加和接口中定义相同的方法(可以被Student变量调用，也可以被接口变量调用);
        ///显式实现，当一个子类继承了多个接口，且多个接口中定义了相同方法的时候;
        ///在方法前面加一个IXXXX；显式实现的接口方法，不能用子类类型的变量进行调用：
        ///internal class Student : Person, ILearn, IPlay
        ///{
        ///    //internal void ILearn.Practise()  //不能有访问修饰符
        ///    void ILearn.Practise()  //实现ILearn.Practise()方法
        ///    {
        ///        Console.WriteLine("键盘敲烂，月薪过万！");
        ///    }                                        
        ///                                                                       调用:  IPlay wx = new Student();
        ///                                                                              wx.Practise();
        ///    void IPlay.Practise()  //实现IPlay.Practise()方法
        ///    {
        ///        Console.WriteLine("再撸一把啊！");
        ///    }
        ///}
        ///接口和抽象类，都不能实例化；
        ///抽象方法和接口中的方法声明都不能有实现；
        ///继承自抽象类和接口的子类，都必须实现抽象类的全部抽象方面和接口的全部定义成员;
        ///抽象类里除了抽象方法，还可以有其他实现；但接口不行，接口里面只能有成员声明
        ///抽象类可以继承接口；但接口不能继承抽象类
        ///抽象类只能作为父类使用，所以一个子类只能继承一个抽象类，但可以继承多个接口
        ///++++++++++++++++++++
        ///抽象类还是一个类，类通常都被认为是对现实中事物的映射，是对事物的行为和状态的封装
        ///所以，类名一般都是名词（比如Person、Animal、Major之类的），映射的是一个实体事物，其中既有方法（行为）也有字段（状态）
        ///而接口通常被认为是对行为（没有状态）的封装，所以接口名一般都是动词（比如IMove、ILearn），映射的是一些操作，其中只有方法（属性本质上也是一种方法）
        ///面向对象  ||  九(结构和日期)
        ///1.结构(Struct)——结构类型是值类型。而值类型要求其所有成员必须有值
        ///new一个结构实例，生成它的实例对象
        ///int age = new Int32();
        ///调用结构的实例方法
        ///age.CompareTo(21);
        ///能够实现接口，但不能继承其他结构和类，自然也不能被其他结构和类继承（这可能是结构较少使用的一大原因）；
        ///默认有一个无参构造函数，但不能显式声明。有参构造函数可以显式声明，
        ///声明的有参构造函数也不会“隐藏”默认的无参构造函数。但构造函数必须保证结构中的所有字段和自动属性被赋值
        ///使用结构默认的无参构造函数，结构会自动的给所有成员赋默认值；否则，这些所有成员都必须在有参构造函数中被赋值
        ///+结构是值类型，值类型的优势是直接存放在栈中，可以快速读取；但它的数据量不能太大，否则就会耗用栈空间，反而拖累性能
        ///+引用类型的优势：只赋值地址不copy内容，传递时更快……
        ///2.DateTime
        ///ToString()方法：可以用于指定日期显示的格式。通常，我们使用字符串指定。用y代表year，用M（注意大写）代表month，用d代表day等，如下所示：
        ///Console.WriteLine(DateTime.Now.ToString(
        ///        "yyyy年MM月dd日 hh点mm分ss秒"));
        ///显示：2019年12月01日 07点59分14秒
        ///+++++++++++++++++++++++
        ///string now = "2021/4/24";
        ///Console.WriteLine(DateTime.Parse(now));     //parse转换字符串;

        ///   //DateTime.TryParse(now, out DateTime result);
        ///   //Console.WriteLine(result.Year);           tryparse运用;
        ///    if (DateTime.TryParse(now, out DateTime result))
        ///    {
        ///        result = result.AddYears(20);   //有返回值不会改变属性;
        ///        Console.WriteLine(result.Year);
        ///    }
        ///    else
        ///    {
        ///        Console.WriteLine("wrong format");
        ///    }

        ///Console.WriteLine(DateTime.Now.ToLongDateString());//2021年4月24日
        ///Console.WriteLine(DateTime.Now.ToLongTimeString());//16:03:57
        ///Console.WriteLine(DateTime.Now.ToShortDateString());//2021/4/24
        ///Console.WriteLine(DateTime.Now.ToShortTimeString());//16:03
        ///Console.WriteLine(DateTime.Now.ToString("yyyy年MM月dd日HH时mm分"));//2021年04月24日16时03分

        ///DateTime.Now.CompareTo(new DateTime(1998, 3, 8));
        ///DateTime.Now.Equals(new DateTime(2020, 4, 4));

        ///DateTime created = DateTime.Now;
        ///DateTime published = created; /*DateTime.Now;*//*二者有差异;*/
        ///Console.WriteLine(created.CompareTo(published));/*结果为0，相等*/
        ///++++++++++++++++++++++
        ///3.运算符重载:本来加号是只能用于数值型类型的，DateTime显然不是数值，本是不应该能够使用加号的
        ///public static DateTime operator +(DateTime d, TimeSpan t);      任何一个类都可以进行运算符重载
        ///语法要求:
        ///方法只能是public和static的
        ///必须要有一个关键字operator
        ///至少一个参数和返回值类型相匹配
        ///某些运算符有要求“成套”，比如重载了==，就必须重载 !=
        ///public double Score { get; set; }
        ///public static double operator-(Student a,student b)
        ///{ 
        ///   return a.Score - b.Score;
        ///}
        ///double gap = new Student { Score = 98.5 } - new Student { Score = 89.5 };//调用
        ///4.TimeSpan:表示的是一段时间，通常由两个日期相减获得;
        ///TimeSpan span = DateTime.Now - new DateTime(2020, 4, 24);
        ///Console.WriteLine(span.Days);//365
        ///Console.WriteLine(span.TotalDays);//365.893690837
        ///Console.WriteLine(span.Hours);//21
        ///Console.WriteLine(span.TotalHours);//8781.4485689
        ///Timespan计量的最大单位是天（Days），没有年和月
        ///用Days/Hours/Minutes等取出的是Timespan中天/小时/分钟等部分的值
        ///用TotalDays/TotalHours/TotalMinutes等取出的才是Timespan代表的时间间隔换算成天/小时/分钟等的值
        ///5.类型转换重载:类与类的转换
        ///Teacher fg = (Teacher)new student();
        ///public static explicit operator Teacher(Student student)
        ///{
        ///    return new Teacher();
        ///}
        ///面向对象  ||  十(枚举和位运算)
        ///1.枚举（Enum）  
        ///成员又被称之为枚举值，枚举值不能有任何修饰符，只能包含两部分：名称+底层数据(默认为int类型，可以不写，不写默认从0开始，依次往下加1)
        ///例：
        ///enum Grade : short   //默认是int类型，现在是short类型
        ///{
        ///   Excellent;
        ///   Passed;
        ///   Failed=8;
        ///}
        ///枚举可以像类型一样使用：
        ////声明Grade属性
        //public Grade grade { get; set; }
        ////作为方法的返回值
        //static Grade GetBy(int score) { }
        ////作为方法的参数
        //static int GetBy(Grade score) { }
        ///它的值直接枚举名点（.）出即可: Grade grade = Grade.Excellent;
        ///可以在枚举和整型之间进行转换
        ///Console.WriteLine((short) Grade.Excellent);
        ///  int类型也行（可以和short转换）
        ///  Console.WriteLine((int) Grade.Passed);
        ///  Console.WriteLine((int) Grade.Failed);
        ///  Console.WriteLine((Grade)0);    //Excellent
        ///  Console.WriteLine((Grade)16);   //无法转换时也不会报错，直接输出16
        ///0所对应的枚举值，或者如果找不到0所对应的枚举值，就直接为0
        ///2.switch...case
        ///Grade grade = Grade.Excellent;
        ///    switch (grade)
        ///    {
        ///        case Grade.Excellent:
        ///            Console.WriteLine("发10个红包");
        ///            break;
        ///        case Grade.Passed:
        ///            Console.WriteLine("发5个红包");
        ///            break;
        ///        case Grade.Failed:
        ///            Console.WriteLine("没有红包了");
        ///            break;
        ///        default:
        ///            Console.WriteLine("怎么回事？");
        ///            break;
        ///    }
        ///注意:
        ///能进行“等值”运算，也就是说只能判断switch()中的值是否等于case后面的值，不能进行大于小于等其他运算
        ///defau兜底，不能忘记break，因为:
        ///如果两个case之间没有break只有业务逻辑语句，就会报编译错误；如果两（多）个case之间没有任何其他语句，这些case条件构成一种“或”的关系
        ///3.位运算
        /// &：读作“位与”，只要一个0才为0
        /// |：读作“位或”，只要一个1就为1
        /// ^：读作“异或”，两个值不同才为1
        ///如果所有参与运算成员的数值都是：
        ///2的整数次方，比如1、2、4、8、16……，或者
        ///2的整数次方数之和，比如3（=1+2）、6（=2+4）、7（=1+2+4）……
        ///他们就会有如下规律：
        ///位或（|）相当于“加”，比如：2|4=6，2|4|1=7……，以下我们将位或（相加）的结果简称为“位或结果”，参与位或运算的成员简称为“成员”，未参与运算的称之为“非成员”
        ///将位或结果和任一成员进行异或（^）运算，其效果就相当于“减”，比如：6^2=4，7^4=3，
        ///将位或结果和任一成员进行位与（&）运算，其结果就等于该成员，比如：6&2=2，7&4=4；且与任何非成进行位与（&）运算，其结果不会等于该非成员，比如：6&1=0，7&8=0
        ///面向对象  ||  十一(object和装箱拆箱)
        ///1.Object:所有类型的父类,任何类默认自动的继承自Object，不需要显式声明;几个常用的方法:
        ///I.Equals():它是一个静态方法，用于比较作为参数传入的两个对象：如果是值类型，比较两个对象的值内容（所有字段），相同为true，否则为false
        ///           如果是引用类型，如果有一个值是null值，返回false，否则当两个变量指向同一个对象，返回true；否则为false;
        ///  referenceEquals:比较的是对象地址-比较值类型时和equals不一样;
        ///II.GetHashCode()：获取对象的哈希值。哈希（Hash），有被称之为散列，是一种获取固定长度数据的算法;
        ///   GetHashCode()是virtual的，所以可以被子类重写（override).
        ///   如果没有被重写，两个完全相同的对象GetHashCode()的Hash值必然相同;
        ///   但是，相同的Hash值并不意味着生成他们的对象相同！所以，我们可以用GetHashCode()确定两个对象不相同，但不能用于确定他们相同.
        ///III.GetType()：获取当前对象的类型信息;取的是当前对象的类型信息，不是当前变量的类型信息;
        ///              Person wx = new Student();
        ///              Console.WriteLine(wx.GetType().Name);   //结果为：Student
        /// ++   wx究竟指向的是什么对象，只能是在程序运行时才能知道，所以GetType()又被称之为获取变量的“运行时类型”;
        /// ++   typeof()，它获取的是类的类型信息：因为传入typeof的就是一个类，所以可以在编译时就知道这个类的类型信息，它又被称之为获取类型的“编译时类型”.
        ///III.ToString()：将对象转换成字符串。注意这也是一个virtual方法，
        ///    所以很多常用的.NET类库对象都重写了这个方法，比如DateTime。如果没有重写的话，默认返回对象的类的全名;
        ///2.类型继承结构:
        ///所有类型被分为值类型（Value Type）和引用类型（Reference Type）,但都继承自Object;
        ///所有class定义的都是引用类型（数组继承自Array，是引用类型；String是一个行为特征非常类似于值类型的引用类型），其他struct/enum定义的都是值类型;
        ///3.装箱和拆箱:种把值类型数据直接赋值给object变量的行为，被称之为装箱（box）
        /// object wx = new Student();
        /// int i = 888; 
        /// object o = 986;  
        /// 自动生成一个object对象（相当于new object()）+ 将整数值986存入这个object对象,这个过程就是装箱的核心过程+将object对象的堆地址赋值给o变量
        /// ----可以用&运算符查看：
        ///装箱和类型的强制转换语法一致，但不能混为一谈:
        ///++装箱和拆箱仅适用于值类型和object之间；强制类型转换适用于任何有继承关系的类型；
        ///++装箱和拆箱多了一个创建object实例的过程；类型转换没有这个过程，不会额外的生成一个对象
        ///4.动态类型（dynamic）
        ///dynamic完全和object完全一致，任何类型对象都可以使用dynamic标记。使用dynamic标记的变量可以绕过C#的编译时（注意：仅仅是编译时）的类型检查;
        ///dynamic并不意味这变量类型可变，通过上述d.GetType()可以清楚的看到d的类型.
        ///面向对象  ||  十二(反射和特性)
        ///1.反射（Reflection）
        ///.NET的反射只能应用于.NET程序。所以说，反射是一种正常的应用技术。如果.NET的反射可以引用于Java程序，就属于非正常技术了；
        ///其次，反射发生是在.NET程序运行时(不是编译时)
        ///2.元数据(Metadata)
        ///当它把源代码编译成.dll文件的时候，它还同时生成了程序集的二进制描述性信息：元数据（metadata），并直接存放在.dll文件中;
        ///程序集的所定义和引用的有成员信息都包括在内，包括程序集信息、类名、类成员和类的继承实现等等;
        ///反射就是依靠读取metadata实现其功能的
        ///3.MSIL(微软中间语言)
        ///metadata中没有方法的具体实现。换言之，metadata里记录了某个类中有某个方法，方法名、参数、返回值啥的它都知道，
        ///但它不知道这个方法具体是如何运行的。记录方法如何运行的代码以MSIL的格式存放在.dll文件中
        ///4.ILDASM(反编译工具)可以阅读.dll文件;
        ///5.反射不能直接读取方法中的源代码，也不能读取经过编译过后的以MSIL格式的代码，
        ///唯一可以读取的是.dll文件中的方法对应的字节流（二进制文件内容）,反射就是利用这些字节流，来进行方法调用的.比如：
        ///获取learn()方法
        ///typeInfo.GetMethod("learn")
        ///        //以对象zjq调用该方法，传入参数csharp
        ///        .Invoke(zjq, new object[] { "csharp" });
        ///6.特性(Attribute)
        ///特性可以被使用于任何目标元素，包括：类、类成员、enum、delegate、assembly……但是，
        ///具体某个特性，应被使用在那种目标元素，是由声明特性时的AttributeUsage指定的；
        ///一个目标元素可以被附着多个Attribute；
        ///可以像方法一样加圆括号，里面接受构造函数参数、给属性赋值等；
        ///Flags本质上是一个继承了Attribute的类:
        ///[AttributeUsage(AttributeTargets.Enum, Inherited = false)]
        ///public class FlagsAttribute : Attribute
        ///特性的声明——定义一个特殊类的的行为:
        ///声明特性（类）的时候，我们通常以Attribute为后缀，但在使用的时候可以省略。
        ///另外注意，在FlagsAttribute上也使用了特性AttributeUsage，和Flags不同的是，AttributeUsage后面跟了圆括号，其中：
        ///AttributeTargets.Enum指定FlagsAttribute只能使用在枚举（Enum）上
        ///Inherited = false说明该特性无法被子类继承
        ///再F12转到AttributeUsage的定义：
        ///AttributeTargets.Enum是其构造函数的参数;
        ///Inherited是其属性.
        ///Flags:
        ///[Flags]
        ///enum Role                       //Enum重写了Object的ToString()方法，在其中判断枚举上是否标记了FlagsAttribute：
        ///{                               //if (!enumInfo.HasFlagsAttribute){
        ///    Student = 1,                // return GetEnumName(enumInfo, value);}
        ///    TeacherAssist = 2,
        ///    TeamLeader = 4,
        ///    DormitoryHead = 8
        ///}
        ///Console.WriteLine(Role.Student | Role.TeacherAssist);
        ///没有Flag，输出：3
        ///有Flag，  输出：Student, TeacherAssist
        ///注意：Flags仅在ToString()时输出“更有意义”的字符串，不保证枚举值都是2的整数次方;
        ///      如果枚举值不是2的整数次方，会出现一些“预期以外”的结果.
        ///Obsolete:常用于需要更改的老旧代码，相较于直接删除或更改，这种方式给了调用者详细的通知，更加的友好，不至于让调用者莫名其妙.
        ///默认情况下标记为过时的元素还可以使用，但是会在编译时给出警告;
        ///但如果使用Obsolete的有参构造函数，可以指定该元素无法使用。强行使用该元素会导致编译错误;
        ///面向对象  ||  十三(争议TDD（测试驱动开发)
        ///1.单元测试:
        ///主体是“开发人员”，不是测试人员。
        ///途径是“通过代码实现”，不是通过手工测试。
        ///实质是一种“测试”，不是代码调试。
        ///SetUp：被标记的方法将会在每一个测试方法被调用前调用
        ///Test：被标记的方法会被依次调用
        ///2.Assert:最常用的是Assert.AreEqual()，比较传入的两个参数
        ///3.TDD,开发流程:
        ///写一个未实现的开发代码。比如定义一个方法，但没有方法实现
        ///为其编写单元测试。确定方法应该实现的功能
        ///测试，无法通过。^_^，因为没有方法实现嘛。但这一步必不可少，以免单元测试的代码有误，无论是否正确实现方法功能测试都可以通过
        ///实现开发代码。比如在方法中完成方法体。
        ///再次测试。如果通过，Over；否则，查找原因，修复，直到通过.
        ///再次测试。如果通过，Over；否则，查找原因，修复，直到通过.
        ///单元测试的价值:
        ///正确性。理论上，TDD的代码bug率非常低——那得你单元测试和开发代码都有疏漏，且双方的疏漏“相兼容”才行
        ///否则，开发代码的bug会被单元测试暴露出来；单元测试的bug也会被开发代码暴露出来
        ///可维护性。这其实才是TDD最重要的价值
        ///成本和收益:
        ///能够单元测试的代码，一定是（高质量的）非常容易解耦的代码;能写出高质量代码的程序员，工资一定是不低的;
        ///面向对象  ||  十四(string还是StringBuilder？)
        ///1.immutable(不可变的):string定义的字符串，一旦设定，就不能改变
        ///    string slagon = "@大神小班，拎包入住@";
        ///    //删除
        ///    Console.WriteLine(slagon.Remove(1));             //结果：@                          删除此字符串中从指定位置到最后位置的所有字符;
        ///    Console.WriteLine(slagon.Remove(1,1));           //结果：@神小班，拎包入住@          从此实例中的指定位置开始删除指定数目的字符;
        ///    //插入
        ///    Console.WriteLine(slagon.Insert(2, "@"));        //结果：@大@神小班，拎包入住@        在指定位置处插入字符;
        ///    //替换
        ///    Console.WriteLine(slagon.Replace('大', '小'));   //结果：@小神小班，拎包入住@         替换char或者string;
        ///    //截取
        ///    Console.WriteLine(slagon.Substring(1, 3));       //结果：大神小                      截取字符串；
        ///    
        ///    //trim  修改字符串前后空白字符
        ///    string fg = "   大 飞 哥   ";
        ///    使用一个@后缀显示效果
        ///    Console.WriteLine(fg.Trim() + "@");           //删除前后空白：大 飞 哥@
        ///    Console.WriteLine(fg.TrimStart() + "@");      //删除前面的空白：大 飞 哥   @
        ///    Console.WriteLine(fg.TrimEnd() + "@");        //删除后面的空白：   大 飞 哥@
        ///    fg本身不会改变
        ///    Console.WriteLine(fg + "@");                  //   大 飞 哥   @
        ///    
        ///    //ToLower/ToUpper   转换大小写
        ///    string sql = "SQL";
        ///    Console.WriteLine(sql.ToLower());             //变成小写：sql
        ///    Console.WriteLine(sql);                       //不变：SQL
        ///    string csharp = "CSharp";
        ///    Console.WriteLine(csharp.ToUpper());         //变成大写：CSHARP
        ///    Console.WriteLine(csharp);                   //不变：CSharp
        ///    
        ///    string是引用类型，但它是一个非常特殊的引用类型，因为它在太多方面表现得和值类型一样（实质原因是imutable）
        ///    string是一个类，类就是引用类型啊。注意它是sealed的，因为.NET不希望string被继承，以免破坏它的immutable特征;
        ///2.一般来说，如果是引用类型，==运算符会比较两个对象的堆地址；但值类型，==运算符直接比较两个对象的值  ：
        ///    string center = "源栈", greet = "欢迎您";
        ///    string a = center + greet;
        ///    string b = $"{center}{greet}";
        ///    Console.WriteLine(a == b);      //结果为true
        ///    比较的是a和b里面存储的值,a和b的所存放的堆地址也不一样:
        ///通过运算符重载实现: public static bool operator ==(String a, String b);
        ///    string a = "源栈";
        ///    string b = "源栈";
        ///    Console.WriteLine(a == b)
        ///结果仍然是true，但是a和b存储的是相同的堆地址;a和b变量中存储还是堆地址而不是字符串的值
        ///3.字符串池(string pool)
        ///在编译的时候（注意：是编译的时候，不是运行的时候），编译器会设置一个字符串“池（pool）”。每次要实例化一个新字符串的时候，首先在池中进行检查：
        ///如果池中已经有完全相同的字符串，直接将这个字符串的堆地址赋值给新变量；否则实例化这个字符串，然后放到字符串池里
        ///为什么不把string直接改成struct呢?——因为string有可能非常非常大，像我们之前讲过的，太大的对象就不适合放在栈中，以免占用宝贵的栈资源.
        ///4.其他的一些方法:
        ///    判断是否为空
        ///    string a = null;
        ///    string b = "";
        ///    string c = "       ";
        ///    IsNullOrEmpty() ：是不是为Null值或者为空
        ///    IsNullOrWhiteSpace()：是不是为Null或者空白字符串
        ///    Console.WriteLine(string.IsNullOrEmpty(a));         //True
        ///    Console.WriteLine(string.IsNullOrWhiteSpace(a));    //True
        ///    Console.WriteLine(string.IsNullOrEmpty(b));         //True
        ///    Console.WriteLine(string.IsNullOrWhiteSpace(b));    //True
        ///    Console.WriteLine(string.IsNullOrEmpty(c));         //False
        ///    Console.WriteLine(string.IsNullOrWhiteSpace(c));    //True
        ///    
        ///    其他返回bool值的判断，包含（Contain）和开始（Starts）/结束（Ends）
        ///    string slagon = "飞哥，还有源栈欢迎您！";
        ///    包含"源栈"
        ///    Console.WriteLine(slagon.Contains("源栈"));         //True
        ///    以"飞哥"开始/"欢迎您！"结尾 
        ///    Console.WriteLine(slagon.StartsWith("飞哥"));       //True
        ///    Console.WriteLine(slagon.EndsWith("欢迎您！"));     //True   
        ///
        ///    还有返回int类型下标的IndexOf()和LastIndexOf()：
        ///    string slagon = "源栈欢迎您！！！";
        ///    Console.WriteLine(slagon.IndexOf("！"));            //5
        ///    Console.WriteLine(slagon.LastIndexOf("！"));        //7
        ///    
        ///    连接和拆分——Contact()可以直接将字符串连接起来，Join()用指定字符（分隔符）将字符串连接起来；
        ///    Contact()可以直接将字符串连接起来
        ///    Join()用指定字符（分隔符）将字符串连接起来
        ///    string a = "源栈";
        ///    string b = "，";
        ///    string c = "欢迎您!";
        ///    直接把abc连接起来
        ///    Console.WriteLine(string.Concat(a, b, c));
        ///    把abc用' '连接起来
        ///    string joined = string.Join(' ', a, b, c);
        ///    Console.WriteLine(joined);   //注意空格：源栈 ， 欢迎您!
        ///++  被Join()用分隔符连接起来的的字符串还可以再使用Split()拆分，获得一个string数组：
        ///    string[] splitted = joined.Split(' ');   //用' '分隔
        ///    for (int i = 0; i<splitted.Length; i++)
        ///    {
        ///        Console.WriteLine(splitted[i]);
        ///    }
        ///    被' '分隔之后，splitted共三个元素：
        ///    源栈
        ///    ，
        ///    欢迎您!
        ///    
        ///    把字符串转换成字符数组的：
        ///    char[] ofA = a.ToCharArray();  //结果：'源'和'栈',转换之后，就可以对字符串的每个字符进行过滤筛选
        ///5.StringBuilder
        ///    实例化一个StringBuilder对象
        ///    StringBuilder sb = new StringBuilder();
        //     一直往StringBuilder对象上添加（Append）字符串
        ///    sb.Append("源栈");
        ///    sb.Append("，");
        ///    sb.Append("欢迎您！");
        ///    //不要忘了使用ToString()将StringBuilder对象转换成字符串
        ///    string slagon = sb.ToString();
        ///如果用+的话就一行: string slagon = "源栈" + "，" + "欢迎您！";
        ///StringBuilder是一个可以实例化的类,还有其他方法:
        ///    Insert()：插入，需要指定插入的位置index
        ///    Replace()：替换
        ///    Remove()：删除指定位置index，一定长度length的内容
        ///    Clear()：清除全部内容
        ///    sb.Remove(0, 1);             //删除了从下标为0开始的一个字符
        ///    sb.Replace("!", "……");       //将！替换成……
        ///    sb.Insert(0, "○");          //在下标为0的地方插入一个○
        ///    sb.Clear();                 //全部清除
        ///两个重要的构造函数:
        ///    public StringBuilder(int capacity);
        ///    public StringBuilder(string value);
        ///    value：指定StringBuilder最开始“装”着的字符串
        ///    capacity：指定StringBuilder最初的“容量”。这实际上就是的StringBuilder所谓“性能提升”的关键.
        ///6.加号（+）拼接和StringBuilder.Append()的区别:
        ///两个字符串a和b加好拼接的过程：
        ///    计算出a和b的长度，然后相加达到总长度
        ///    按总长度新生成一个新的char[]数组
        ///    将a和b的内容依次复制到新的char[]数组
        ///    将新的char[]数组合成字符串
        ///StringBuilder，其工作原理(减少性能的损耗,大规模字符串拼接):
        ///    在StringBuilder实例化的时候，生成一个长度（capacity）或者由构造函数参数指定，或者默认为16的char[] 数组
        ///    将a、b、c、d……等字符串依次往char[] 数组里装，如果
        ///    char[] 数组的长度不够了，StringBuilder自动扩充其capacity，生成一个双倍长度的新数组继续装
        ///    直到调用ToString()，将char[] 数组转换成字符串




























    }





    class Note2
    {
        //C# 高级进阶 ||  (一)泛型：声明/使用/约束/继承
        //1.用object数组存在弊端: 装箱拆箱性能+不知道取出来的对象究竟是什么类型 => 泛型;
        //泛型(Generic)
        //在普通类上加一个<T>就诞生了泛型类
        //public class Generic<T>
        //{
        //    //注意T[]，不是int[]或者string[]
        //    internal T[] array;
        //}
        //语法点:
        //T：类型参数（Type parameter）/占位符（placeholder）;
        //I. 定义构造函数时不需要加上泛型参数;
        //II. 可以有多个类型参数，用，分开，但最好不要太多;
        //III. 对于泛型对象而言，一旦T被“具象化”（变量声明/new），就不能再更改;
        //IV. 泛型可以用于方法/接口/委托，没有泛型enum;
        //2.为什么需要泛型?
        //I. 重用;
        //II. 类型安全(相较于Object),编译时检查尽早暴露问题;
        //III. 提高性能,编译时生成,避免装箱/拆箱;
        //类型确定——泛型类还不是一个类;
        //Console.WriteLine(typeof(Generic<int>) == new Generic<Student>().GetType());false
        //默认值:array[0] = default(T);
        //3.类型约束where
        //internal class Generic<T> where T : struct  /*只能是值类型，由struct定义*/
        //internal class Generic<T> where T : class   /*只能是引用类型，由class定义*/
        //internal class Generic<T> where T : new()   /*必须包含一个公共的无参构造函数，可以new()*/
        //internal class Generic<T> where T : Person  /*只能是Person及其子类*/
        //internal class Generic<T> where T : ISort   /*只能是ISort及其实现*/
        //用法:I.可以为多个Type parameter定义不同的约束;II.可以为同一个Type parameter定义多个（不冲突的）约束
        // class MimicStack<T, TKey>
        ////where T : class, struct  冲突了，不行
        //where T : ILearn, new()
        //where TKey : new()
        //4.泛型的继承
        //I. 一个非泛型类不能继承一个还没有具象化的泛型类;
        //II. 可以继承具象化的泛型类;
        //III. 泛型类可以继承一个泛型类;
        //IV. 泛型类可以继承一个非泛型类;
        //internal class Major { }
        //internal class SQL : Major { }
        //internal class Person<T> where T : Major { }
        //当一个泛型类作为父类（被使用）的时候，一定要指明具体的类型参数
        //internal class Teacher : Person<Major> { }
        //internal class Teacher : Person<T> { }
        //除非子类和父类都是泛型类，且共用一个泛型参数
        //internal class Teacher<T> : Person<T> where T : Major { }
        //Teacher<T>和Teacher有没有什么关系？
        //++++++++++++++++++++++
        //其他的都和普通类没有区别
        //interface ICode { }
        //internal class Student : Person<Major>, ICode { }
        //internal class GoodStudent : Teacher { }
        //当泛型类变得冗长:     //名称空间
        //using Teacher = Junior.Person<Junior.Major>;
        //Console.WriteLine(typeof(Teacher) == typeof(Person<Major>));

        //C# 高级进阶 ||  (二)泛型应用：Nullable / ?? / ?.
        //1.可空类型(Nullable)——方便和数据库交互;比如性别（IsMale），通常用bool值，但可以有三个值：男、女和“没填写”
        //在值类型后面加一个问号（?），就可以声明一个该值类型相对象的可空类型。可空类型可以为null值
        //  int? i = 18;
        //  int j = i.Value;
        //  i = null;
        //  Console.WriteLine(i.HasValue);
        //2.null运算
        //null值替代运算符 ??    不为null值时，返回原值；为null值时，返回 ?? 后替代值
        //SQL.Teacher = SQL.Teacher ?? new Teacher();
        //null条件运算符?. 和?[] 只有.或者 [] 前面的变量不为null值的时候，才进行取值；否则返回null值
        //Console.WriteLine(SQL.Teacher?.Name ?? "course SQL has no teacher");

        //C# 高级进阶 ||  (三)集合：List / Dictionary / ER模型 ……
        //student.Add("xm");   //添加到最后
        //student.Insert(3, "xm");   //插入到指定位置
        //
        //student.Remove("xr");
        //student.RemoveAt(0);
        //student.clear();
        //
        //student[0] = "dfg";
        //
        //Console.WriteLine(student.BinarySearch("dfg"));
        //Console.WriteLine(student.IndexOf("jym"));
        //Console.WriteLine(student.Contains("jym")); 返回布尔值
        //其他集合:
        //Dictionary<string, int> scores = new Dictionary<string, int>();     //键值对集合
        //scores["atai"] = 85;
        //scores["zm"] = 95;
        //scores["wpz"] = 90;
        //+++++++++++++++++++
        //scores = new Dictionary<string, int>
        //{
        //    {"atai", 85 },
        //    {"zm", 95 }
        //};
        //+++++++++++++++++++
        //scores.Add("wpz", 90);
        //scores.Remove("wpz");
        //scores.ContainsKey("zm");
        //+++++++++++++++++++
        //Console.WriteLine(scores["atai"]);
        //LinkedList<T>：单向链表
        //Queue<T>：队列
        //SortedSet<T>：有序Set
        //ER模型:Entity-Releationship Model
        //+
        //单向/双向引用
        //++
        //一对一（1:1），1个老师只有1个学生 且 1个学生也只有1个老师
        //一对多（1:n），1个老师教多个学生 且 1个学生只能有1个老师
        //多对多（n:n），1个老师教多个学生 且 1个学生可以有多个老师
        //+++
        //内容决定对象间的关系本质;形式推定(单向/双向)

        //C# 高级进阶 ||  (四)集合：foreach背后
        //foreach (var item in collection)
        //{
        //   Console.WriteLine(item);
        //}
        //1.foreach和for循环的区别:
        //for循环的迭代基础是累加器和下标（i++）;foreach循环的基础是迭代器的MoveNext();foreach里的item不能被赋值（assign）  
        //2.底层实现:实现IEnumerable：该接口能返回IEnumerator：具有MoveNext()方法;
        //3.yield(关键字):让自定义集合实现foreach遍历的方法
        //一般来说当我们创建自定义集合的时候为了让其能支持foreach遍历，就只能让其实现IEnumerable接口（可能还要实现IEnumerator接口),
        //但是我们也可以通过使用yield关键字构建的迭代器方法来实现foreach的遍历，且自定义的集合不用实现IEnumerable接口;
        //注意--虽然不用实现IEnumerable接口 ，但是迭代器的方法必须命名为GetEnumerator()，返回值也必须是IEnumerator类型
        //public IEnumerable<int> GetSingleDigitNumbers()
        //{
        //    yield return 0;
        //    yield return 1;
        //    yield return 2;
        //    yield return 3;
        //    yield return 4;
        //}
        //简单的迭代器方法
        //public IEnumerator GetEnumerator()
        //{
        //    foreach (Person item in pers)
        //    {
        //        //yield return 作用就是返回集合的一个元素,并移动到下一个元素上
        //        yield return item;
        //    }
        //}
        //方法返回的是一个匿名的（系统生成的）IEnumerable<int> 实例，实例中按顺序存储上述数据
        //方法体中多个yield return不会冲突，但不能同时有return和yield return
        //还可以使用 yield break; 中断循环
        //4.扩展方法(Extension)-在不修改类的情况下给类添加一个实例方法
        //特点:
        //I. 在原有类（如IEnumerable<int>）之外另外声明一个类（如：Enumerable，以下简称“扩展类”），
        //   扩展类必须是静态（static）的，类名其实并不重要（不会被用到）
        //II.在扩展类中声明static方法,方法的第一个参数必须带 this 关键字，且后跟一个原有类类型的参数（通常命名为source）
        //III. 于是可以直接用扩展类实例调用这个方法，调用时应忽略第一个this参数
        //IV. 扩展方法仅在扩展类没有相应的实例方法时才会被调用
        //    即：如果扩展类中本身就有一个和扩展方法签名相同的方法，会直接调用实例方法而不是扩展方法

        //C# 高级进阶 ||  (五)委托和事件
        //1.委托（delegate）
        //public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
        //委托是一种（特殊的）类型;代表的是方法（的引用），所以需要指定参数和返回值;代表的是方法（的引用），所以需要指定参数和返回值
        //2.Func和Action
        //Func：有返回值的方法。使用泛型参数依次表示方法参数，最后一个表示方法返回值;
        //Action：没有返回值的方法。使用泛型参数依次表示方法参数;
        //3.事件(event):委托是事件的基础，事件又对委托进行了封装
        //public class Button
        //{
        //    //定义事件，用于发布
        //    public event EventHandler OnClick;    //注意：EventHnadler是一个委托
        //    public void click()
        //    {
        //        if (OnClick != null)
        //        {
        //            OnClick(this, new EventArgs());
        //        }
        //    }
        //}
        //     实例化一个发布了OnClick事件的button
        //     Button btn = new Button();
        //     事件被btn_click订阅，即：当这个btn被click时调用btn_click()方法
        //     btn.OnClick += btn_click;
        //
        //private static void btn_click(object sender, EventArgs e)
        //{
        //    Console.WriteLine("点我干啥呢？");
        //}
        //     事件被触发
        //     btn.click();

        //C#高级进阶  || (六)匿名方法 / Lambda / 闭包
        //1.匿名委托
        //Calculate ai = delegate (int x, int y)
        //{
        //    Console.WriteLine($"just a piece of cake: {x}/{y}={x / y}");
        //};
        //ai(8, 3);
        //2.Lambda表达式
        //将匿名方法的delegate去掉，使用箭头（=>）替代，就是Lambda表达式了
        //Calculate ai = /*delegate*/ (int x, int y) =>  /*添加=>*/
        //{
        //    Console.WriteLine($"just a piece of cake: {x}/{y}={x / y}");
        //};
        //Lambda还提供了很多简写方式（语法规则）：
        //可以不指定参数类型
        //Action<string, string> d = (x, y) => { Console.WriteLine(x + "欢迎您，" + y); };
        //
        //一行方法体实现，可以不用{ }
        //省略掉花括号
        //Action d = () => Console.WriteLine("源栈欢迎您");
        //
        //一个参数，可以不用（）；没有参数，还是要有一个空括号
        //Action<string> d = x => Console.WriteLine(x + "欢迎您");
        //
        //而且不能写return
        // //要return就必须要花括号{}
        // //Func<int, int> square = a => { return a * a; }; 
        //Func<int, int> square = a => a * a;
        //3.闭包:一种语法现象
        //外部方法不能使用匿名函数中的变量;匿名方法能够使用（并改变）其外部方法的变量/参数
        //class Closure
        //{
        //    public static Calculate GetAI()
        //    {
        //        int a = 10, b = 20;
        //        Calculate ai = delegate/* (int x, int y)*/
        //        {
        //            return a + b /*+ x + y*/;
        //        };
        //        return ai;
        //    }
        //}
        //4.自定义myAny()
        //student.Any(s=>s.age>20)
        //statc void Main(string[] args)
        //{
        //    IList<Student> students = new List<Student>
        //    {
        //       new Student{age=18},
        //       new Student{age=20},
        //       new Student{age=18},
        //       new Student{age=18},
        //    };
        //    students.myAny(s=>s.age>20);
        //}
        //
        //public static class MyExtension 
        //{
        //    public static bool myAny<T>(this IList<T> source, Func<T, bool> predicate) 
        //    {
        //        foreach (T item in source)
        //        {
        //            if (predicate(item))
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //}

        //C#高级进阶  || (七)（泛型）变体：协变和逆变
        //在声明（不是使用）
        //泛型接口和委托（也只能是接口和委托）时
        //可以在类型参数添加（in或out）“变体”的指示
        //协变（Covariance）：out，子类可以替父类，代表：IEnumerable<T>, IEnumerator<T>, IQueryable<T>, and IGrouping<TKey, TElement>
        //逆变（Contravariance）：in，父类可以替子类，代表： IComparer<T>, IComparable<T>, and IEqualityComparer<T>
        //不变（Invariance）：无指示。只能使用同一个类型
        //准确描述：一个类型参数声明了协变out（或逆变in）的泛型接口，用父类（或子类）做类型参数时，可以接受子类（或父类）做类型参数的实例
        //变体:变体不能用于泛型类和泛型方法和值类型，仅仅支持于引用转换
        //为什么需要变体？——主要是为了让被定义的泛型接口和委托，可以有更广泛的应用
        //参数都是in，输出都是out：——当使用Action/Func时，传入的参数都是调用方提供的，可以比预期的“大”（父类对象），但不能小；反之亦然
        //委托:
        //委托可以接受比它的方法目标更加具体的参数类型——逆变; 委托的目标方法可以返回比委托描述更加具体的类型的返回结果——协变

        //C#高级进阶  || (八)Linq-1：where/order/group/select
        //1.Linq（Language-Integrated Query）针对于集合的操作属于Linq to Object。但所有的Linq使用统一的查询表达式（query expression）
        //var excellent = from s in students
        //                where s.Score > 90
        //                select s;
        //说明:   以 from 开头;    数据源（source data）必须是IEnumerable或它的子类;     以select 或 group 结尾
        //强类型:无论是表达式内部，还是表达式结果,如果数据源为非泛型集合：需要在from之后指定类型
        //2.where(过滤条件)
        //可选。如果不要，就会返回全部集合元素
        //所有能返回bool值的表达式都可以用作where条件（Linq to Object）:
        //                  大于（>）小于（<）等于（==）  不等于（!=）
        //                  包含（Contains）、StartWith()
        //                  数量（Count）、Length...
        //可以使用多个条件（||、&&或多个where）进行组合:
        //var excellent = from s in students
        //                    //where s.Majors.Count > 2
        //                    //where s.Majors.Contains(csharp)
        //                    //where !s.Majors.Contains(Javascript)
        //                where s.Name.StartsWith('王') && s.Score > 80
        //                select s;
        //3.order(排序)   关键字:orderby
        //var excellent = from s in students
        //                    //orderby s.Score ascending  //按Score升序（默认）
        //                orderby s.Name descending    //按Name降序
        //                select s;
        //4.group(分组)   将具有相同属性的元素归为一组
        //var groupedMajor = from m in majors
        //                   group m by m.Teacher;
        //分组后的结果:IEnumerable<IGrouping<Teacher, Major>>,关键：
        //   IGrouping<Teacher, Major> 里的Key（Teacher：分组依据）
        //   迭代IGrouping<Teacher, Major> 获得（iterate）的值（Major）
        //   foreach (var item in groupedMajor)
        //   {
        //      Console.WriteLine(item.Key.GetType() + ":" + item.Key.Name);
        //      foreach (var i in item)
        //      {
        //          Console.WriteLine(i.GetType() + ":" + i.Name);
        //      }
        //      Console.WriteLine();
        //   }
        //5.select(投影)
        //从原有结果集中取出或增加若干属性重新组合成新的集合
        //var excellent = from s in students
        //                select s.Name;
        //还可以用匿名对象:
        //var excellent = from s in students
        //                select new /*ShortStudentInfo*/
        //                {
        //                    /*Name = */
        //                    s.Name,
        //                    /*Score = */
        //                    s.Score
        //                };
        //常见面试题:select与where的区别:
        //where是“横向”的操作（一个学生一行），比如从10个学生中取出3个年龄大于20岁的学生，取出来的还是学生；
        //select是“纵向”的操作（学生的一个属性算一列），比如取出学生的姓名和年龄，取出来的就不是学生了，而是一个属性或者多个属性的组合
        //var groupedMajor = from m in majors
        //                   group m by m.Teacher //到此为止，得到分组结果集
        //                                        //接下来对分组结果集再运算（统计）
        //           into gm              //into类似于命名，将之前的结果集命名为：gm
        //                   select new          //利用投影
        //                   {
        //                       gm.Key.Name, //老师的名字
        //                       gm.Count()   //统计结果
        //                   };
        //可以用自定义类型:
        //public class Result
        //{
        //    public string teacher { get; set; }
        //    public int count { get; set; }
        //}
        //然后select
        //select new Result           //利用投影
        //{
        //    teacher = gm.Key.Name,  //老师的名字
        //    count = gm.Count()      //统计结果
        //};
        //直接使用匿名类
        //select new           //没有类名了
        //{
        //    teacher = gm.Key.Name, 
        //    count = gm.Count()
        //};
        //转化为Dictionary
        //var 1staic=stat.ToDictionary(s=>s.key,s=>s.count);然后foreach...
        //6.实现泛型比较的三种方法：
        //public static void Prompt<T>(T a, T b, Func<T, T, bool> func)
        //{
        //    if (func(a, b))
        //    {

        //    }
        //}
        //++
        //public static void Prompt<T>(T a, T b) where T : IComparable
        //{
        //    if (a.CompareTo(b) > 0)
        //    {
        //
        //    }
        //}
        //++
        //public static void Prompt<T>(T a, T b, IMyCompare<T> compare)
        //{
        //    if (compare.Compare(a, b))
        //    {
        //
        //    }
        //}
        //+
        //public interface IMyCompare<T>
        //{
        //    bool Compare(T a,T b)
        //}

        //C#高级进阶  || (九)Linq-2：join和let
        //1.join(连接)——将多个集合连接起来进行查询，以获得额外的条件或结果集
        //例子：Teacher中添加一个Id属性，Major中不再记录Teacher对象，而是TeacherId--内连接
        //var majors = from m in majors
        //             join t in teachers
        //             on m.Teacher equals t      //equals非常重要，不能使用 == 替代
        //             where t.Name == "小鱼"
        //             select m;
        //利用投影
        //             var result = from m in majors
        //                 join t in teachers
        //                    on m.TeacherId equals t.Id
        //                 select new 
        //                 { 
        //                    t.Id,
        //                    teacherName = t.Name, 
        //                    majorName = m.Name
        //                 };
        //然后foreach
        //外连接：所有左边的（第一个）集合元素都必须返回，哪怕在右边的（第二个）集合无法匹配到（无法匹配就显示为null）。需要使用DefaultIfEmpty
        //var majors = from t in teachers    //List<Teacher>放在第一位
        //             join m in majors
        //             on t equals m.Teacher into mt            //又见into，mt是IEnumerable<Major>
        //             from result in mt.DefaultIfEmpty()       //调用了DefaultIfEmpty()并再次from
        //             select new { teacher = t.Name, major = result?.Name ?? "没有课程" };
        //交叉连接(cross join)--左右两边的集合进行无条件的多对多交叉连接（执行笛卡尔乘积），使用多个from实现
        //var result = from t in teachers
        //             from m in majors
        //             select new { teacher = t.Name, major = m.Name };
        //多个字段——使用匿名类进行比较
        //var majors = from t in new List<Teacher> { fg, fish }
        //             join m in new List<Major> { csharp, SQL, Javascript, UI }
        //             //使用组合关键字的匿名类进行比较
        //             on new { name = t.Name, age = t.Age } equals new { name = m.TeacherName, age = m.TeacherAge }
        //             select new { teacher = t.Name, major = m.Name };
        //2.let子句——将查询过程切分为若干个过程，每一个过程存储一个子结果集，以供之后的查询使用
        //var majors = from s in students
        //             let ms = s.Majors   //把所有的 Major 先暴露出来
        //             from m in ms        //后面就可以使用 let 指定的 ms
        //             select new { student = s.Name, major = m };
        //另一种写法:
        //var studentsMajors = from s in students
        //                     from m in majors
        //                     where s.Majors.Contains(m)
        //                     select new { student = s.Name, major = m };
        //3.延迟加载（deferred）——Linq的查询表达式只是一个表达式，并不存储查询结果，直到被foreach调用
        // 或者，使用ToList()，ToArray()等方法强制立即执行（Forcing Immediate Execution）：
        //     var result = from t in teachers
        //                  select t;
        // ((List<Teacher>) teachers).Add(new Teacher { Name = "new" });
        //teachers.ToList().Add(new Teacher { Name = "new" });   //比较这两种方式Console.WriteLine(teachers.Count());
        //foreach (var item in result)
        //{
        //   Console.WriteLine(item.Name);
        //}
        //作用:在进行多条件查询拼接时提高性能，使用最终表达式进行查询
        //var result = from t in teachers
        //             select t;

        //    if (true)
        //    {
        //        result = from r in result
        //                 where r.Age > 20
        //                 select r;
        //    }
        //获得up-to-data

        //C#高级进阶  || (十)Linq方法
        //1.where:
        //var excellent = students.Where(s => s.Score > 90);
        //2.orderby
        //var excellent = students
        //     //.OrderBy(s => s.Name)
        // .OrderByDescending(s => s.Score);
        //3.Group
        // var groupedMajor = majors.GroupBy(m => m.Teacher);
        //4.Select
        //var excellent = students.Select(s => s.Name);
        //5.Join
        //var mj = majors.Join(teachers, m => m.TeacherName, t => t.Name,
        //     (m, t) => new
        //     {
        //         major = m.Name,
        //         teacher = t.Name
        //     });
        //6.SelectMany
        //var sm = students.SelectMany(
        //           s => s.Majors,              //指示取出students里的所有Major
        //           (s, m) => new { s, m.Name }      //组合student和major
        //       )
        //       .Where(s => s.Name.ToLower().Contains("s"))  //在上述结果集中筛选
        //       ;
        //7.其他方法:
        //取单个：First/Single/Last(OrDefault)
        //聚合函数：Sum/Count/Min/Max/Average
        //顺序相关：Reverse，一定要非常慎重的使用

        //C#高级进阶  || (十一)异常处理
        //1.什么是异常:本来就是那些“正常情况下不会出现”、且“出现了之后‘我’也无法处理”的问题，并且程序不应该继续执行（应该中断）
        //2.抛出异常:throw new Exception("成绩只能在0-100分之间");自定义异常需要继承Excepetion
        //3.try...catch...finally:
        //被抛出的异常，（如果没有被处理/捕获）会直接传递给它的调用者，再由调用者传递给它的调用者，...，直到程序最顶层调用，程序崩溃
        // try   //尝试
        //{
        //    SLevel level = Map(101);
        //}
        //catch (FileNotFoundException)  //捕获
        //{
        //    //如果是FileNotFoundException
        //    //记录到日志，不再抛出
        //}
        //catch (IndexOutOfRangeException)
        //{
        // //如果是IndexOutOfRangeException
        // //发送Email给维护人员，不再抛出
        //}
        //    catch (Exception)
        //{
        //   //其他异常处理
        //    throw;      //将异常再次抛出
        //}
        //注意：越是具体（子类）的异常，越是要放在前面，否则编译无法通过；
        //     finally：无论有无异常（即使有return）都要执行的代码（比如关闭文件流）——配合catch：没有catch就无法正常使用，断点不会被击中
        //4.使用注意:
        //异常会带来较大的资源开销（性能损耗），所以要尽可能避免异常被抛出（不是不写throw exception的代码）
        //不要使用exception做为分支判断条件
        //尽可能的使用具体的、.NET现有的异常





























    }
}
