using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen : BaseBuyer,IIdentification, IBirthday, IIntroduction,IBuyer
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Name { get; }
        public int Age { get;}
        public string Id { get; }

        public string Birthday { get;  }

        protected override int IncreasedFood => 10;
    }
}
