using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"Make: {Make}");
            sbResult.AppendLine($"Model: {Model}");
            sbResult.AppendLine($"HorsePower: {HorsePower}");
            sbResult.Append($"RegistrationNumber: {RegistrationNumber}");

            return sbResult.ToString();
        }


    }
}
