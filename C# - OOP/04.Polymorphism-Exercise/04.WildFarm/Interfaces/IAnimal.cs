﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.Interfaces
{
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }

        public string Sound { get; }
        public IReadOnlyCollection<string> PrefferFoods { get; }

        void ProduceSoundForFood(Food food);
    }
}
