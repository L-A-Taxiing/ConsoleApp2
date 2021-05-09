using ConsoleApp1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLinkNodeTests
{
    public class DLinkeNodeTests
    {
        private DLinkNode<int> node1, node2, node3, node4, node5 ;
        //1,2,4,3
        [SetUp]//每次测试自动调用，就不需要调用了
        public void SetUp() 
        {
            node1 = new DLinkNode<int>();
            node2 = new DLinkNode<int>();
            node3 = new DLinkNode<int>();
            node4 = new DLinkNode<int>();
            node5 = new DLinkNode<int>();
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

        [Test]
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
            Assert.AreEqual(null, node5.Previous);
            Assert.IsNull(node5.Next);

        }

        [Test]
        public void FindByTest() 
        {
            //5.[选] FindBy()：根据节点值查找到某个节点




        }



        [Test]
        public void ForeachTest() 
        {
            IList<DLinkNode<int>> nodes = new List<DLinkNode<int>>();
            foreach (var item in node2)
            {
                nodes.Add(item);
            }
            // 1 2 3 4 5
            Assert.AreEqual(5, nodes.Count);
            Assert.AreEqual(node1.value,nodes[0].value);
            Assert.AreEqual(node2.value,nodes[1].value);
            Assert.AreEqual(node3.value,nodes[2].value);
            Assert.AreEqual(node4.value,nodes[3].value);
            Assert.AreEqual(node5.value,nodes[4].value);

        }




    }



}
