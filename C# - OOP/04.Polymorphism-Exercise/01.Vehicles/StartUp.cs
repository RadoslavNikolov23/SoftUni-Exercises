using System.Diagnostics;
using Vehicles.Classes;
using Vehicles.Interface;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IVehicle car = GetVehicle();
            IVehicle truck = GetVehicle();

            List<IVehicle> vehicles = new List<IVehicle>();
            vehicles.Add(car);
            vehicles.Add(truck);

            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                string[] commandArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                CheckCommand(commandArray, vehicles);
            }

            PrintVehicles(vehicles);

        }

        private static void PrintVehicles(List<IVehicle> vehicles)
        {
            foreach(var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());

            }
        }

        private static void CheckCommand(string[] commandArray, List<IVehicle> vehicles)
        {
            string command = commandArray[0];
            string vehicleType = commandArray[1];

            if (command == "Drive")
            {
                double distance = double.Parse(commandArray[2]);

                DriveVehicle(vehicleType, distance, vehicles);
            }
            else if (command == "Refuel")
            {
                double liters = double.Parse(commandArray[2]);

                RefuelVehicle(vehicleType, liters, vehicles);
            }
        }

        private static void RefuelVehicle(string vehicleType, double liters, List<IVehicle> vehicles)
        {
            switch (vehicleType)
            {
                case "Car":
                    IVehicle car = vehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);
                    car.Refueled(liters);
                    break;

                case "Truck":
                    IVehicle truck = vehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);
                    truck.Refueled(liters);
                    break;
            }
        }

        private static void DriveVehicle(string vehicleType, double distance, List<IVehicle> vehicles)
        {
            switch (vehicleType)
            {
                case "Car":
                    IVehicle car = vehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);

                    if (car.Driven(distance))Console.WriteLine($"Car travelled {distance} km");
                    else Console.WriteLine($"Car needs refueling");

                    break;

                case "Truck":
                    IVehicle truck = vehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);

                    if (truck.Driven(distance)) Console.WriteLine($"Truck travelled {distance} km");
                    else Console.WriteLine($"Truck needs refueling");

                    break;
            }
        }

        public static IVehicle GetVehicle()
        {
            string[] dataVehicle = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = dataVehicle[0];

            switch (vehicleType)
            {
                case "Car": return new Car(double.Parse(dataVehicle[1]), double.Parse(dataVehicle[2]));
                case "Truck": return new Truck(double.Parse(dataVehicle[1]), double.Parse(dataVehicle[2]));
                default: throw new ArgumentException("Invalid vehicle type!");
            }

        }

    }


}
