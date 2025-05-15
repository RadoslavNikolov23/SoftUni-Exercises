using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder resultSB = new StringBuilder();
            resultSB.AppendLine(base.ExplainSelf());
            resultSB.AppendLine("DJAAF");

            return resultSB.ToString().Trim();
        }
    }
}
