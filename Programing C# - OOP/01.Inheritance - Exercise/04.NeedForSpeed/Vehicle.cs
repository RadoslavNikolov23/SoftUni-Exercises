using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private const double defaultFuelConsumption=1.25;
        private double fuelConsumption;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
 
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public double Fuel
		{
			get { return fuel; }
			set { fuel = value; }
		}

        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = defaultFuelConsumption; }
        }

       public virtual void Drive(double kilometers)
        {
            double neceseryFuel=this.FuelConsumption* kilometers;
            this.Fuel-=neceseryFuel;
        }


    }
}
