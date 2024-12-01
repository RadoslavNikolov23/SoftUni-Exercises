using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public interface IMyList
    {
        public IReadOnlyCollection<string> ListOfStrings { get; }
        public int Add(string item);
        public string Remove();
        public int Used();
    }
}
