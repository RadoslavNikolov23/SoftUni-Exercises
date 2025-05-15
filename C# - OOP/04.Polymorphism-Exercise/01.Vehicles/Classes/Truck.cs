using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Classes
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double IncreasedFuelConsumption => 1.6;

        public override void Refueled(double liters) => base.Refueled(liters * 0.95);

        public override string ToString() =>  base.ToString() + $"{this.FuelQuantity:f2}";

    }
}
