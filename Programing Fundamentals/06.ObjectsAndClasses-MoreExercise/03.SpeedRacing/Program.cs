
using System.Threading.Channels;

int numberOfCars = int.Parse(Console.ReadLine());

CarList carList = new CarList();


for (int i = 0; i < numberOfCars; i++)
{
    string[] array = Console.ReadLine().Split();
    string model = array[0];
    double fuelAmount = double.Parse(array[1]);
    double fuelConsumptForKM = double.Parse(array[2]);
    double travelDistan = 0;

    carList.AddCarsToList(model, fuelAmount, fuelConsumptForKM, travelDistan);

}

string input;
while ((input = Console.ReadLine()) != "End")
{
    string[] array = input.Split();
    string model = array[1];
    double amountOfKM = double.Parse(array[2]);

    carList.CalculateDistance(model, amountOfKM);
}

carList.OutPut();

class Car
{
    public Car(string model, double fuelAmount, double fuelComsumPerKm, double travelDistance)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelComsumPerKm = fuelComsumPerKm;
        TravelDistance = travelDistance;
    }

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelComsumPerKm { get; set; }
    public double TravelDistance { get; set; }


}

class CarList
{
    public List<Car> allCarList { get; set; } = new List<Car>();


    public void AddCarsToList(string model, double fuelAmount, double fuelConsumptForKm, double travelDistan)
    {
        allCarList.Add(new Car(model, fuelAmount, fuelConsumptForKm, travelDistan));
    }
    public void CalculateDistance(string model, double amoundOfKM)
    {

        foreach (Car car in allCarList) 
        {
            double fuelConsum = car.FuelComsumPerKm * amoundOfKM;
 
            if (car.Model == model) 
            { 
                if(car.FuelAmount >= fuelConsum)
                {
                    car.FuelAmount -= fuelConsum;
                    car.TravelDistance += amoundOfKM;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }

    }

    public void OutPut()
    {
        foreach (var car in allCarList)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelDistance}");
        }
    }

}


