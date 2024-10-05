using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BoxOfT
{
    public class Box<T>
    {
        private Stack<T> Element { get; set; }
        public Box()
        {
            Element=new Stack<T>();
            
        }

        public int Count { get { return this.Element.Count; } }
        public void Add(T element) 
        { 
            this.Element.Push(element);
        } 
        
        public T Remove() 
        { 
            T element=this.Element.Pop();
            return element;
        }
    }
}
