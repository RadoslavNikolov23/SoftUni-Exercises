using System.Diagnostics;
using System.Threading.Channels;
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
            IVehicle bus = GetVehicle();

            List<IVehicle> vehicles = new List<IVehicle>() {car,truck,bus };

            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                string[] commandArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vehicleType = commandArray[1];
                IVehicle vehicle = vehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);

                CheckCommand(commandArray, vehicle);
            }

            PrintVehicles(vehicles);

        }

        private static void PrintVehicles(List<IVehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }

        private static void CheckCommand(string[] commandArray, IVehicle? vehicle)
        {
            string command = commandArray[0];

            if (command == "Drive")
            {
                double distance = double.Parse(commandArray[2]);
                Console.WriteLine(vehicle.Driven(distance));
            }
            else if (command == "Refuel")
            {
                double liters = double.Parse(commandArray[2]);
                vehicle.Refueled(liters);
            }

            else if (command == "DriveEmpty")
            {
                double distance = double.Parse(commandArray[2]);
                Console.WriteLine(vehicle.DriveEmpty(distance));
            }
        }

        public static IVehicle GetVehicle()
        {
            string[] dataVehicle = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = dataVehicle[0];

            switch (vehicleType)
            {
                case "Car": return new Car(double.Parse(dataVehicle[1]), 
                    double.Parse(dataVehicle[2]), double.Parse(dataVehicle[3]));

                case "Truck": return new Truck(double.Parse(dataVehicle[1]), 
                    double.Parse(dataVehicle[2]), double.Parse(dataVehicle[3]));

                case "Bus": return new Bus(double.Parse(dataVehicle[1]), 
                    double.Parse(dataVehicle[2]), double.Parse(dataVehicle[3]));

                default: throw new ArgumentException("Invalid vehicle type!");
            }
        }
    }
}
