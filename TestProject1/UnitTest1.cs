using ConsoleApp1;
using NUnit.Framework;

namespace TestProject1
{
    public class StudentTests
    {
        [SetUp]
        public void Setup()//每一个测试之前都会跑一边setup
        {
        }

        [Test]
        public void Greet()
        {
            Assert.Pass();
        }

        [Test]
        public void Learn() 
        {
        
        }
        //[Test]
        //public void GetMaxTest()
        //{
        //    int Max = MyClass.GetMax(new int[] { 1, 2, 3, 4, 111, 999 });
        //    Assert.AreEqual(999, Max);//比较相等
        
        //}

    }
}