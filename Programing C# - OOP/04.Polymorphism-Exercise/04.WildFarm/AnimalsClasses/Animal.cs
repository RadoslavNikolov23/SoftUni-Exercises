using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;
using WildFarm.Interfaces;

namespace WildFarm.AnimalsClasses
{
    public abstract class Animal : IAnimal
    {
        
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract double IndividualIncrese { get; }

        public abstract void ProduceSoundForFood(Food food);

    }
}
