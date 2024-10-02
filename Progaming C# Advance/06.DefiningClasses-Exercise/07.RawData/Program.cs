using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCars = int.Parse(Console.ReadLine());
            Dictionary<string, Car> carDT = new Dictionary<string, Car>();

            for (int i = 0; i < numberCars; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];

                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(data[6]),double.Parse(data[5])),
                    new Tire(int.Parse(data[8]),double.Parse(data[7])),
                    new Tire(int.Parse(data[10]),double.Parse(data[9])),
                    new Tire(int.Parse(data[12]), double.Parse(data[11])),
                };

                if (!carDT.ContainsKey(model))
                {
                    carDT.Add(model, new Car(model, engine, cargo, tires));
                }
            }

            string singleCommand = Console.ReadLine();

            switch (singleCommand)
            {
                case "fragile":
                    foreach(var car in carDT.Where(x=>x.Value.Cargo.Type=="fragile")
                        .Where(x=>x.Value.Tires.Any(t=>t.Pressure<1)))
                    {
                        Console.WriteLine($"{car.Key}");
                    }
                    break;
                case "flammable":
                    foreach (var car in carDT.Where(x => x.Value.Cargo.Type == "flammable")
                        .Where(x => x.Value.Engine.Power>250))
                    {
                        Console.WriteLine($"{car.Key}");
                    }
                    break;
            }
        }
    }
}
