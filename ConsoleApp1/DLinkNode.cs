using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //让之前的双向链表，能够：被foreach迭代
    public class DLinkNode<T> : IEnumerable<DLinkNode<T>>
    {


        #region Methods
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion

        public DLinkNode<T> Previous { get; set; }
        public DLinkNode<T> Next { get; set; }
        public T value { get; set; }

        public void AddAfter(DLinkNode<T> node)
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
        public void AddBefore(DLinkNode<T> node)
        {
            // 2  [1]  3
            if (this.Previous == null)
            {
                //node.Next = this;
                //this.Previous = node;
            }
            else
            {
                node.Previous = this.Previous;
                this.Previous.Next = node;
                //node.Next = this;
                //this.Previous = node;
            }
            node.Next = this;
            this.Previous = node;


        }
        public void Delete()
        {
            if (this.Previous == null)//   [1] 2 3 4 5
            {
                this.Next.Previous = null;
                this.Next = null;

            }
            else if (this.Next == null)//2 3 4 [5]
            {
                this.Previous.Next = null;
                this.Previous = null;
            }
            else/* 1 [2] 3*/
            {
                this.Previous.Next = this.Next;
                this.Next.Previous = this.Previous;
                this.Previous = null;
                this.Next = null;
            }


        }
        public void Swap(DLinkNode<T> node)
        {
            DLinkNode<T> PreThis = this.Previous;
            DLinkNode<T> NextThis = this.Next;

            if (node.Next != this)    /*/*1 2 3 4 5*///*5 1 2 3 4*///*/
            {
                this.Delete();
                node.AddAfter(this); //1 2 3 4 5   1 5  3 4 2
            }
            if (NextThis == node)
            {
                NextThis = this;
            }

            if (PreThis == node)
            {
                PreThis = this;
            }

            if (PreThis == null)
            {
                //if (NextThis==node.Next)
                //{
                node.Delete();
                NextThis.AddBefore(node);
                //}
                //else
                //{
                //    node.Delete();
                //    NextThis.AddBefore(node);
                //}
            }
            else
            {
                if (node.Previous != PreThis)
                {
                    node.Delete();
                    PreThis.AddAfter(node);

                }
            }




        }

        public void FindBy()
        {

        }


        public IEnumerator<DLinkNode<T>> GetEnumerator()
        {
            return new Enumrator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }
        private DLinkNode<T> GetFirstNode() 
        {
            DLinkNode<T> head = this;
            if (this.Previous!=null)
            {
                head = this.Previous;
            }
            return head;
        }
            





         struct Enumrator : IEnumerator<DLinkNode<T>>
         {
            private DLinkNode<T> _current;
            public object Current => _current;
            DLinkNode<T> IEnumerator<DLinkNode<T>>.Current => _current;

            public bool MoveNext()   //移到集合的下一个元素。如果成功则返回为 true;如果超过集合结尾，则返回false
            {
                
                if (_current.Next!=null)
                {
                    _current.Next = _current; 
                    return true;
                }
                return false;
            }

            public void Reset()   
            {
                return;
            }

            public void Dispose()
            {
                return;
            }
            public Enumrator(DLinkNode<T> node)
            {
                _current = node.GetFirstNode();
            }
        }
    }
}
