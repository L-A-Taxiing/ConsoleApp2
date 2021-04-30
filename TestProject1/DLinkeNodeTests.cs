using ConsoleApp1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class DLinkeNodeTests
    {
        private DLinkNode node1, node2, node3, node4;
        //1,2,4,3
        [SetUp]//每次测试自动调用，就不需要调用了
        public void SetUp() 
        {
            /*DLinkNode*/
            node1 = new DLinkNode();
            /*DLinkNode*/
            node2 = new DLinkNode();
            /*DLinkNode*/
            node3 = new DLinkNode();
            /*DLinkNode*/
            node4 = new DLinkNode();

            node1.Next = node2;
            node2.Previous = node1;
            node2.Next = node4;
            node4.Previous = node2;
            node4.Next = node3;
            node3.Previous = node4;
            //node1.AddAfter（node2）;
            //会报异常，运行时需要测试；



        }


        [Test]
        public void AddTest() 
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

            Assert.AreEqual(node4, node2.Next);
            Assert.AreEqual(node2, node4.Previous);
            Assert.AreEqual(node3, node4.Next);
            Assert.AreEqual(node4, node3.Previous);
            Assert.IsNull(node3.Next);



        }






    }



}
