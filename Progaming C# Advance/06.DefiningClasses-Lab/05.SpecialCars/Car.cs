using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;

        }
        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {

            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, 
            Engine engine, Tire[] tires):this(make, model, year, fuelQuantity,fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Engine Engine{ get=> engine; set=> engine = value; }
        public Tire[] Tires{ get=>tires; set=>tires=value; }
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
            set => year = value;
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
            if (FuelQuantity - (distance * FuelConsumption / 100) > 0)
            {
                FuelQuantity -= (distance * FuelConsumption / 100);
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

        public string SpecialCar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.Append($"FuelQuantity: {this.FuelQuantity}");
            return sb.ToString();
        }

    }

    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }

        private int horsePower;
        private double cubicCapacity;



        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }
    }

    public class Tire
    {
        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }

        private int year;
        private double pressure;

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }


        public int Year
        {
            get { return year; }
            set { year = value; }
        }


    }
}