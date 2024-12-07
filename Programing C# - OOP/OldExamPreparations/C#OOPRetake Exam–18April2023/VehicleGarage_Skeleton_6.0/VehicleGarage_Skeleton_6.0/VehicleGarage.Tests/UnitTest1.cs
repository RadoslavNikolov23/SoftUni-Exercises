using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace VehicleGarage.Tests
{
    public class Tests
    {

        [Test]
        public void GarageIntialization()
        {
            int capacity = 10;
            Garage garage = new Garage(capacity);

            Assert.That(garage, Is.Not.Null);
            Assert.That(garage.Capacity, Is.EqualTo(capacity));
            Assert.That(garage.Vehicles, Is.Not.Null);
            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddVehicle_WorksProperly()
        {
            string brand = "Audi";
            string model = "A4";
            string licensePlateNumber = "P1111PP";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);

            Assert.That(vehicle, Is.Not.Null);
            Assert.That(vehicle.Brand, Is.EqualTo(brand));
            Assert.That(vehicle.Model, Is.EqualTo(model));
            Assert.That(vehicle.LicensePlateNumber, Is.EqualTo(licensePlateNumber));
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
            Assert.That(vehicle.IsDamaged, Is.False);

            int capacity = 10;
            Garage garage = new Garage(capacity);

            garage.AddVehicle(vehicle);
            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddVehicle_WorksProperly_RetursTrue()
        {
            int capacity = 10;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i}", $"{i + 100}", $"{i + 300}");
                bool isTrue = garage.AddVehicle(vehicle);
                Assert.That(isTrue, Is.True);
                Assert.That(garage.Vehicles.Count, Is.EqualTo(i + 1));
            }
        }

        [Test]
        public void AddVehicle_WorksProperly_RetursFalseFillCapacity()
        {
            int capacity = 10;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i}", $"{i + 100}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }
            Vehicle vehicleOneMore = new Vehicle($"Audi", $"A6", $"P000PP");
            bool isFalse = garage.AddVehicle(vehicleOneMore);
            Assert.That(isFalse, Is.False);
        }

        [Test]
        public void AddVehicle_WorksProperly_RetursFalse_CarWithSamePlateAdded()
        {
            int capacity = 10;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity - 1; i++)
            {
                Vehicle vehicle = new Vehicle($"{i}", $"{i + 100}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }
            Vehicle vehicleOneMore = new Vehicle($"Audi", $"A6", $"{1 + 300}");
            bool isFalse = garage.AddVehicle(vehicleOneMore);
            Assert.That(isFalse, Is.False);
        }

        [Test]
        public void DriveVehicle_WorksProperly_AcciendIsFalse()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }

            string licensePlateNumber = "301";
            int batteryDrainage = 50; 
            bool accidentOccured = false;

            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Vehicle vehicleToCheck=garage.Vehicles.FirstOrDefault(v=>v.LicensePlateNumber==licensePlateNumber);
            Assert.That(vehicleToCheck.BatteryLevel, Is.EqualTo(100-batteryDrainage));
            Assert.That(vehicleToCheck.IsDamaged, Is.False);
        }

        [Test]
        public void DriveVehicle_WorksProperly_AcciendIsTrue()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }

            string licensePlateNumber = "301";
            int batteryDrainage = 50; 
            bool accidentOccured = true;

            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Vehicle vehicleToCheck=garage.Vehicles.FirstOrDefault(v=>v.LicensePlateNumber==licensePlateNumber);
            Assert.That(vehicleToCheck.BatteryLevel, Is.EqualTo(100-batteryDrainage));
            Assert.That(vehicleToCheck.IsDamaged, Is.True);
        }

        [Test]
        public void DriveVehicle_WorksProperly_ButReturns_WhenIsDamage_IsTrue()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }

            string licensePlateNumber = "301";
            int batteryDrainage = 50; 
            bool accidentOccured = true;

            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Vehicle vehicleToCheck=garage.Vehicles.FirstOrDefault(v=>v.LicensePlateNumber==licensePlateNumber);
            Assert.That(vehicleToCheck.BatteryLevel, Is.EqualTo(100-batteryDrainage));
            Assert.That(vehicleToCheck.IsDamaged, Is.True);

            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Assert.That(vehicleToCheck.BatteryLevel, Is.EqualTo(100 - batteryDrainage));
            Assert.That(vehicleToCheck.IsDamaged, Is.True);

        }

        [Test]
        public void DriveVehicle_WorksProperly_ButReturns_WhenBatterLeveisOver100()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }

            string licensePlateNumber = "301";
            int batteryDrainage = 150; 
            bool accidentOccured = true;

            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Vehicle vehicleToCheck=garage.Vehicles.FirstOrDefault(v=>v.LicensePlateNumber==licensePlateNumber);
            Assert.That(vehicleToCheck.BatteryLevel, Is.EqualTo(100));
            Assert.That(vehicleToCheck.IsDamaged, Is.False);
        }


        [Test]
        public void DriveVehicle_WorksProperly_ButReturns_WhenBatterLevelIsLowerThanDrainage()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }

            string licensePlateNumber = "301";
            int batteryDrainage = 40;
            bool accidentOccured = false;

            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Vehicle vehicleToCheck = garage.Vehicles.FirstOrDefault(v => v.LicensePlateNumber == licensePlateNumber);

            Assert.That(vehicleToCheck.BatteryLevel, Is.EqualTo(100 - batteryDrainage));
            Assert.That(vehicleToCheck.IsDamaged, Is.False);

            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Assert.That(vehicleToCheck.BatteryLevel, Is.EqualTo(100 - batteryDrainage*2));
            Assert.That(vehicleToCheck.IsDamaged, Is.False);
            
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Assert.That(vehicleToCheck.BatteryLevel, Is.EqualTo(100 - batteryDrainage*2));
            Assert.That(vehicleToCheck.IsDamaged, Is.False);
        }


        [Test]
        public void DriveVehicle_ThrowsException()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }

            string licensePlateNumber = "3";
            int batteryDrainage = 50;
            bool accidentOccured = false;

            Assert.Throws<NullReferenceException>(()=>garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured));
        }

        [Test]
        public void ChargeVehicles_WorksProperly()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }  
            
            for (int i = 0; i < capacity; i++)
            {
                string licensePlateNumber = $"{i+300}";
                int batteryDrainage = 40;
                bool accidentOccured = false;
                garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            }

            int result = garage.ChargeVehicles(90);

            Assert.That(result, Is.EqualTo(5));

            foreach(var vehicle in garage.Vehicles)
                Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
        }

        [Test]
        public void ChargeVehicles_WorksProperly_ButWillChargeOnlyToCars()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }  
            
            for (int i = 0; i < 2; i++)
            {
                string licensePlateNumber = $"{i+300}";
                int batteryDrainage = 40;
                bool accidentOccured = false;
                garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            }
            int result = garage.ChargeVehicles(90);
            Assert.That(result, Is.EqualTo(2));
        }


        [Test]
        public void RepairVehicles_WorksProperly()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }

            for (int i = 0; i < capacity; i++)
            {
                string licensePlateNumber = $"{i + 300}";
                int batteryDrainage = 40;
                bool accidentOccured = true;
                garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            }

            string result = garage.RepairVehicles();
            Assert.That(result, Is.EqualTo($"Vehicles repaired: {capacity}"));

            foreach (var vehicle in garage.Vehicles)
                Assert.That(vehicle.IsDamaged, Is.False);
        }


        [Test]
        public void RepairVehicles_WorksProperly_RepairsOnlyDamage()
        {
            int capacity = 5;
            Garage garage = new Garage(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Vehicle vehicle = new Vehicle($"{i + 100}", $"{i + 200}", $"{i + 300}");
                garage.AddVehicle(vehicle);
            }

            for (int i = 0; i < 2; i++)
            {
                string licensePlateNumber = $"{i + 300}";
                int batteryDrainage = 40;
                bool accidentOccured = true;
                garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
                Assert.That(garage.Vehicles[i].IsDamaged,Is.True);
            }

            string result = garage.RepairVehicles();
            Assert.That(result, Is.EqualTo($"Vehicles repaired: 2"));

            foreach (var vehicle in garage.Vehicles)
                Assert.That(vehicle.IsDamaged, Is.False);
        }
    }
}