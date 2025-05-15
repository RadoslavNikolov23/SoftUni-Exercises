using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberEngine = int.Parse(Console.ReadLine());

            Dictionary<string, Engine> engineDT = new Dictionary<string, Engine>();
            for(int i = 0; i < numberEngine; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string modelEngine = data[0];
                int power = int.Parse(data[1]);
                int? displacement=null;
                string efficiency=null;

                if (data.Length == 3)
                {
                    if(int.TryParse(data[2],out int number))
                    {
                        displacement = number;
                    }
                    else
                    {
                        efficiency = data[2];
                    }
                }
                else if(data.Length==4)
                {
                     displacement=int.Parse(data[2]);
                    efficiency = data[3];
                }

                Engine engine = new Engine(modelEngine, power, displacement, efficiency);

                    engineDT[modelEngine] = engine;
            }

            int numberCars = int.Parse(Console.ReadLine());

            Car[] cars = new Car[numberCars];

            for(int i = 0; i < numberCars; i++)
            {
                string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string modelCar = data[0];
                string engineModel = data[1];
                int? weight = null;
                string color = null;

                if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int number))
                    {
                        weight = number;
                    }
                    else
                    {
                        color = data[2];
                    }
                }
                else if(data.Length==4)
                {
                    weight = int.Parse(data[2]);
                    color = data[3];
                }

                Engine engineFromDT = engineDT[engineModel];
                Car newCar = new Car(modelCar, engineFromDT, weight, color);

                cars[i] = newCar;

            }

            foreach (var car in cars) Console.WriteLine(car.ToString());


        }
    }
}
