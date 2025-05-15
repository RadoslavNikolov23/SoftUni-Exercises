namespace _07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Catalog catalogCarsandTruck = new Catalog();


            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArray = input.Split("/");

                string type = inputArray[0];

                if (type == "Car")
                {
                    string brand = inputArray[1];
                    string model = inputArray[2];
                    int horsePower = int.Parse(inputArray[3]);

                    catalogCarsandTruck.Cars.Add(new Car()
                    {
                        Brand = brand,
                        HorsePower = horsePower,
                        Model = model
                    });
                  
                    
                }
                else if (type == "Truck")
                {
                    string brand = inputArray[1];
                    string model = inputArray[2];
                    int weight = int.Parse(inputArray[3]);


                    catalogCarsandTruck.Trucks.Add(new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    });
                 
                }


            }


            if (catalogCarsandTruck.Cars.Count > 0)
            {
                Console.WriteLine($"Cars:");
                foreach (Car carList in catalogCarsandTruck.Cars.OrderBy(car => car.Brand))
                {
                    Console.WriteLine($"{carList.Brand}: {carList.Model} - {carList.HorsePower}hp");
                }
            }

            if (catalogCarsandTruck.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks:");
                foreach (Truck truckList in catalogCarsandTruck.Trucks.OrderBy(truck => truck.Brand))
                {
                    Console.WriteLine($"{truckList.Brand}: {truckList.Model} - {truckList.Weight}kg");
                }
            }
            


        }

        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
            //Define a class Truck with the following properties: Brand, Model, and Weight.

        }

        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
            //    Define a class Car with the following properties: Brand, Model, and Horse Power.

        }

        class Catalog
        {
            public List<Car> Cars { get; set; }
            public List<Truck> Trucks{ get; set; }

            public Catalog()
            {
                Cars = new List<Car>();
                Trucks = new List<Truck>();
            }

            //    Define a class Catalog with the following properties: Collections of Trucks and Cars.

        }


    }
}
