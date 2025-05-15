using MilitaryElite.Soldiers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Soldiers
{
    public class Spy : Soldier, ISoldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}Code Number: {this.CodeNumber}";
        }
    }
}
