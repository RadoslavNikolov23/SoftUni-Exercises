using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GenericScale
{
    public class EqualityScale<T> where T:IComparable
    {
        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public T Left { get; set; }
        public T Right { get; set; }

       public bool AreEqual()
        {
            return this.Left.Equals(this.Right);
        }
    }
}
