using ConsoleApp1;
using NUnit.Framework;

namespace TestProject1
{
    public class StudentTests
    {
        [SetUp]
        public void Setup()//ÿһ������֮ǰ������һ��setup
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
        //    Assert.AreEqual(999, Max);//�Ƚ����
        
        //}

    }
}