using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.AnimalsClasses
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight,  livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; }

        public override string ToString() => $"[{this.Name}, {Breed}, " + base.ToString();
    }
}
