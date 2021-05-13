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

        public void AddAfter(DLinkNode<T> node)//1 2 3 4 5
        {
            if (this.Next == null)
            {
                
            }
            else
            {
                this.Next.Previous = node;
                node.Next = this.Next;
            }
            node.Previous = this;
            this.Next = node;

        }
        public void AddBefore(DLinkNode<T> node)
        {
            // 2  [1]  3
            if (this.Previous == null)
            {
                
            }
            else
            {
                this.Previous.Next = node;
                node.Previous = this.Previous;
               
            }
            this.Previous = node;
            node.Next = this;


        }
        public void Delete()
        {
            //1 2 3 4 5
            if (this.Previous != null)
            {
                this.Previous.Next = this.Next;
                if (this.Next == null)
                {
                    this.Previous = null;
                }
            }
            if (this.Next != null)
            {
                this.Next.Previous = this.Previous;
                if (this.Previous == null)
                {
                    this.Next = null;
                }
            }

        }
        public void Swap(DLinkNode<T> node)
        {
            DLinkNode<T> PreThis = this.Previous;
            DLinkNode<T> NextThis = this.Next;
            //1 2 3 4 5
            if (node.Next != null)
            {
                this.Delete();
                node.AddAfter(this);
            }
            else 
            {
                this.Delete();
                node.Previous.AddAfter(this);
            }

            if (PreThis == node)
            {
                PreThis = this;
            }
            if (NextThis == node)
            {
                NextThis = this;
            }


            if (PreThis != null)
            {
                node.Delete();
                PreThis.AddAfter(node);
            }
            else
            {
                node.Delete();
                NextThis.AddBefore(node);
                node.Previous = PreThis;
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
        //private DLinkNode<T> GetFirstNode()
        //{
        //    DLinkNode<T> head = this;
        //    if (this.Previous != null)
        //    {
        //        head = this.Previous;
        //    }
        //    return head;
        //}






        struct Enumrator : IEnumerator<DLinkNode<T>>
        {
            private DLinkNode<T> _current;
            private bool end;
            //private DLinkNode<T> head;

            public object Current => _current.Previous;
            DLinkNode<T> IEnumerator<DLinkNode<T>>.Current => _current.Previous;
            public Enumrator(DLinkNode<T> node)
            {
                _current = node;
                end = false;
                //head = _current.GetFirstNode();
            }
            public void Dispose()
            {
                return;
            }

            public bool MoveNext()   //移到集合的下一个元素。如果成功则返回为 true;如果超过集合结尾，则返回false
            {
                if (end)
                {
                    return false;
                }
                if (_current.Next == null)
                {
                    _current.Next = new DLinkNode<T>
                    {
                        Previous = _current
                    };
                    end=true;
                }
                _current = _current.Next;
                return true;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

           
        }
    }





    //调用扩展方法Max()：能够返回之前双向链表中存贮着最大值的节点
    public static class GetMaxExtension 
    {
        public static DLinkNode<int> Max(this DLinkNode<int> node)
        {
            DLinkNode<int> max = new DLinkNode<int>();
            max.value = -1;
            foreach (var item in node)
            {
                if (item.value > max.value)
                {
                    max = item;
                }
            }
            return max;
        }



    }
}
