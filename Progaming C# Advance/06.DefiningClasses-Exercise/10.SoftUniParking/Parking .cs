using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> carsDT;
        private int capacity;
        private int count;

        public int Count =>this.carsDT.Count;
     

        public Parking(int capacity)
        {
            CarsDT = new Dictionary<string, Car>();
            Capacity = capacity;
        }

        public Dictionary<string, Car> CarsDT
        {
            get { return carsDT; }
            set { carsDT = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"{carsDT}");
            return sbResult.ToString();
        }

        public string AddCar(Car car)
        {
            if (this.carsDT.ContainsKey(car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (this.carsDT.Count == Capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                this.carsDT.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.carsDT.ContainsKey(registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                this.carsDT.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return this.CarsDT[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                this.CarsDT.Remove(registrationNumber);
            }
        }
    }
}
