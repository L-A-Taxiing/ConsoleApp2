using System;

namespace CSharp
{


    public class Animals<M>
    {
        public M Kind { get; set; }

    }
    public class Foods 
    { 
       public double Price { get; set; }

    }
    public class Program
    {

        static void Main(string[] args)
        {

            Animals<string> lw= new Animals<string>();
            lw.Kind = "青龙";

            Animals<Foods> my = new Animals<Foods>();
            my.Kind = new Foods();


          













            //int i = 18;







            //3.getFibonacci(0, 1);

            //4.quickSort(new int[] { 23, 15, 37, 89, 2, 21, 43, 9, 56 }, 0, 8);


            //1.int a = 20, b = 18;
            //swap(ref a, ref b);
            //Console.WriteLine(a);
            //Console.WriteLine(b);


            //2.int age = 18;
            //grow(ref age);
            //Console.WriteLine(age);


            //bool input = double.TryParse(Console.ReadLine(),out double input);
            //if (double.TryParse(Console.ReadLine(), out double input))//能够parse
            //{

            //    input += 10;
            //}
            //else
            //{
            //    Console.WriteLine("输入错误...");
            //}

            //buy(3,"可乐");
            //buy(5);



            //Console.WriteLine("Ceiling:" + Math.Ceiling(19.8));//向上取整 20;
            //Console.WriteLine("Floor:" + Math.Floor(19.8));//向下取整 19;
            //Console.WriteLine("Round:" + Math.Round(19.875, 2));

            //Console.WriteLine(new Random().Next(1000));
            //Random names = new Random();
            //int output = names.Next(1, 1000);
            //int a = new Random().Next(1, 123);

        }

        //static void buy() 
        //{
        //     buy("矿泉水");
        //}
        static void buy(double price,string water="矿泉水") //可选参数
        {
            Console.WriteLine("出门");
            Console.WriteLine("付钱买"+water);
            Console.WriteLine("回家");
        }

       

















































































        //方法的重载，buy返回的不同，按F12；
        //可选参数放在必须(required)参数后面,可选参数的默认值必须是“编译时”确定的，
        //比如：常量、字面值、default()表达式、new ValueType……
        //default是取required parameter的默认值，比如int;
        //可选和非可选参数之间不能构成"重载";



        //当方法的参数是数组的时候，我们可以在数组类型前面加一个关键字params;static void getMax(params int[] array)
        //这样，当我们调用该方法的时候，就可以（不是必须只能）直接传递数组元素了：
        //getMax(3, 9, 18, 23);
        ////等效于：
        //getMax(new int[] { 3, 9, 18, 23 });





        //static int Max(int a, int b)
        //{
        //    return (a > b) ? a : b;
        //}  条件运算符?    :



        //1.static void swap(ref int a, ref int b)
        //{
        //    int temp = a;
        //    a = b;
        //    b = temp;
        //}


        //2.static void grow(ref int a)
        //{
        //     a++;
        //}


        //3.static void getFibonacci(int a, int b)
        //{
        //    //终止条件
        //    if (b > 1000)
        //    {
        //        return;
        //    }

        //    Console.WriteLine(b);
        //    int sum = a + b;
        //    //递归的调用自己
        //    getFibonacci(b, sum);
        //}
















        //值传递＆引用传递
        //值传递：传递的是变量的值的“副本”，所以方法不改变变量本身;引用传递传递的是变量本身;ref标记在参数前和调用的时候;
        //1.ref传进去的参数必须事先赋值;out不必  2.ref传进去的参数可在函数内部直接使用，out不可——使用ref是为了改变传入参数，out是为了获得；
        //out常用于一个方法需要多个返回的时候（即：获取除了返回值以外的结果），比如类库中的TryParse：











        //可以使用同一个方法名，配以不同的参数“组合”（个数/类型/次序/传递方式ref）。但注意：
        //仅是参数名不同
        //仅是返回值不同
        //不能认为是方法的重载。







        //static void swap(int a, int b)
        //{
        //    swap(a, b);
        //}
        //在方法体中还可以调用方法自己，这被称之为递归（调用）。








        //四舍五入
        //Console.WriteLine("Ceiling:" + Math.Ceiling(19.8));
        //Console.WriteLine("Floor:" + Math.Floor(19.8));
        //Console.WriteLine("Round:" + Math.Round(19.875, 2));

