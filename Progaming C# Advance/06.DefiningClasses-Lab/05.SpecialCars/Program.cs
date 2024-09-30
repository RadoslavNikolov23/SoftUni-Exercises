namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string inputTires = Console.ReadLine();

            List<Tire[]> listTires = new List<Tire[]>();

            while (inputTires != "No more tires")
            {
                double[] array = inputTires.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                Tire[] tires = new Tire[4]
                {
                    new Tire((int)array[0], array[1]),
                    new Tire((int)array[2], array[3]),
                    new Tire((int)array[4], array[5]),
                    new Tire((int)array[6], array[7]),
                };

                listTires.Add(tires);
                inputTires = Console.ReadLine();
            }


            string inputEngine = Console.ReadLine();

            List<Engine> listEngine = new List<Engine>();

            while (inputEngine != "Engines done")
            {
                string[] array = inputEngine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(int.Parse(array[0]), double.Parse(array[1]));

                listEngine.Add(engine);
                inputEngine = Console.ReadLine();
            }

            Console.WriteLine();

            string inputSpecialCar = Console.ReadLine();
            List<Car> carList = new List<Car>();

            while (inputSpecialCar != "Show special")
            {
                string[] arrayCar = inputSpecialCar.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = arrayCar[0], model = arrayCar[1];
                int year = int.Parse(arrayCar[2]);
                double fuelQuantity = double.Parse(arrayCar[3]), fuelConsumption = double.Parse(arrayCar[4]);
                int engineIndex = int.Parse(arrayCar[5]), tireIndex = int.Parse(arrayCar[6]);

                Car car = new Car()
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    FuelQuantity = fuelQuantity,
                    FuelConsumption = fuelConsumption,
                    Engine = listEngine[engineIndex],
                    Tires = listTires[tireIndex],
                };

                carList.Add(car);
                inputSpecialCar = Console.ReadLine();
            }

            Func<double, bool> isBeetween9And10 = x => x >= 9 && x <= 10;
            Predicate<int> isMadeAfter2017 = x => x >= 2017;
            Predicate<int> has300Horsepower = x => x >= 300;

            foreach (Car car in carList)
            {
                if (isMadeAfter2017(car.Year) && has300Horsepower(car.Engine.HorsePower) && isBeetween9And10(car.Tires.Sum(x => x.Pressure)))
                {
                    car.Drive(20);
                    Console.WriteLine(car.SpecialCar());

                }
            }

        }

    }
}