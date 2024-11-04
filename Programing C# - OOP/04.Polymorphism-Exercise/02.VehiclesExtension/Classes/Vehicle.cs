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
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else this.FuelQuantity = fuelQuantity;

            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

        public abstract double IncreaseFuelConsumtion { get; }

        public string DriveEmpty(double driveKM)
        {
            double needFuel = driveKM * this.FuelConsumption;
            if (this.FuelQuantity < needFuel)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= needFuel;
            return $"{this.GetType().Name} travelled {driveKM} km";
        }

        public string Driven(double drivenKM)
        {
            double needFuel = drivenKM * (this.FuelConsumption + this.IncreaseFuelConsumtion);
            if (this.FuelQuantity < needFuel)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= needFuel;
            return $"{this.GetType().Name} travelled {drivenKM} km";
        }

        public void Refueled(double liters)
        {
            if (liters <= 0) Console.WriteLine($"Fuel must be a positive number");
            else
            {
                if (this.FuelQuantity + liters > this.TankCapacity)
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                else
                {
                    if (this.GetType().Name == "Truck") this.FuelQuantity += liters * 0.95;
                    else this.FuelQuantity += liters;
                }
            }
        }

        public override string ToString() => $"{this.GetType().Name}: ";

    }
}
