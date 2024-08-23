
namespace _04.RawData
{
    internal class Program
    {
        class Car
        {
            public Car(string model, Engine engine, Cargo cargo)
            {
                Model = model;
                Engine = engine;
                Cargo = cargo;
            }

            public string Model { get; set; }
            public Engine Engine { get; set; }

            public Cargo Cargo { get; set; }
        }

        //<EngineSpeed> <EnginePower> <CargoWeight> <CargoType>", 

        class Engine
        {
            public Engine(int engineSpeed, int enginePower)
            {
                EngineSpeed = engineSpeed;
                EnginePower = enginePower;
            }

            public int EngineSpeed { get; set; }
            public int EnginePower { get; set; }
        }

        class Cargo
        {
            public Cargo(int cargoWeight, string cargoType)
            {
                CargoWeight = cargoWeight;
                CargoType = cargoType;
            }

            public int CargoWeight { get; set; }
            public string CargoType { get; set; }
        }
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> carList= new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] array = Console.ReadLine().Split();
                //"<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType>"
                string model= array[0];
                int engineSpeed= int.Parse(array[1]);
                int enginePower= int.Parse(array[2]);
                int cargoWeight= int.Parse(array[3]);
                string cartoType= array[4];

                carList.Add(new Car(model,new Engine(engineSpeed, enginePower),new Cargo(cargoWeight,cartoType)));
            }

            string command = Console.ReadLine(); //fragile" or "flamable". 

            if (command == "fragile")
            {
                //print all cars, whose Cargo Type is "fragile" with cargo with weight< 1000.
                foreach (var car in carList)
                {
                    if (car.Cargo.CargoType == "fragile" && car.Cargo.CargoWeight < 1000)
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
            }
            else if (command == "flamable")
            {
                //"flamable", print all of the cars whose Cargo Type is "flamable" and have Engine Power > 250
                foreach (var car in carList)
                {
                    if (car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
            }

        }
    }
}