        //取随机数
        //Console.WriteLine(new Random().Next(1000));














        //F12 进入方法说明;
        //函数声明要在class program中；
        //double——返回类型；  min——方法名；  double[]scores——参数——类型+名字；
        //返回类型和方法名都只能有一个且必须有一个，返回类型可为空"void";参数可以有多个，用逗号隔开；
        //只有一个return返回且必须返回;cw控制台，return返回到程序；
        //调用在 Main 函数里面；
        //F11 进入方法内部 or  在函数体设置断点;Call Stack窗口：查看方法被谁调用
        //方法名上面///可以自动生成注释;
        //console.writeLine(setGrade(98))----------------setgrade(98);
        //如果方法体只有一条return语句的话，可以简写成static int Add(int a, int b) => a + b;
        //截断式编程，少写一个else;

        //string[] names = {"迪迦", "高斯", "赛罗" };
        ////Console.WriteLine(names[1]);
        //Console.WriteLine(names.Length);
        //数组从0开始
        //int[][] students = new int[3][];
        //students[0] = new int[] { 1, 2 };
        //students[1] = new int[] { 3, 4, 5 };
        //students[2] = new int[5];
        //int[] i = students[1];
        //Console.WriteLine(i[1]);

        //string[] username;
        //username = new string[3] { "alxe", "bill","c"};
        //string[] username = { "alxe", "bill", "c" };
        //string[] username = new string[] { "alxe", "bill", "c" };

        //int[,] mda = new int[2, 1];
        //mda[0, 0] = 1;
        //mda[1, 1] = 2;
        //int[,] mda = { { 1, 2, 3 }, { 4, 5, 6 } };

        //int[][] age = new int[4][];
        //int[][] age = new int[2][] { new int[]{ 1, 2, 3 }, new int[]{ 5, 6, 7 } };
        //string[][] password = new string[2][] { new string[] { "am", "is", "are" }, new string[] { "wu" };

        //string[] names = new string[] { "火" };
        //string[,] location = new string[2, 4];
        //string[][] password = new string[2][] { new string[] { "qaq" }, new string[] { "qwq" } };

        //string name = "源栈", greet = "欢迎您";
        //Console.WriteLine(name+","+greet+"!");拼接
        //Console.WriteLine($"{name},{greet}!");内插
        //Console.WriteLine($"\"{name}\",{greet}!");转义
        //Console.WriteLine($"\\{name}\\,{greet}!");
        //Console.WriteLine(@"\\{name}\\,{greet}!");
        //Console.WriteLine(@$"\\{name}\\,{greet}!");
        //\r\n==》"+Environment NewLine+";\t
        //Console.WriteLine(17+"bang"+true);

        //string[] name = { "卢本伟", "Pdd", "大司马" };
        //for (int i = 0; i < name.Length; i++)
        //{
        //    Console.WriteLine(name[i]);
        //}
        //i++不在作用域内{ }
        //int[] studentIds = { 8, 7, 9, 10, 2, 4, 5 };
        //for (int i = 0; i < studentIds.Length; i++)
        //{
        //    if ((studentIds[i] == 10))
        //    {
        //        Console.WriteLine(studentIds[i]);
        //    }
        //}




        //4.static void quickSort(int[] array, int low, int high)
        //{
        //    if (low >= high)
        //    {
        //        return;
        //    }
        //    int i = low, j = high, index = array[i]; // 取最左边的数作为基准数
        //    while (i < j)
        //    {
        //        while (i < j && array[j] >= index)
        //        { // 向左寻找第一个小于index的数
        //            j--;
        //        }
        //        if (i < j)
        //        {
        //            array[i++] = array[j]; // 将array[j]填入array[i]，并将i向右移动
        //        }
        //        while (i < j && array[i] < index)
        //        {// 向右寻找第一个大于index的数
        //            i++;
        //        }
        //        if (i < j)
        //        {
        //            array[j--] = array[i]; // 将array[i]填入array[j]，并将j向左移动
        //        }
        //    }
        //    array[i] = index; // 将基准数填入最后的坑
        //    quickSort(array, low, i - 1); // 递归调用，分治
        //    quickSort(array, i + 1, high); // 递归调用，分治
        //}

        //static void quickSort(int[] array)
        //{
        //    if (array == null || array.Length == 0)
        //    {
        //        return;
        //    }
        //    quickSort(array, 0, array.Length - 1);
        //}
    }




    







}

