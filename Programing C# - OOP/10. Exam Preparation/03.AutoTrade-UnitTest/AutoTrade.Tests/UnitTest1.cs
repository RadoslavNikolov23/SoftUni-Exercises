using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {

        [Test]
        public void DealerShopInitialization()
        {
            DealerShop dealerShop = new DealerShop(5);

            Assert.IsNotNull(dealerShop);
            Assert.That(dealerShop.Capacity, Is.EqualTo(5));
            Assert.That(dealerShop.Vehicles.Count, Is.EqualTo(0));
        }

        [TestCase(0),TestCase(-5)]
        public void DealerShopThrosException_WhenInitializationAndCapacityIsBelowOne(int capacityTest)
        {
            DealerShop dealerShop = null;
            var exception = Assert.Throws<ArgumentException>(() => dealerShop=new DealerShop(capacityTest));

            Assert.That(exception.Message, Is.EqualTo("Capacity must be a positive value."));
        }


        [Test]
        public void DealerShopAddMethod_WorksCorrelcy()
        {
            DealerShop dealerShop = new DealerShop(5);
            Assert.That(dealerShop.Vehicles.Count(), Is.Zero);

            Vehicle vehicle = new Vehicle("Ford", "Ford", 1993);
            string input=dealerShop.AddVehicle(vehicle);

            Assert.That(dealerShop.Vehicles.Count(), Is.EqualTo(1));
            Assert.That(input, Is.EqualTo($"Added {vehicle}"));
        }


        [Test]
        public void DealerShopAddMethod_ThrowsException_WhenCapacityIsReach()
        {
            DealerShop dealerShop = new DealerShop(1);
            Vehicle vehicleOne = new Vehicle("Ford", "Ford", 1993);
            string input = dealerShop.AddVehicle(vehicleOne);           
            
            Vehicle vehicleTwo = new Vehicle("Audi", "A4", 2000);


            var exception = Assert.Throws<InvalidOperationException>(() => dealerShop.AddVehicle(vehicleTwo));

            Assert.That(exception.Message, Is.EqualTo("Inventory is full"));
        }


        [Test]
        public void DealerShopRemoveMethod_ReturnsTrueIfCarExist()
        {
            DealerShop dealerShop = new DealerShop(5);

            Vehicle vehicle = new Vehicle("Ford", "Ford", 1993);
            dealerShop.AddVehicle(vehicle);
            bool isSold = dealerShop.SellVehicle(vehicle);

            Assert.That(dealerShop.Vehicles.Count(), Is.EqualTo(0));
            Assert.That(isSold, Is.True);
        }

        [Test]
        public void DealerShopRemoveMethod_ReturnsFalseIfCarDoentExist()
        {
            DealerShop dealerShop = new DealerShop(5);

            Vehicle vehicle = new Vehicle("Ford", "Ford", 1993);
            bool isSold = dealerShop.SellVehicle(vehicle);

            Assert.That(dealerShop.Vehicles.Count(), Is.EqualTo(0));
            Assert.That(isSold, Is.False);
        }

        [Test]
        public void DealerInvetoryMethods_WorksProperly()
        {
            DealerShop dealerShop = new DealerShop(2);
            for(int i=0; i<2; i++)
            {
                Vehicle vehicle = new Vehicle($"{i}", $"{i+100}", i+200);
                dealerShop.AddVehicle(vehicle);
            }

            string result = dealerShop.InventoryReport();
            string expected= $"Inventory Report{Environment.NewLine}Capacity: 2{Environment.NewLine}Vehicles: 2{Environment.NewLine}200 0 100{Environment.NewLine}201 1 101";




            Assert.That(expected, Is.EqualTo(result));
        }

    }
}
