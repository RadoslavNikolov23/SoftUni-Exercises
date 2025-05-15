using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddCollection:MyList
    {
        //public AddCollection(List<string> list) : base(list)
        //{
        //}

        public override int Add(string item)
        {
            this.listOfStrings.Add(item);
            int indexAtLast = listOfStrings.Count-1;
            return indexAtLast;
        }
    }
}
