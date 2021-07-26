using ConsoleApp1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLinkNodeSwapTest
{
   public  class DLinkNodeSwapTest
    {
        private DLinkNode<int> node1, node2, node3, node4, node5;
        public int Value { get; set; }

        [SetUp]
        public void SetUp() 
        {
            node1 = new DLinkNode<int>() {Value=1};
            node2 = new DLinkNode<int>() {Value=2};
            node3 = new DLinkNode<int>() {Value =3};
            node4 = new DLinkNode<int>() {Value=4};
            node5 = new DLinkNode<int>() {Value=5};
            //1 2 3 4 5
            node1.Previous = null;
            node1.Next = node2;
            node2.Previous = node1;
            node2.Next = node3;
            node3.Previous = node2;
            node3.Next = node4;
            node4.Previous = node3;
            node4.Next = node5;
            node5.Previous = node4;
            node5.Next = null;
        }

        [Test]
        public void DLinkNodeSwapTest_1_2() 
        {
            //[1] [2] 3 4 5=>2 1 3 4 5  相连-首和下一个交换
            node1.Swap(node2);
            Assert.IsNull(node2.Previous);
            Assert.AreEqual(1,node2.Next.Value);
            Assert.AreEqual(2,node1.Previous.Value);
            Assert.AreEqual(3,node1.Next.Value);
            Assert.AreEqual(1,node3.Previous.Value);
            Assert.AreEqual(4,node3.Next.Value);
            Assert.AreEqual(3,node4.Previous.Value);
            Assert.AreEqual(5,node4.Next.Value);
            Assert.AreEqual(4,node5.Previous.Value);
            Assert.AreEqual(null,node5.Next);
            
        }

        [Test]
        public void DLinkNodeSwapTest_2_1() 
        {
            node2.Swap(node1);
            Assert.IsNull(node2.Previous);
            Assert.AreEqual(1, node2.Next.Value);
            Assert.AreEqual(2, node1.Previous.Value);
            Assert.AreEqual(3, node1.Next.Value);
            Assert.AreEqual(1, node3.Previous.Value);
            Assert.AreEqual(4, node3.Next.Value);
            Assert.AreEqual(3, node4.Previous.Value);
            Assert.AreEqual(5, node4.Next.Value);
            Assert.AreEqual(4, node5.Previous.Value);
            Assert.AreEqual(null, node5.Next);


        }

        [Test]
        public void DLinkNodeSwapTest_1_3() 
        {
            //[1] 2 [3] 4 5=> 3 2 1 4 5 不相连-首和中间交换
            node1.Swap(node3);
            Assert.IsNull(node3.Previous);
            Assert.AreEqual(2, node3.Next.Value);
            Assert.AreEqual(3, node2.Previous.Value);
            Assert.AreEqual(1, node2.Next.Value);
            Assert.AreEqual(2, node1.Previous.Value);
            Assert.AreEqual(4, node1.Next.Value);
            Assert.AreEqual(1, node4.Previous.Value);
            Assert.AreEqual(5, node4.Next.Value);
            Assert.AreEqual(4, node5.Previous.Value);
            Assert.AreEqual(null, node5.Next);

        }

        [Test]
        public void DLinkNodeSwapTest_1_5() 
        {
            //[1] 2 3 4 [5]=>5 2 3 4 1 不相连-首尾交换
            node1.Swap(node5);
            Assert.IsNull(node5.Previous);
            Assert.AreEqual(2, node5.Next.Value);
            Assert.AreEqual(5, node2.Previous.Value);
            Assert.AreEqual(3, node2.Next.Value);
            Assert.AreEqual(2, node3.Previous.Value);
            Assert.AreEqual(4, node3.Next.Value);
            Assert.AreEqual(3, node4.Previous.Value);
            Assert.AreEqual(1, node4.Next.Value);
            Assert.AreEqual(4, node1.Previous.Value);
            Assert.AreEqual(null, node1.Next);

        }

        [Test]
        public void DLinkNodeSwapTest_2_3() 
        {
            //1 [2] [3] 4 5=>1 3 2 4 5  相连-中间互相交换
            node2.Swap(node3);
            Assert.AreEqual(3, node1.Next.Value);
            Assert.AreEqual(1,node3.Previous.Value);
            Assert.AreEqual(2,node3.Next.Value);
            Assert.AreEqual(3,node2.Previous.Value);
            Assert.AreEqual(4,node2.Next.Value);
            Assert.AreEqual(2,node4.Previous.Value);
            Assert.AreEqual(5,node4.Next.Value);
            Assert.AreEqual(4,node5.Previous.Value);
            Assert.AreEqual(null,node5.Next);
        }

        [Test]
        public void DLinkNodeSwapTest_2_4() 
        {
            //1 [2] 3 [4] 5=>1 4 3 2 5 不相连-中间交换
            node2.Swap(node4);
            Assert.AreEqual(4, node1.Next.Value);
            Assert.AreEqual(1, node4.Previous.Value);
            Assert.AreEqual(3, node4.Next.Value);
            Assert.AreEqual(4, node3.Previous.Value);
            Assert.AreEqual(2, node3.Next.Value);
            Assert.AreEqual(3, node2.Previous.Value);
            Assert.AreEqual(5, node2.Next.Value);
            Assert.AreEqual(2, node5.Previous.Value);
            Assert.AreEqual(null, node5.Next);
        }

        [Test]
        public void DLinkNodeSwapTest_2_5() 
        {
            //1 [2] 3 4 [5]=>1 5 3 4 2 不相连-中间和尾交换
            node2.Swap(node5);
            Assert.AreEqual(5, node1.Next.Value);
            Assert.AreEqual(1, node5.Previous.Value);
            Assert.AreEqual(3, node5.Next.Value);
            Assert.AreEqual(5, node3.Previous.Value);
            Assert.AreEqual(4, node3.Next.Value);
            Assert.AreEqual(3, node4.Previous.Value);
            Assert.AreEqual(2, node4.Next.Value);
            Assert.AreEqual(4, node2.Previous.Value);
            Assert.AreEqual(null, node2.Next);
        }

        [Test]
        public void DLinkNodeSwapTest_4_5() 
        {
            //1 2 3 4 5=>1 2 3 5 4 相连-尾前和尾交换
            node4.Swap(node5);
            Assert.AreEqual(2, node1.Next.Value);
            Assert.AreEqual(1, node2.Previous.Value);
            Assert.AreEqual(3, node2.Next.Value);
            Assert.AreEqual(2, node3.Previous.Value);
            Assert.AreEqual(5, node3.Next.Value);
            Assert.AreEqual(3, node5.Previous.Value);
            Assert.AreEqual(4, node5.Next.Value);
            Assert.AreEqual(5, node4.Previous.Value);
            Assert.AreEqual(null, node4.Next);




        }


    }
}
