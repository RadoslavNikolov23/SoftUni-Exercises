using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Interface;

namespace Vehicles.Classes
{
    public class Bus : Vehicle
    {
        public const double increasedSummerBusConsum = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
                    : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double IncreaseFuelConsumtion => increasedSummerBusConsum;
        public override string ToString() => base.ToString() + $"{this.FuelQuantity:f2}";

    }
}

