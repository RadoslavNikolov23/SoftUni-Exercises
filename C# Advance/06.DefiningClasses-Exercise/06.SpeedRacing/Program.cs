using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> carDT = new Dictionary<string, Car>();

            int numberCars = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberCars; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                double fuelAmount = double.Parse(data[1]), fuelConsumptionForKm = double.Parse(data[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionForKm, 0);

                if (!carDT.ContainsKey(model))
                    carDT[model] = car;
            }

            string inputCommand = Console.ReadLine();

            while (inputCommand != "End")
            {
                string[] data = inputCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
             
                string carModel = data[1];
                double amountOfKM = double.Parse(data[2]);

                if (carDT.ContainsKey(carModel))
                {
                    Car car = carDT[carModel];

                    carDT[carModel] = Car.CalculateCarsTravelDistance(car, amountOfKM);
                }

                inputCommand = Console.ReadLine();
            }

            foreach (var car in carDT)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.Travelleddistance}");
            }

        }
    }
}
