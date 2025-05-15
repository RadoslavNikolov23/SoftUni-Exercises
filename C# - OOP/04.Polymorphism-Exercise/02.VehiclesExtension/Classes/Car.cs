using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Classes
{
    public class Car : Vehicle
    {
        public const double increasedSummerCarConsum = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double IncreaseFuelConsumtion => increasedSummerCarConsum;
        public override string ToString() => base.ToString() + $"{this.FuelQuantity:f2}";
  
    }
}
