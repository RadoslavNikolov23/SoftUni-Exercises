using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjects
{
    public class Person:IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }


        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {

            
            bool areEqualNames = this.Name.Equals(other.Name);
            bool areEqualAge = this.Age.Equals(other.Age);
            bool areEqualTowns = this.Town.Equals(other.Town);

            if (areEqualNames && areEqualAge && areEqualTowns) return 0;
            else return 1;
           
        }
    }
}
