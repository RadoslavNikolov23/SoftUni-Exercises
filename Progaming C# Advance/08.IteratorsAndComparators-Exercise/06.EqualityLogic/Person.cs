using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get;}
        public int Age { get;}

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Age);

        }

        public int CompareTo(Person? other)
        {
            if (other == null) return 1;
            if (ReferenceEquals(this, other)) return 0;

            int resultName = string.Compare(this.Name, other.Name);
            if (resultName != 0) return resultName;

            return Age.CompareTo(other.Age);

        }

        public  bool Equals(Person? other) => this.CompareTo(other)==0;
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }


            return this.Equals((Person?)obj);
        }
    }
}
