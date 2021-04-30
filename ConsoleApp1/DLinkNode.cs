using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DLinkNode
    {
        public DLinkNode Previous{get;set;}
        public DLinkNode Next { get; set; }

        public void AddAfter(DLinkNode node)
        {
            if (this.Next==null)
            {
                node.Previous = this;
                this.Next = node;
            }
            else
            {

                node.Next = this.Next;
                node.Previous = this;
                this.Next.Previous = node;
                this.Next = node;

            }

        }
        public void Addbefore(DLinkNode node) 
        {
        
        }
        public void Delete() { }
        public void Swap() { }

             

    }
}
