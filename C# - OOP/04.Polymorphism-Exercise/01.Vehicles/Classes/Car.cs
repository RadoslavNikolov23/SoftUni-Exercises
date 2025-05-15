using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Classes
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double IncreasedFuelConsumption => 0.9;

        public override string ToString() => base.ToString() + $"{this.FuelQuantity:f2}";
  
    }
}
