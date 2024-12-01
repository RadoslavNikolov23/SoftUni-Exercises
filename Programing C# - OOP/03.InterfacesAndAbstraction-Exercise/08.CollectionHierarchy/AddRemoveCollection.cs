using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddRemoveCollection:MyList
    {
        //public AddRemoveCollection(List<string> list) : base(list)
        //{
        //}

        public override string Remove()
        {
            string itemAtFirstIndex = listOfStrings[listOfStrings.Count-1];
            this.listOfStrings.RemoveAt(listOfStrings.Count - 1);
            return itemAtFirstIndex;
        }
    }
}
