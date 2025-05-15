using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Stack<T>:IEnumerable<T>
    {
        public Stack(T[] elements)
        {
            this.CustomST = new List<T>(elements);
        }
        public List<T> CustomST { get; set; }
        
        public void Push(T[] elements)
        {
            foreach(T element in elements)
            this.CustomST.Add(element);
        }   
        public void Push(T element)
        {
            this.CustomST.Add(element);
        }   
        
        public T Pop()
        {
            if(this.CustomST.Count == 0)
            {
                    Console.WriteLine("No elements");
                return default(T) ;

            }

            T element=CustomST[CustomST.Count-1];
             this.CustomST.RemoveAt(this.CustomST.Count-1);
             return element;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for(int i=this.CustomST.Count-1; i >= 0; i--)
            {
                yield return this.CustomST[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

     

    }
}
