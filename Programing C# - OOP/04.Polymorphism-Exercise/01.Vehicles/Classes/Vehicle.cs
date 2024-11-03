using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Interface;

namespace Vehicles.Classes
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public abstract double IncreasedFuelConsumption { get; }

        public bool Driven(double drivenKM)
        {
            if (this.FuelQuantity < drivenKM * (this.FuelConsumption + this.IncreasedFuelConsumption))
            {
                return false;
            }
            this.FuelQuantity -= drivenKM * (this.FuelConsumption + this.IncreasedFuelConsumption);
            return true;
        }

        public virtual void Refueled(double liters) => this.FuelQuantity += liters;


        public override string ToString() => $"{this.GetType().Name}: ";

    }
}
