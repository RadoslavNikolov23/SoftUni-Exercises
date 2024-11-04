using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Classes
{
    public class Truck : Vehicle
    {
        public const double increasedSummerTruckConsum = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
                    : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double IncreaseFuelConsumtion => increasedSummerTruckConsum;
        public override string ToString() =>  base.ToString() + $"{this.FuelQuantity:f2}";

    }
}
