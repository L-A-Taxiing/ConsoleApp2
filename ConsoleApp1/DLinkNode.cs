using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DLinkNode
    {
        public DLinkNode Previous { get; set; }
        public DLinkNode Next { get; set; }

        public void AddAfter(DLinkNode node)
        {
            if (this.Next == null)
            {
                node.Previous = this;
                this.Next = node;
            }
            else
            {
                node.Next = this.Next;
                this.Next.Previous = node;
                node.Previous = this;
                this.Next = node;
                
            }

        }
        public void AddBefore(DLinkNode node)
        {
            // 2  [1]  3
            if (this.Previous==null)
            {
                node.Next = this;
                this.Previous = node;
            }
            else
            {
                node.Previous = this.Previous;
                this.Previous.Next = node;
                node.Next = this;
                this.Previous = node;
            }
        }
        public void Delete() 
        {
            if (this.Previous==null&&this.Next!=null)//   [1] 2 3 4 5
            {
                DLinkNode node = this.Next;
                this.Next = null;
                node.Previous = null;

            }
            else if (this.Next==null&&this.Previous!=null)//2 3 4 [5]
            {
                DLinkNode node = this.Previous;
                this.Previous = null;
                node.Next = null;
            }
            else if (this.Previous!=null&&this.Next!=null)/*2 [3] 4*/
            {
                this.Previous = this.Previous;
                this.Next = this.Next;
            }
            else // [2]
            {
                this.Previous = null;
                this.Next = null;
            }
        }
        public void Swap(DLinkNode node) 
        {
            //if (this.Previous==null&&node.Next!=null)
            //{
            //    //node.Previous.Next = this;
            //    //this.Previous = node.Previous;
            //    //this.Next = node.Next;
            //    //node.Next.Previous = this;

            //    //node = this.Previous.Previous;
            //    //node.Previous = null;
            //    //node.Next = this;

            //}

        }
        public void FindBy() 
        {
        
        }

    }
}
