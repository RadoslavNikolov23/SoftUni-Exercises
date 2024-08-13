namespace _03.Problem3_NeedforSpeedIII
{
    class Cars
    {
        public Cars(string carName, int mileage, int fuel)
        {
            CarName = carName;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string CarName { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            int numberOfCars = int.Parse(Console.ReadLine());
            Dictionary<string, Cars> carsDictionary = new Dictionary<string, Cars>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] arrayInput = Console.ReadLine().Split("|");
                string carName = arrayInput[0];
                int carMileage = int.Parse(arrayInput[1]);
                int carFuel = int.Parse(arrayInput[2]);

                carsDictionary.Add(carName, new Cars(carName, carMileage, carFuel));
            }

            string command;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] arrayComands = command.Split(" : ");
                string firstComand = arrayComands[0];

                switch (firstComand)
                {
                    case "Drive":
                        string carDrive = arrayComands[1];
                        int driveDistance = int.Parse(arrayComands[2]);
                        int carFuelForDistance = int.Parse(arrayComands[3]);
                        carsDictionary = CarDrive(carsDictionary, carDrive, driveDistance, carFuelForDistance);
                        break;

                    case "Refuel":
                        carDrive = arrayComands[1];
                        int carFuelForRefuel = int.Parse(arrayComands[2]);
                        carsDictionary = CarRefuel(carsDictionary, carDrive, carFuelForRefuel);
                        break;

                    case "Revert":
                        carDrive = arrayComands[1];
                        int carKilomToRevert = int.Parse(arrayComands[2]);
                        carsDictionary = CarToRevert(carsDictionary, carDrive, carKilomToRevert);
                        break;
                }
            }

            foreach (var (_, car) in carsDictionary)
            {
                Console.WriteLine($"{car.CarName} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
            //Upon receiving the "Stop" command, you need to print all cars in your possession in the following format:
            //"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt."

        }

        private static Dictionary<string, Cars> CarToRevert(Dictionary<string, Cars> carsDictionary, string carDrive, int carKilomToRevert)
        {
            Cars car = carsDictionary[carDrive];

            car.Mileage -= carKilomToRevert;

            if (car.Mileage < 10_000)
            {
                car.Mileage = 10000;
            }
            else
            {
                Console.WriteLine($"{car.CarName} mileage decreased by {carKilomToRevert} kilometers");
            }
            return carsDictionary;

            //•	"Revert : {car} : {kilometers}":
            //o Decrease the mileage of the given car with the given kilometers
            //and print the kilometers you have decreased it with in the following format:
            //"{car} mileage decreased by {amount reverted} kilometers"
            //o If the mileage becomes less than 10 000km after it is decreased,
            //just set it to 10 000km and
            //DO NOT print anything.
        }

        private static Dictionary<string, Cars> CarRefuel(Dictionary<string, Cars> carsDictionary, string carDrive, int carFuelForRefuel)
        {
            Cars car = carsDictionary[carDrive];

            if (car.Fuel + carFuelForRefuel > 75)
            {
                carFuelForRefuel = 75 - car.Fuel;

            }

            car.Fuel += carFuelForRefuel;
            Console.WriteLine($"{car.CarName} refueled with {carFuelForRefuel} liters");

            return carsDictionary;

            //•	"Refuel : {car} : {fuel}":
            //o Refill the tank of your car.
            //o Each tank can hold a maximum of 75 liters of fuel,
            //so if the given amount of fuel is more than you can fit in the tank,
            //take only what is required to fill it up.
            //o Print a message in the following format: "{car} refueled with {fuel} liters"
        }

        private static Dictionary<string, Cars> CarDrive(Dictionary<string, Cars> carsDictionary, string carDrive, int driveDistance, int carFuelForDistance)
        {
            Cars car = carsDictionary[carDrive];

            if (car.Fuel < carFuelForDistance)
            {
                Console.WriteLine($"Not enough fuel to make that ride");
            }
            else
            {
                car.Mileage += driveDistance;
                car.Fuel -= carFuelForDistance;
                Console.WriteLine($"{car.CarName} driven for {driveDistance} kilometers. {carFuelForDistance} liters of fuel consumed.");
            }

            if (car.Mileage >= 100_000)
            {
                carsDictionary.Remove(car.CarName);
                Console.WriteLine($"Time to sell the {car.CarName}!");
            }

            return carsDictionary;

            //•	"Drive : {car} : {distance} : {fuel}":
            //o You need to drive the given distance, and you will need the given fuel to do that.
            //If the car doesn't have enough fuel, print: "Not enough fuel to make that ride"
            //o If the car has the required fuel available in the tank,
            //increase its mileage with the given distance, decrease its fuel with the given fuel,
            //and print:
            //"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed."

            //o You like driving new cars only, so if a car's mileage reaches 100 000 km,
            //remove it from the collection(s) and print: "Time to sell the {car}!"
        }
    }
}
