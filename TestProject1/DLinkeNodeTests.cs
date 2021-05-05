using ConsoleApp1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class DLinkeNodeTests
    {
        private DLinkNode node1, node2, node3, node4,node5;
        //1,2,4,3
        [SetUp]//每次测试自动调用，就不需要调用了
        public void SetUp() 
        {
            node1 = new DLinkNode();
            node2 = new DLinkNode();
            node3 = new DLinkNode();
            node4 = new DLinkNode();
            node5 = new DLinkNode();

        }

        [Test]
        public void AddAfterTest1() 
        {
            ////1  [2]
            //Assert.IsNull(node1.Previous);
            //Assert.AreEqual(node2, node1.Next);

            //Assert.AreEqual(node1, node2.Previous);
            //Assert.IsNull(node2.Next);

            ////1 2 [3]
            //Assert.IsNull(node3.Next);
            //Assert.AreEqual(node2, node3.Previous);
            //Assert.AreEqual(node3, node2.Next);


            //1 2 [4] 3
            node1.AddAfter(node2);
            node2.AddAfter(node4);
            node4.AddAfter(node3);
            Assert.AreEqual(node4, node2.Next);
            Assert.AreEqual(node2, node4.Previous);
            Assert.AreEqual(node3, node4.Next);
            Assert.AreEqual(node4, node3.Previous);
            Assert.IsNull(node3.Next);
        }
        public void AddAfterTest2()
        {
            //1.node3.InsertAfter(node1); 场景
            //[1] 3
            node1.AddAfter(node3);
            Assert.IsNull(node3.Next);
            Assert.IsNull(node1.Previous);
            Assert.AreEqual(node1, node3.Previous);
            Assert.AreEqual(node3, node1.Next);

            //1 3 [4]
            node3.AddAfter(node4);
            Assert.AreEqual(node3, node4.Previous);
            Assert.AreEqual(node4, node3.Next);
            Assert.IsNull(node4.Next);

            //1 3 [2] 4
            node3.AddAfter(node2);
            Assert.AreEqual(node3, node2.Previous);
            Assert.AreEqual(node2, node3.Next);
            Assert.AreEqual(node2, node4.Previous);
            Assert.AreEqual(node4, node2.Next);
        }
        [Test]
        public void AddBeforeTest() 
        {
            //2.InerstBefore()：在某个节点前插入
            //[1] 2
            node2.AddBefore(node1);
            Assert.AreEqual(node1,node2.Previous);
            Assert.AreEqual(node2,node1.Next);
            Assert.IsNull(node1.Previous);
            Assert.IsNull(node2.Next);

            //[3] 1 2
            node1.AddBefore(node3);
            Assert.AreEqual(node1,node3.Next);
            Assert.AreEqual(node3,node1.Previous);
            Assert.IsNull(node3.Previous);

            //3 [4] 1 2
            node1.AddBefore(node4);
            Assert.AreEqual(node4, node1.Previous);
            Assert.AreEqual(node3, node4.Previous);
            Assert.AreEqual(node4, node3.Next);
            Assert.AreEqual(node1, node4.Next);


        }

        [Test]
        public void DeleteTest() 
        {
            node1.AddAfter(node2);
            node2.AddAfter(node3);
            node3.AddAfter(node4);
            node4.AddAfter(node5);
            // [1] 2 3 4 5
            node1.Delete();
            Assert.IsNull(node2.Previous);
            Assert.IsNull(node1.Next);
            Assert.IsNull(node1.Previous);
            //2 [3] 4 5
            node3.Delete();
            Assert.IsNull(node2.Previous);
            Assert.AreEqual(node4, node2.Next);
            Assert.AreEqual(node2,node4.Previous);
            Assert.AreEqual(node5,node4.Next);
            //2 [4] 5
            node4.Delete();
            Assert.IsNull(node2.Previous);
            Assert.AreEqual(node5, node2.Next);
            Assert.AreEqual(node2, node5.Previous);
            Assert.IsNull(node5.Next);
            //2 [5]
            node5.Delete();
            Assert.IsNull(node2.Previous);
            Assert.IsNull(node2.Next);
            Assert.AreEqual(node2, node5.Previous);
            Assert.IsNull(node5.Next);
            //[2]
            node2.Delete();
            Assert.IsNull(node2.Previous);
            Assert.IsNull(node2.Next);

        }


        [Test]
        public void SwapTest1() 
        {
            node1.AddAfter(node2);
            node2.AddAfter(node3);
            node3.AddAfter(node4);
            node4.AddAfter(node5);
            //4.[选] Swap()：交互某两个节点
            //[1] 2 [3] 4 5  =>3 2 1 4 5      首和中间交换
            node1.Swap(node3);
            Assert.AreEqual(node2,node1.Previous);
            Assert.AreEqual(node1,node2.Next);
            Assert.AreEqual(node4,node1.Next);
            Assert.AreEqual(node1,node4.Previous);
            Assert.AreEqual(null,node3.Previous);
            Assert.AreEqual(node2,node3.Next);
            Assert.AreEqual(node3, node2.Previous);


            //[3]  2  1  4  [5]  =>5 2 1 4 3      首尾交换
            node3.Swap(node5);
            Assert.AreEqual(node4,node3.Previous);
            Assert.AreEqual(node3,node4.Next);
            Assert.AreEqual(null,node3.Next);
            Assert.AreEqual(null,node5.Previous);
            Assert.AreEqual(node2,node5.Next);
            Assert.AreEqual(node5,node2.Previous);


            //5  [2]  1  4  [3] =>5 3 1 4 2        中间和尾交换
            node2.Swap(node3);
            Assert.AreEqual(node4,node2.Previous);
            Assert.AreEqual(node2,node4.Next);
            Assert.AreEqual(null,node2.Next);
            Assert.AreEqual(node5,node3.Previous);
            Assert.AreEqual(node3,node5.Next);
            Assert.AreEqual(node1,node3.Next);
            Assert.AreEqual(node3,node1.Previous);

            //5  [3]   1  [4]   2 =>5 4 1 3 2       中间和中间交换
            node3.Swap(node4);
            Assert.AreEqual(node1,node3.Previous);
            Assert.AreEqual(node3,node1.Next);
            Assert.AreEqual(node2,node3.Next);
            Assert.AreEqual(node3,node2.Previous);
            Assert.AreEqual(node5,node4.Previous);
            Assert.AreEqual(node4,node5.Next);
            Assert.AreEqual(node1,node4.Next);
            Assert.AreEqual(node4,node1.Previous);


        }
        [Test]
        public void SwapTest2() 
        {
            //[1] [2]=>2 1
            node1.AddAfter(node2);
            node1.Swap(node2);
            Assert.AreEqual(node2,node1.Previous);
            Assert.AreEqual(node1,node2.Next);
            Assert.AreEqual(null,node1.Next);
            Assert.AreEqual(null,node2.Previous);
            Assert.AreEqual(node1,node2.Next);
            Assert.AreEqual(node2, node1.Previous);
        }

        [Test]
        public void FindByTest() 
        {
            //5.[选] FindBy()：根据节点值查找到某个节点




        }






    }



}
