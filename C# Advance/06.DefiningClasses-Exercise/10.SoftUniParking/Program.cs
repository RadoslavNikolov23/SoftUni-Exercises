using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");
            var car3 = new Car("BMW", "318", 120, "P0625KX");
            var car4 = new Car("VW", "|Golf", 120, "CB4554BC");
            var car5 = new Car("Nissan", "GTR", 330, "X0440PC");
            var car6 = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(car.ToString());

            Parking carList = new Parking(5);

            Console.WriteLine(carList.AddCar(car));
            Console.WriteLine(carList.AddCar(car2));
            Console.WriteLine(carList.AddCar(car3));
            Console.WriteLine(carList.AddCar(car4));
            Console.WriteLine(carList.AddCar(car5));

            Console.WriteLine(carList.AddCar(car));
            Console.WriteLine(carList.AddCar(car6));

            Console.WriteLine(carList.RemoveCar("EB8787MN"));

            Console.WriteLine(carList.Count);

            List<string> registration = new List<string>() { car2.RegistrationNumber, car.RegistrationNumber };

            carList.RemoveSetOfRegistrationNumber(registration);

            Console.WriteLine(carList.Count);

        }
    }
}
