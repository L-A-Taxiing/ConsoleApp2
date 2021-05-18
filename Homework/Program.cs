using Homework.OO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    //enum Role
    //{
    //    Student = 1,
    //    TeacherAssist = 2,
    //    TeamLeader = 4,
    //    DormitoryHead = 8,
    //}
    internal struct People
    {
        public int _number;
        public People(int number)
        {
            _number = number;//必须给_number赋值，不然会报错；
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]//指定只能使用于类和方法;
    internal class OnlineAttribute : Attribute
    {
        public OnlineAttribute()
        {

        }
        public OnlineAttribute(int version)
        {
            Version = version;
        }
        public int Version { get; set; }
    }

    [Online(Version = 3)]
    internal class animals
    {
        [Online]
        internal void learn() { }
        public string name { get; set; }

    }


    class Program
    {

        static void Main(string[] args)
        {

            

            //5.在Main()函数调用ContentService时，捕获一切异常，并记录异常的消息和堆栈信息
            try
            {
                ContentService contentService = new ContentService();
                contentService.Publish(new Problem {Author=new User(),Reward=-100,Id=81194});
            }
            catch (Exception e)
            {
                Console.WriteLine("发现错误:"+e.ToString());
            }






            //在之前“文章 / 评价 / 评论 / 用户 / 关键字”对象模型的基础上，添加相应的数据，然后完成以下操作：
            //将之前作业的Linq查询表达式用Linq方法实现
            //找出每个作者最近发布的一篇文章
            //为求助（Problem）添加悬赏（Reward）属性，并找出每一篇求助的悬赏都大于5个帮帮币的求助作者
            User fg = new User() { Name = "飞哥" };
            User fish = new User() { Name = "小鱼" };
            IEnumerable<User> users = new List<User> { fg, fish };


            KeyWord key1 = new KeyWord { Name = "C#" };
            KeyWord key2 = new KeyWord { Name = "SQL" };
            KeyWord key3 = new KeyWord { Name = ".Net" };
            IEnumerable<KeyWord> keyWords = new List<KeyWord> { key1, key2, key3 };

            IList<Article> articles = new List<Article>()
            {
                new Article()
                {
                    Title = "人人都不是程序员",
                    Author = fg,
                    PublishTime = new DateTime(1999,12,31),
                    KeyWords = new List<KeyWord>() { key1 },
                    Comments = new List<Comment<Article>>(){ new Comment<Article> { },new Comment<Article> { } }
                },
                new Article()
                {
                    Title = "不折腾",
                    Author = fg,
                    PublishTime = new DateTime(2019,1,1),
                    KeyWords = new List<KeyWord>() { key2},
                    Comments = new List<Comment<Article>>() { new Comment<Article> { } }
                },
                new Article()
                {
                    Title = "小鱼吐泡泡",
                    Author = fish,
                    PublishTime = new DateTime(2020,01,01),
                    KeyWords = new List<KeyWord>() { key3 },
                    Comments = new List<Comment<Article>>() { new Comment<Article> { }, new Comment<Article> { } }
                },
                new Article()
                {
                    Title = "小鱼吃大鱼",
                    Author = fish,
                    PublishTime = new DateTime(2099,12,31),
                    KeyWords = new List<KeyWord>() { key1,key3 },
                    Comments = new List<Comment<Article>>() { new Comment<Article> { } }
                }
            };
            //1.找出“飞哥”发布的文章
            //var result = from a in articles
            //             where a.Author.Name == "飞哥"
            //             select a;
            //var result = articles.Where(a => a.Author.Name == "飞哥");
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Title);
            //}

            ////2.找出2019年1月1日以后“小鱼”发布的文章
            //var result = from a in articles
            //             where a.PublishTime > new DateTime(2019 / 01 / 01) && a.Author.Name == "小鱼"
            //             select a;
            //var result = articles.Where(a => a.PublishTime > new DateTime(2019 / 01 / 01) && a.Author.Name == "小鱼");
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Title);
            //}

            ////3.按发布时间升序 / 降序排列显示文章
            //var ascend = from a in articles
            //             orderby a.PublishTime ascending
            //             select a;
            //var ascend = articles.OrderBy(a => a.PublishTime);
            //foreach (var item in ascend)
            //{
            //    Console.WriteLine(item.Title);
            //}

            //var descend = from a in articles
            //             orderby a.PublishTime descending
            //             select a;
            //var descend = articles.OrderByDescending(a => a.PublishTime);
            //foreach (var item in descend)
            //{
            //    Console.WriteLine(item.Title);
            //}

            //4.统计每个用户各发布了多少篇文章
            //var result = from a in articles
            //             group a by a.Author;
            //var result = articles.GroupBy(a => a.Author);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Key.Name + item.Count());
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine($"{item.Key.Name}:{i.Title}");
            //    }
            //}

            //5.找出包含关键字“C#”或“.NET”的文章
            //var result = from a in articles
            //             where a.KeyWords.Any(k => k.Name == "C#" || k.Name == ".Net")
            //             select a;
            //var result = articles.Where(a => a.KeyWords.Any(k => k.Name == "C#" || k.Name == ".Net"));
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Title);
            //}

            //6.找出评论数量最多的文章
            //var result = from a in articles
            //             orderby a.Comments.Count descending
            //             select a;
            //var result = articles.OrderByDescending(a => a.Comments.Count);
            //foreach (var item in result)
            //{
            //    if (result.First().Comments.Count != item.Comments.Count)
            //    {
            //        return;
            //    }
            //    Console.WriteLine(item.Title);
            //}

            //7.找出每个作者评论数最多的文章
            //var result = from a in articles
            //             group a by a.Author into ga
            //             select ga.OrderByDescending(ga => ga?.Comments?.Count).FirstOrDefault();
            //Linq方法怎么写?

            //找出每个作者最近发布的一篇文章
            //var result = from a in articles
            //             group a by a.Author into ga
            //             select ga.OrderByDescending(ga => ga.PublishTime).FirstOrDefault();


            //为求助（Problem）添加悬赏（Reward）属性，并找出每一篇求助的悬赏都大于5个帮帮币的求助作者
            //IList<Problem> problems = new List<Problem>()
            //{
            //    new Problem(){ Reward=1, Author=fg},
            //    new Problem(){ Reward=6, Author=fg},
            //    new Problem(){ Reward=6, Author=fish},
            //    new Problem(){ Reward=10, Author=fish},
            //};
            //var result = from p in problems
            //             group p by p.Author into pa
            //             where pa.All(pa => pa.Reward > 5)
            //             select pa.Key.Name;
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


























































            //Person.InvokeDelegate();

            //Student zb = new Student();
            //zb.age = 18;
            //grow(zb);


            //Article lw = new Article() { Name = "Csharp" };
            //Article zl = new Article() { Name = "Sql" };
            //Article lzb = new Article() { Name = "JavaScript" };

            //KeyWord i = new KeyWord { Name = "编程基础" };
            //KeyWord j = new KeyWord { Name = "后台开发" };
            //KeyWord k = new KeyWord { Name = "编程基础" };

            //Comment<Article> zdh = new Comment<Article> { Name = "好" };
            //Comment<Article> xkp = new Comment<Article> { Name = "还行" };
            //Comment<Article> ht = new Comment<Article> { Name = "很不错" };

            //Appraise ag = new Appraise { Name = "Agree" };
            //Appraise dag = new Appraise { Name = "Disagree" };

            //一篇文章可以有多个评论
            //lw.Comments = new List<Comment<Article>> { zdh, xkp, ht };
            //zdh.Article = lw;
            //xkp.Article = lw;
            //ht.Article = lw;

            ////一个评论必须有一个它所评论的文章
            //xkp.Article = zl;
            //zl.Comments = new List<Comment<Article>> { xkp };

            ////每个文章和评论都有一个评价
            //lw.Appraise = ag;
            //zdh.Appraise = dag;


            ////一篇文章可以有多个关键字，一个关键字可以对应多篇文章
            //lw.KeyWords = new List<KeyWord> { i, j, k };
            //zl.KeyWords = new List<KeyWord> { j,k };
            //lzb.KeyWords = new List<KeyWord> { i, k };

            //i.Articles = new List<Article> {lw,lzb };
            //j.Articles = new List<Article> { lw, zl};
            //k.Articles = new List<Article> {lw,zl,lzb };














            //用泛型改造二分查找
            //Console.WriteLine(BinarySeek<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 9));

            //用泛型改造堆栈
            //MimicStack<object> lw = new MimicStack<object>(5);
            //Console.WriteLine(lw.Push("自"));
            //Console.WriteLine(lw.Push("由"));
            //Console.WriteLine(lw.Push("跑"));
            //lw.Push(new object[] { true, 98,"Go" });
            //Console.WriteLine(lw.Pop());

            //用泛型改造双向链表

            //用泛型改造"取数组中的最大值"
            //Console.WriteLine(FindMax<int>(new int[] {-1,99,98,56,42,87,666,233,234,100}));








            //在Content之外封装一个方法，可以修改Content的CreateTime和PublishTime
            //Content paper = new Content("阿Q正传");
            //DateTime datetime = new DateTime(2020, 1, 1);

            //SetCreateTime (paper, datetime);
            //SetPublishTime(paper, datetime);

            //将HelpMoneyChanged应用于Publish()方法,用反射获取Publish()上的特性实例，输出其中包含的信息
            //Attribute attribute = HelpMoneyChangedAttribute.GetCustomAttribute
            //(typeof(Problem).GetMethod("Publish"), typeof(HelpMoneyChangedAttribute));
            //Console.WriteLine(((HelpMoneyChangedAttribute)attribute).Amount);


            //1.确保文章（Article）的标题不能为null值，也不能为一个或多个空字符组成的字符串，而且如果标题前后有空格，也予以删除
            //Article lw = new Article("1234",new DateTime { });
            //lw.Title = "折腾";
            //lw.Title = null;
            //lw.Title ="     ";
            //lw.Title = "  折腾   ";

            //2.设计一个适用的机制，能确保用户（User）的昵称（Name）不能含有admin、17bang、管理员等敏感词。
            //User qh = new User("", "");
            //qh.Name = "admin";
            //qh.Name = "17bang";
            //qh.Name = "管理员";
            //qh.Name = "飞弟";

            //3.确保用户（User）的密码（Password）：
            //   长度不低于6
            //   必须由大小写英语单词、数字和特殊符号（~!@#$%^&*()_+）组成
            //User lw = new User("","1234");
            //lw.PassWordTrue("1234");
            //lw.PassWordTrue("1234A122");
            //lw.PassWordTrue("1234Ab122");
            //lw.PassWordTrue("1234Ab~!");

            //4.实现GetCount(string container, string target)方法，可以统计出container中有多少个target
            //GetCount("青葡萄,紫葡萄, 青葡萄没紫葡萄紫, 紫葡萄不吐葡萄皮, 不吃葡萄倒吐葡萄皮。", "葡萄");
            //GetCount("12344532446140014", "4");
            //GetCount("1", "1234");

            //5.不使用string自带的Join()方法，定义一个mimicJoin()方法，能将若干字符串用指定的分隔符连接起来，
            //比如：mimicJoin("-","a","b","c","d")，其运行结果为：a-b-c-d
            //MimicJoin("--", "编程改变命运励志照亮人生");
            //MimicJoin("-", "abcd");











            //Student jp = new Student();
            //int weight =(int)jp.GetType().GetField("_weight",BindingFlags.NonPublic|BindingFlags.Instance).GetValue(jp);
            //Console.WriteLine(weight);//反射拿私有字段的值

            //Attribute attribute = OnlineAttribute.GetCustomAttribute(typeof(animals), typeof(OnlineAttribute));
            //Console.WriteLine(((OnlineAttribute)attribute).Version);//将基类的Attribute对象强转为子类

            //Article aaa = new Article("people", DateTime.Now);
            //DateTime bbb = aaa.PublishTime;
            //Console.WriteLine(bbb);

            //在https://source.dot.net/中找到 Console.WriteLine(new Student()); 输出Student类名的源代码
            //Console.WriteLine(new Student());
            //    [MethodImplAttribute(MethodImplOptions.NoInlining)]
            //    public static void WriteLine(object? value)
            //    {
            //        Out.WriteLine(value);
            //    }
            //     public virtual void WriteLine(object? value)
            //{
            //    if (value == null)
            //    {
            //        WriteLine();
            //    }
            //    else
            //    {
            //        // Call WriteLine(value.ToString), not Write(Object), WriteLine().
            //        // This makes calls to WriteLine(Object) atomic.
            //        if (value is IFormattable f)
            //        {
            //            WriteLine(f.ToString(null, FormatProvider));
            //        }
            //        else
            //        {
            //            WriteLine(value.ToString());
            //        }
            //    }
            //}
            //public virtual string? ToString()
            //{
            //    return GetType().ToString();
            //}
            //public override string ToString() => "Type: " + Name;



            //思考dynamic和var的区别，并用代码予以演示
            //dynamic fg = "665";               //编译时不知道类型;
            ///*Console.WriteLine(fg-665);*/    //编译时不报错，绕过了类型检查
            //Console.WriteLine(fg.GetType());  //注释掉第二行，输出时知道是string 类型;

            //var fd = 666;                   //编译时就已经确定类型;
            //Console.WriteLine(fd.GetType());//输出也是int类型

            //构造一个能装任何数据的数组，并完成数据的读写
            //object[] arraylist= {1,2,"叶子",98.7,true };
            //for (int i = 0; i < arraylist.Length; i++)
            //{
            //    Console.WriteLine(arraylist[i]);
            //}








            //枚举调用
            //User qh = new User("", "");
            //qh.Tokens = new TokenManager();       //没有这一行会报错;返回为null值
            //qh.Tokens.Add(Token.Admin);
            //qh.Tokens.Remove(Token.Newbie);
            //qh.Tokens.Has(Token.Registered);

            //Student tlzz = new Student
            //{
            //    Roles = (int)Role.Student | (int)Role.TeamLeader
            //};
            //tlzz.Roles = tlzz.Roles | (int)Role.DormitoryHead;
            //tlzz.Roles = tlzz.Roles ^ (int)Role.Student;
            //Console.WriteLine((tlzz.Roles & (int)Role.TeamLeader) == (int)Role.TeamLeader);




            // 用代码证明struct定义的类型是值类型
            //People people/*=new People()*/;
            //people._number = 10; /*此处设断点，展开会发现people被声明时已经有_number了*//*将struct改成class会直接报错*/
            //Console.WriteLine(people._number);//第二行注释掉会报错-未赋值;需要new一下，跑结果为默认值

            //日/周/月的调用;
            //Console.WriteLine(time.GetDate(new DateTime(2021, 4, 24), 7));
            //Console.WriteLine(time.GetDate(new DateTime(2021, 2,29 ), 7));//不存在的日期会发生运行时错误;

            //按周排列显示每周的起始日期的调用;
            //time.GetWeeks(time.GetFirstWeek(2019));

            //Console.WriteLine(DateTime.Now.DayOfWeek);

            //TimeSpan span = DateTime.Now - new DateTime(2020, 4, 24);
            //Console.WriteLine(span.Days);//365
            //Console.WriteLine(span.TotalDays);//365.893690837
            //Console.WriteLine(span.Hours);//21
            //Console.WriteLine(span.TotalHours);//8781.4485689



            //Console.WriteLine(DateTime.Now.Hour);
            //int i = 10;
            ////i++;
            ////Console.WriteLine(i++);
            //Console.WriteLine(++i);
            //DateTime MimicNow = new DateTime(2021,4,24,14,19,50);
            //Console.WriteLine(MimicNow);
            //Console.WriteLine(1 | 0);
            //Console.WriteLine(3| 5);
            //Console.WriteLine( int.Parse("23")  ); 
            //int i = 18;
            //int j = i;
            //j = 20;
            //Console.WriteLine(i);

            //int age = 18;
            //grow( age);
            //Console.WriteLine(age);

            //Student qh = new Student();
            //qh.age = 20;
            //grow(qh);
            //Console.WriteLine(qh.age);

            //Content zt = new Article ("编程开发语言");
            //Content sug = new Suggest("反馈");
            //函数作业：方法基础、声明、调用、返回值；第二题的调用
            //Double[] grade = new double[] { 59.9, 78.5, 82.68, 99.9, 56.5, 72.9 };
            //Console.WriteLine(Math.Round(GetAverage(grade), 2));
            //第三题的调用
            //GuessMe();

            //二分查找：调用
            //Console.WriteLine(FindNum(new int[] { 2, 7, 8, 9, 21, 43, 95 }, 7));

            //快速排序
            //quickSort(new int[] { 23, 15, 37, 89, 2, 21, 43, 9, 56 }, 0, 8);

            //C#：面向过程：方法进阶：值/引用传递
            //1.利用ref调用Swap()方法交换两个同学的床位号
            //int a = 201, b = 202;
            //Swap(ref a, ref b);
            //Console.WriteLine("夏康平的床号是：" + a);
            //Console.WriteLine("姜鹏的床号是:" + b);
            //2.将登陆的过程封装成一个方法LogOn()，调用之后能够获得：
            //  1.true / false，表示登陆是否成功
            //  2.string，表示登陆失败的原因
            //if (LogOn("姜鹏","0000",out string reason))
            //{
            //    Console.WriteLine("登录成功");
            //}
            //else
            //{
            //    Console.WriteLine(reason);
            //}
            //C#：面向过程：方法进阶：参数：重载/可选/params
            //1.定义一个生成数组的方法：int[] GetArray()，其元素随机生成从小到大排列。利用可选参数控制：
            //  最小值min（默认为1）
            //  相邻两个元素之间的最大差值gap（默认为5）
            //  元素个数length（默认为10个）
            //GetArray();
            //var array = GetArray();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}
            //2.实现二分查找，方法名BinarySeek(int[] numbers, int target)：
            //  传入一个有序（从大到小 / 从小到大）数组和数组中要查找的元素
            //  如果找到，返回该元素所在的下标；否则，返回 - 1
            //int end=BinarySeek(new int[] { 1, 2, 3, 4, 5, 6, 7, 8,9 }, 7);
            //Console.WriteLine(end);

            //C#面向过程:其他类成员:构造函数/属性/索引器/析构函数
            //1.将之前User / Problem / HelpMoney类的字段封装成属性，其中：
            //    1.user.Password在类的外部只能改不能读
            //    2.如果user.Name为“admin”，输入时修改为“系统管理员”
            //    3.problem.Reward不能为负数
            //2.调用这些类的有参 / 无参构造函数，生成这些类的对象，调用他们的方法
            //3.一起帮的求助可以有多个（最多10个）关键字，请为其设置索引器，以便于我们通过其整数下标进行读写。
            //4.设计一种方式，保证：
            //    1.每一个Problem对象一定有Body赋值
            //    2.每一个User对象一定有Name和Password赋值

            //C#-面向对象：静态和实例
            //1.定义一个仓库（Repoistory）类，用于存取对象，其中包含：
            //一个int类型的常量version;一个静态只读的字符串connection，以后可用于连接数据库;思考Respoitory应该是static类还是实例类更好
            //2.考虑求助（Problem）的以下方法/属性，哪些适合实例，哪些适合静态，然后添加到类中：
            //Publish()：发布一篇求助，并将其保存到数据库;Load(int Id)：根据Id从数据库获取一条求助;Delete(int Id)：根据Id删除某个求助;repoistory：可用于在底层实现上述方法和数据库的连接操作等
            //3.设计一个类FactoryContext，保证整个程序运行过程中，无论如何，外部只能获得它的唯一的一个实例化对象。（提示：设计模式之单例）
            //4.想一想，为什么Publish()方法不是放置在User类中呢？用户（user）发布（Publish）一篇文章（article），不正好是user.Publish(article)么？
            //5.自己实现一个模拟栈（MimicStack）类，入栈出栈数据均为int类型，包含如下功能：
            //出栈Pop();弹出栈顶数据;入栈Push();可以一次性压入多个数据;出/入栈检查，如果压入的数据已超过栈的深度（最大容量），提示“栈溢出”,如果已弹出所有数据，提示“栈已空”



            // C#面向对象 多态 
            // 添加一个新类ContentService，其中有一个发布（Publish()）方法：
            // 如果发布Article，需要消耗一个帮帮币
            // 如果发布Problem，需要消耗其设置悬赏数量的帮帮币
            // 如果发布Suggest，不需要消耗帮帮币
            //Content content = new Article();
            //content.change();
            //content = new Problem();
            //content.change();
            //content = new Suggest();
            //content.change();





        }
        //在Content之外封装一个方法，可以修改Content的CreateTime和PublishTime
        public static void SetCreateTime(Content content, DateTime datetime)
        {
            typeof(Content).GetProperty("CreateTime",
            BindingFlags.Public | BindingFlags.Instance).SetValue(content, datetime);
        }

        public static void SetPublishTime(Content content, DateTime datetime)
        {
            typeof(Content).GetProperty("CreateTime",
            BindingFlags.Public | BindingFlags.Instance).SetValue(content, datetime);
        }
        static void say(string words)
        {
            words += "oh，yeah！";
        }
        //4.实现GetCount(string container, string target)方法，可以统计出container中有多少个target
        public static int GetCount(string container, string target)
        {
            int hastarget = -1;   //如果container没有找到target，则标记为-1;
            int count = 0;
            if (container.Length < target.Length)
            {
                Console.WriteLine("target不在container范围之内!");
                return -1;
            }
            for (int i = 0; i < container.Length;)
            {
                hastarget = container.IndexOf(target);
                if (hastarget != -1)
                {
                    container = container.Substring(hastarget + 1);
                    count++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"container中一共有{count}个target");
            return -1;
        }

        //5.不使用string自带的Join()方法，定义一个mimicJoin()方法，能将若干字符串用指定的分隔符连接起来，
        //比如：mimicJoin("-","a","b","c","d")，其运行结果为：a-b-c-d
        public static string MimicJoin(string separator, string input)
        {
            StringBuilder Str = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                Str = Str.Append(input[i]);
            }
            for (int j = 1; j < Str.Length; j++)
            {
                Str.Insert(j, separator);
                j += separator.Length;

            }
            Console.WriteLine(Str);
            return Str.ToString();
        }

        //用泛型改造二分查找
        public static int BinarySeek<T>(T[] numbers, T target) where T : IComparable
        {
            int left = 0, right = numbers.Length - 1;
            int result = -1;
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (target.CompareTo(numbers[middle]) == 0)
                {
                    result = middle;
                    break;
                }
                else if (target.CompareTo(numbers[middle]) > 0)
                {

                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            if (result != -1)
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        //用泛型改造"取数组中的最大值"
        public static T FindMax<T>(T[] Array) where T : IComparable
        {
            T Max = Array[0];
            for (int i = 1; i < Array.Length; i++)
            {

                if (Max.CompareTo(Array[i]) < 0)
                {
                    Max = Array[i];
                }
                //else continue
            }
            return Max;
        }
        static void grow(Student student)
        {
            student = new Student();   //仍然使用增加的这一行代码
            student.age++;
        }

        static void Homework()
        {
            //1.分别用for循环和while循环输出：1,2,3,4,5 和 1,3,5,7,9
            //    int[] names = { 1, 2, 3, 4, 5 };
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}

            //int[] names1 = { 1, 3, 5, 7, 9 };
            //int i = 0;
            //while (i < names1.Length)
            //{
            //    Console.WriteLine(names1[i]);
            //    i++;
            //}
            //2.用for循环输出存储在一维 / 二维数组里的源栈所有同学姓名 / 昵称
            //    string[] names = { "夏康平", "胡涛", "姜鹏", "龚廷义", "刘佳宝", "刘盛民", "秦慧" };
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}
            //string[,] names1 = new string[7, 1];
            //names1[0, 0] = "夏康平";
            //names1[1, 0] = "胡涛";
            //names1[2, 0] = "姜鹏";
            //names1[3, 0] = "龚廷义";
            //names1[4, 0] = "刘佳宝";
            //names1[5, 0] = "刘盛民";
            //names1[6, 0] = "秦慧";
            //for (int i = 0; i < names1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < names1.GetLength(1); j++)
            //    {
            //        Console.WriteLine(names1[i, j]);
            //    }
            //}


            //3.让电脑计算并输出：99 + 97 + 95 + 93 + ...+1的值
            //    int sum = 0;
            //for (int i = 1; i < 100; i += 2)
            //{
            //    sum += i;
            //}
            //Console.WriteLine(sum);


            //4.将源栈同学的成绩存入一个double数组中，用循环找到最高分和最低分
            //    double[] score = { 66.6, 59.9, 74.28, 82.34, 99.9 };
            //double max = score[0];
            //for (int i = 0; i < score.Length; i++)
            //{
            //    if (max < score[i])
            //    {
            //        max = score[i];
            //    }/*else continue*/
            //}
            //Console.WriteLine(max);

            //double min = score[0];
            //for (int i = 0; i < score.Length; i++)
            //{
            //    if (min > score[i])
            //    {
            //        min = score[i];
            //    }
            //}
            //Console.WriteLine(min);


            //5.找到100以内的所有质数（只能被1和它自己整除的数）
            //for (int j = 2; j <= 100; j++)
            //{
            //    bool found = true;
            //    for (int i = 2; i < j; i++)
            //    {
            //        if (j % i == 0)
            //        {
            //            found = false;
            //            break;
            //        }
            //    }
            //    if (found)
            //    {
            //        Console.WriteLine(j);
            //    }
            //}

            ////6.生成一个元素（值随机）从小到大排列的数组
            //int[] nums = new int[10];
            //Random elements = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    nums[i] = elements.Next(0, 100);
            //}
            //for (int i = 0; i < 9; i++)
            //{
            //    for (int j = i + 1; j < 10; j++)
            //    {
            //        if (nums[j] < nums[i])
            //        {
            //            int temp = nums[i];
            //            nums[i] = nums[j];
            //            nums[j] = temp;
            //        }
            //    }
            //}
            //foreach (int value in nums)
            //{
            //    Console.WriteLine(value);
            //}
            //foreach (数据类型 变量名 in 数组名),遍历数组中的元素
            //订正：
            //    int[] nums = new int[10];
            //int sum = 0;
            //Random elements = new Random();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    nums[i] = elements.Next(0, 100);
            //    sum += nums[i];
            //    Console.WriteLine(sum);
            //}




            //7.设立并显示一个多维数组的值，元素值等于下标之和。Console.Write()
            int[,] names = new int[3, 4];
            for (int i = 0; i < names.GetLength(0); i++)
            {
                for (int j = 0; j < names.GetLength(1); j++)
                {
                    int a = i + j;
                    names[i, j] = a;
                    Console.Write(names[i, j] + " ");
                    if (j == 3)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        static int FindNum(int[] ids, int target)
        {
            //int[] ids = { 2, 7, 8, 9, 21, 43, 95 };
            int left = 0, right = ids.Length - 1;
            int result = -1;
            //target = 7;
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (target == ids[middle])
                {
                    result = middle;
                    break;
                }

                else if (target > ids[middle])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            if (result != -1)
            {
                return (result);
            }
            else
            {
                return -1;
            }
        }

        static double GetAverage(double[] grade)
        {
            //2.计算得到源栈同学的平均成绩(精确到两位小数)

            double sum = 0;
            for (int i = 0; i < grade.Length; i++)
            {
                sum += grade[i];
            }
            double average = sum / grade.Length;
            return average;
        }

        static void GuessMe()
        {
            //3.完成“猜数字”游戏，方法名GuessMe()：
            //随机生成一个大于0小于1000的整数
            //用户输入一个猜测值，系统进行判断，告知用户猜测的数是“大了”，还是“小了”
            //没猜中可以继续猜，但最多不能超过10次
            //如果5次之内猜中，输出：你真牛逼！
            //如果8次之内猜中，输出：不错嘛！
            //10次还没猜中，输出：(～￣(OO)￣)ブ

            //Random nums = new Random();
            //int random = nums.Next(1, 1000);
            //Console.WriteLine("随机数是:"+random);
            //Console.WriteLine("请输入一个不超过1000的自然数");
            //for (int i = 1; i <= 10; i++)
            //{

            //    int Guessnum = Convert.ToInt32(Console.ReadLine());
            //    if (Guessnum != random)
            //    {
            //        if (i == 10)
            //        {
            //            Console.WriteLine("(～￣(OO)￣)ブ");
            //            return;
            //        }
            //        if (Guessnum > random)
            //        {
            //            Console.WriteLine($"太大了哟！(还剩{10 - i}次)");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"太小了呢!（还剩{10 - i}次）");
            //        }

            //    }
            //    else
            //    {
            //        if (i <= 5)
            //        {
            //            Console.WriteLine("你真牛逼！");
            //            Console.WriteLine($"恭喜你，答对了！只用了{i}次呢，棒棒哒！");
            //            return;
            //        }
            //        else if (i < 8)
            //        {
            //            Console.WriteLine("不错嘛！");
            //            Console.WriteLine($"恭喜你，答对了！只用了{i}次呢，棒棒哒！");
            //            return;

            //        }
            //        else
            //        {
            //            Console.WriteLine($"恭喜你，答对了！只用了{i}次呢，棒棒哒！");
            //            return;
            //        }
            //    }

            //}   
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static bool LogOn(string username, string password, out string reason)
        {
            reason = "用户名或者密码错误";
            if (username == "姜鹏" && password == "0000")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int[] GetArray(int min = 1, int gap = 5, int length = 10)
        {
            Random random = new Random();
            int[] array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    array[i] = min;
                }
                else
                {
                    array[i] = array[i - 1] + random.Next(gap + 1);
                }
            }
            return array;
        }



        //static void quickSort(int[] array, int low, int high)
        //{
        //    if (low >= high)
        //    {
        //        return;
        //    }
        //    int i = low, j = high, index = array[i];
        //    while (i < j)
        //    {
        //        while (i < j && array[j] >= index)
        //        { 
        //            j--;
        //        }
        //        if (i < j)
        //        {
        //            array[i++] = array[j]; 
        //        }
        //        while (i < j && array[i] < index)
        //        {
        //            i++;
        //        }
        //        if (i < j)
        //        {
        //            array[j--] = array[i]; 
        //        }
        //    }
        //    array[i] = index; 
        //    quickSort(array, low, i - 1); 
        //    quickSort(array, i + 1, high); 
        //}









    }







}


public class Repoistory
{
    const int VERSION = 1;
    static readonly string connection;
}






























































//之前的作业
////1+2+3+4
//累计求和
//int sum = 0;
//for (int i = 1; i < 5; i++)
//{
//    sum += i;
//}
//Console.WriteLine(sum);

//int[] studentids = { 8, 7, 9, 10, 2, 4, 5 };
//int sum = 0;
//for (int i = 0; i < studentids.Length; i++)
//{
//    sum += studentids[i];
//}
//Console.WriteLine(sum);

//求最大/小值
//int[] names = { 1, 2, 5, 7, 9, 11,-999 };
//int min = names[0];
//for (int i = 1; i < names.Length; i++)
//{
//    if (min>names[i])
//    {
//        min = names[i];
//    }/*else continue*/
//}
//Console.WriteLine(min);

//int[] studentids = { -88, 7, 9, 10, 2, 4, -500 };
//[2]--[4]
//int temp = studentids[4];
//studentids[4] = studentids[2];
//studentids[2] = temp;
//Console.WriteLine("studentids[2]:" + studentids[2] );
//Console.WriteLine("studentids[4]:" + studentids[4] );
//从大到小

//for (int i = 1; i < studentids.Length; i++)
//{
//    for (int j = 0; j < studentids.Length - i; j++)
//    {
//        if (studentids[j] < studentids[j + 1])
//        {
//            int temp = studentids[j];
//            studentids[j] = studentids[j + 1];
//            studentids[j + 1] = temp;
//        }
//    }
//}

//for (int i = 0; i < studentids.length; i++)
//{
//    Console.WriteLine (studentids[i]);
//}



//在数组中查找某个值，比如在int[]{ 1,2,8,4,5}; 找到8；
//找到了，输出：找到了，在数组中第几位；
//找不到，输出：没找到；
//int[] studentids = { 1, 2, 4, 4, 5 };
//bool found = false;
//for (int i = 0; i < studentids.Length; i++)
//{
//    if (studentids[i] == 4)
//    {
//        Console.WriteLine($"找到了，在数组中第{(i + 1)} 位");
//        found = true;
//    }/*else continue*/
//}
//if (!found)
//{
//    Console.WriteLine("没找到");
//}/*else nothing*/
//int[] studentids = { 1, 2, 8, 4, 5 };
//for (int i = 0; i < studentids.Length; i++)
//{
//    if (studentids[i] == 8)
//    {
//        Console.WriteLine($"找到了，在数组中第{(i + 1)} 位");
//        break; continue;
//    }
//    else
//    {
//        if (i == studentids.Length - 1)
//        {
//            Console.WriteLine("没找到");
//        }/*else nothing*/
//    }
//}


//观察一起帮登录页面，用if...else ...完成以下功能。
//用户依次由控制台输入：验证码、用户名和密码：
//如果验证码输入错误，直接输出：“*验证码错误”；
//如果用户名不存在，直接输出：“*用户名不存在”；
//如果用户名或密码错误，输出：“*用户名或密码错误”
//以上全部正确无误，输出：“恭喜！登录成功！”
//string captcha = "999";
//Console.WriteLine("请输入验证码");
//if (captcha != (Console.ReadLine()))
//{
//    Console.WriteLine("验证码错误");
//}
//else
//{
//    Console.WriteLine("Nothing");
//}
//string answer2 = Console.ReadLine();
//if (username != answer2)
//{
//    Console.WriteLine("用户名不存在");
//}
//else
//{
//    Console.WriteLine("请输入密码");
//    string answer3 = Console.ReadLine();
//    if (password != answer3)
//    {
//        Console.WriteLine("用户名或密码错误");
//    }
//    else
//    {
//        Console.WriteLine("恭喜！登陆成功!");
//    }

//作业：
//将源栈同学姓名 / 昵称分别：
//按进栈时间装入一维数组，
//按座位装入二维数组，
//并输出共有多少名同学。
//string[] students = new string[] { "阿泰", "母鸡","夏康平", "胡涛", "姜鹏", "周丁浩", "韩佳宝", "秦慧", "刘伟" };
//string[,] names = new string[4, 4];
//names[0, 0] = "阿泰";
//names[0, 1] = "母鸡";
//names[0, 2] = "夏康平";
//names[1, 1] = "胡涛";
//names[1, 2] = "姜鹏";
//names[1, 3] = "周丁浩";
//names[2, 0] = "韩佳宝";
//names[2, 2] = "秦慧";
//names[3, 3] = "刘伟";
//Console.WriteLine(students.Length);
//Console.WriteLine(names.Length);}


