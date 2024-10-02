using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {

        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelleddistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelleddistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            Travelleddistance = travelleddistance;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double Travelleddistance
        {
            get { return travelleddistance; }
            set { travelleddistance = value; }
        }


        public static Car  CalculateCarsTravelDistance(Car car, double amoutKM)
        {
            double needFuel = car.FuelConsumptionPerKilometer * amoutKM;
            if (car.FuelAmount >= needFuel)
            {
                car.FuelAmount -= needFuel;
                car.Travelleddistance += amoutKM;

            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

            return car;
            
        }



    }
}
