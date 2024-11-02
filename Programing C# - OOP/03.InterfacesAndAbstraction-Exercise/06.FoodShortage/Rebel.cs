using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Rebel : BaseBuyer,IIntroduction,IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Name { get; }

        public int Age { get; }
        public string Group { get; set; }

        protected override int IncreasedFood => 5;
    }
}
