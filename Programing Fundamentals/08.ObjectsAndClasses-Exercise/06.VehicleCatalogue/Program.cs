namespace _06.VehicleCatalogue
{
    enum Type
    {
        Car,
        Truck
    }
    class Venichle
    {
        public Type Type;
        public string Model;
        public string Color;
        public double HP;

        public Venichle(string type, string model, string color, string hP)
        {
            Type = type == "car" ? Type.Car : Type.Truck;
            Model = model;
            Color = color;
            HP = double.Parse(hP);
        }

        public override string ToString()
        {
            return $"Type: {Type}\n" +
            $"Model: {Model}\n" +
            $"Color: {Color}\n" +
            $"Horsepower: {HP}";

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Venichle> venichleList = new List<Venichle>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                //"{typeOfVehicle} {model} {color} {horsepower}
                string[] inputArray = input.Split();
                string type = inputArray[0];
                string model = inputArray[1];
                string color = inputArray[2];
                string hp = inputArray[3];

                venichleList.Add(new Venichle(type, model, color, hp));

            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                string carModel = input;
                Venichle foundModel = venichleList.FirstOrDefault(venicle => venicle.Model == carModel);

                if (foundModel != null)
                {
                    Console.WriteLine(foundModel);
                }

            }

            double avaregeHp = venichleList.Where(venichle => venichle.Type == Type.Car)
                .Select(venichle => venichle.HP)
                .DefaultIfEmpty()
                .Average();
            Console.WriteLine($"Cars have average horsepower of: {avaregeHp:f2}.");

            avaregeHp = venichleList.Where(venichle => venichle.Type == Type.Truck)
                .Select(venichle => venichle.HP)
                .DefaultIfEmpty()
                .Average();
            Console.WriteLine($"Trucks have average horsepower of: {avaregeHp:f2}.");


        }
    }
}
