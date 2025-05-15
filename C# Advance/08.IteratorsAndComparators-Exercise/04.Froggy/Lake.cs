using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggy
{
    public class Lake:IEnumerable<int>
    {
        public Lake()
        {
            this.MyList = new List<int>();
        }
        public Lake(List<int> myList):this()
        {
            this.MyList = myList;
        }
        public List<int> MyList { get; }
        public IEnumerator<int> GetEnumerator()
        {
            foreach(int number in this.MyList)
            {
                yield return number;
            }

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
