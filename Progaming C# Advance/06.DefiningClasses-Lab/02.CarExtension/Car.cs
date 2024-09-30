using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        

        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
     
        public string Make
        {
            get => make; 
            set => make = value;
        }
        public string Model
        {
            get => model;
            set => model = value;
        }
        public int Year
        {
            get => year;
            set =>year = value;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set => fuelQuantity = value;
        }

        public double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

        public void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption/100) > 0)
            {
                FuelQuantity -= (distance * FuelConsumption/100);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");
            return sb.ToString();

        }
        /*
         * •	•	WhoAmI(): string – returns the following message: 
           "Make: {this.Make}
            Model: {this.Model}
            Year: {this.Year}
            Fuel: {this.FuelQuantity:F2}"
           
           
         */
    }
}