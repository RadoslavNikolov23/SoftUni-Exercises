using System;
using System.Collections.Generic;


namespace _07.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carParkingLot = new HashSet<string>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] array = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = array[0].ToUpper();
                string carNumber = array[1];

                if (direction == "IN")
                {
                    carParkingLot.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    carParkingLot.Remove(carNumber);
                }
            }

            if (carParkingLot.Count > 0)
                Console.WriteLine(string.Join("\n", carParkingLot));
            else
                Console.WriteLine("Parking Lot is Empty");
        }
    }
}
