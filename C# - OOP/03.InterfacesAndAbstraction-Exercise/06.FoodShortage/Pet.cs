using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Pet : IBirthday
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name{ get; }

        public string Birthday{ get; }
    }
}
