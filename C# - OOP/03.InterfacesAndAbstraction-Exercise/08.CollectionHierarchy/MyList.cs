using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        protected List<string> listOfStrings;
        public MyList()
        {
            listOfStrings = new List<string>();
        }
        public IReadOnlyCollection<string> ListOfStrings { get => this.listOfStrings.AsReadOnly(); }

        public virtual int Add(string item)
        {
            this.listOfStrings.Insert(0, item);
            int indexAtLast=0;
            return indexAtLast;
        }

        public virtual string Remove()
        {
            string itemAtFirstIndex = listOfStrings[0];
            this.listOfStrings.RemoveAt(0);
            return itemAtFirstIndex;
        }

        public int Used()
        {
            return this.listOfStrings.Count;
        }
    }
}
