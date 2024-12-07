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
            this.BatteryLevel = (int)(this.BatteryLevel * (mileage / this.MaxMileage));
            if(this.GetType().Name==nameof(CargoVan))
                this.BatteryLevel = (int)(this.BatteryLevel * 0.95);
        }

        public void ChangeStatus()
        {
            this.IsDamaged = !IsDamaged;
        }

        public void Recharge() => this.BatteryLevel = 100;

        public override string ToString() => $"{this.Brand} {this.Model} License plate: {this.LicensePlateNumber} Battery: {this.BatteryLevel}% Status: OK/damaged";
    }
}
