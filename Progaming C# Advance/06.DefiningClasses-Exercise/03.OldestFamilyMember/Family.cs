using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {

        private readonly List<Person> People = new List<Person>();

        public void AddMember(Person person)
        {
            People.Add(person);
        }
        public Person GetOldestMember()
        {
            return People.OrderByDescending(x=>x.Age).FirstOrDefault();
        } 

    }
}
