using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException(ExceptionMessages.BrandNull);

            if (string.IsNullOrWhiteSpace(model))

                throw new ArgumentException(ExceptionMessages.ModelNull);

            if (string.IsNullOrWhiteSpace(licensePlateNumber))
                throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);

            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            BatteryLevel = 100;
            IsDamaged = false;
        }

        public string Brand { get; }
        public string Model { get; }
        public double MaxMileage { get; }
        public string LicensePlateNumber { get; }
        public int BatteryLevel { get; private set; }
        public bool IsDamaged { get; private set; }

        public void Drive(double mileage)
        {
            double percentage = Math.Round((mileage / this.MaxMileage) * 100);
            this.BatteryLevel -= (int)percentage;

            if (this.GetType().Name == nameof(CargoVan))
            {
                this.BatteryLevel -= 5;
            }
        }

        public void ChangeStatus()
        {
            if (!IsDamaged)
            {
                this.IsDamaged = true;
            }
            else
            {
                this.IsDamaged = false;
            }
        }

        public void Recharge() => this.BatteryLevel = 100;

        public override string ToString()
        {
            string vehicleCondition;

            if (IsDamaged)
            {
                vehicleCondition = "damaged";
            }
            else
            {
                vehicleCondition = "OK";
            }

            return $"{this.Brand} {this.Model} License plate: {this.LicensePlateNumber} Battery: {this.BatteryLevel}% Status: {vehicleCondition}";
        } 
    }
}
