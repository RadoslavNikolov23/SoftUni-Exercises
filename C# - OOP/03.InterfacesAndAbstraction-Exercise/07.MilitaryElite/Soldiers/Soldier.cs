using MilitaryElite.Soldiers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Soldiers
{
    public abstract class Soldier: ISoldier
    {
        private string id;
        private string firstName;
        private string lastName;

        protected Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; }
        public string FirstName { get ; }
        public string LastName { get; }

        public override string ToString()
        {

            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";

        }
    }
}
