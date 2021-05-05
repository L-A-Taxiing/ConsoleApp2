using ConsoleApp1;
using Homework;
using NUnit.Framework;

namespace TestProject1
{
    public class StudentTests
    {
        
        [SetUp]
        public void Setup()//每一个测试之前都会跑一边setup
        {
           
        }
        //[Test]
        //public void GetMaxTest()
        //{
        //    int Max = MyClass.GetMax(new int[] { 1, 2, 3, 4, 111, 999 });
        //    Assert.AreEqual(999, Max);//比较相等
        //}

        //继续完成双向链表的测试和开发，实现：
        //1.node3.InsertAfter(node1); 场景
        //2.InerstBefore()：在某个节点前插入
        //3.Delete()：删除某个节点
        //4.[选] Swap()：交互某两个节点
        //5.[选] FindBy()：根据节点值查找到某个节点

        //为之前作业添加单元测试，包括但不限于：
        [Test]//1.数组中找到最大值
        public void FindMaxTest()
        {
            Assert.AreEqual(999, MyClass.FindMax(new double[] { 1, 2, 33.3, 5, 999, 100, 45 }));
            Assert.AreEqual(999, MyClass.FindMax(new double[] { -1, 2, 3, 5, 98, 999, 12 }));
            Assert.AreEqual(999, MyClass.FindMax(new double[] { 111, 999, 999, 22, 91, 10 }));
            Assert.AreEqual(-11.1, MyClass.FindMax(new double[] { -11.1, -22, -33, -44, -55, -100 }));
        }

        [Test]//2.找到100以内的所有质数
        public void FindPrimeNumTest()
        {
            int[] AllPrimeNums = MyClass.FindPrimeNum(1, 100);
            Assert.AreEqual(25, AllPrimeNums.Length);     //判断质数是不是25个;

            for (int i = 0; i < AllPrimeNums.Length; i++) //判断25个数是不是质数;
            {
                Assert.AreEqual(true, MyClass.IsPrimeNum(AllPrimeNums[i]));
            }
        }

        [Test]//3.猜数字游戏
        public void GuessMeTest()
        {
            Assert.AreEqual(true, MyClass.GuessMe(1000));//判断数字是不是在1000以内;
            Assert.AreEqual(false, MyClass.GuessResult(1000, 999));//判断对不对;
            Assert.AreEqual("(～￣(OO)￣)ブ", MyClass.GuessTimes(1000, 1000, 10));//(◞‸◟ )
        }

        [Test]//4.二分查找
        public void BinarySeek()
        {
            Assert.AreEqual(3, MyClass.BinarySeek(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 4));
            Assert.AreEqual(1, MyClass.BinarySeek(new int[] { -10, -9, -8, -7, -6, 0, 99, -9 }, -9));
            Assert.AreEqual(6, MyClass.BinarySeek(new int[] { 1, 3, 5, 7, 99, 100, 999 }, 999));
            Assert.AreEqual(-1, MyClass.BinarySeek(new int[] { 1, 3, 5, 7, 99, 100, 999 }, 1000));
        }

        [Test]//5.栈的压入弹出
        public void PushTest1() //压入测试
        {
            MimicStack lw = new MimicStack(3);
            Assert.AreEqual(1, lw.Push("0000"));
            Assert.AreEqual(2, lw.Push("0001"));
            Assert.AreEqual(3, lw.Push("0002"));
            Assert.AreEqual(-1, lw.Push("0003"));


        }
        [Test]
        public void PopTest() //弹出测试 (◞‸◟ )
        {
            MimicStack zl = new MimicStack(3);
            Assert.AreEqual("栈已空", zl.Pop());
            MimicStack lw = new MimicStack(3);

            zl.Push("0000");
            Assert.AreEqual("0000", zl.Pop());

        }
        
    }
}
