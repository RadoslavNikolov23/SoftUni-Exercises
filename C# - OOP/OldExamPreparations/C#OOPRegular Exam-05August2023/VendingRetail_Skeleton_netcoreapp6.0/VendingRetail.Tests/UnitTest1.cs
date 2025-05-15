using NUnit.Framework;
using System;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        [Test]
        public void CoffeMatIntialization()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            Assert.That(coffeeMat, Is.Not.Null);
            Assert.That(coffeeMat.WaterCapacity, Is.EqualTo(waterCapacity));
            Assert.That(coffeeMat.ButtonsCount, Is.EqualTo(buttonsCount));
        }

        [Test]
        public void FillWaterTank_WorksProperly()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string result = coffeeMat.FillWaterTank();

            Assert.That(result, Is.EqualTo($"Water tank is filled with 100ml"));
        }

        [Test]
        public void FillWaterTank_WorksProperly_ButRetursDiffrentResult_WhenWaterCapacityIsZero()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            coffeeMat.FillWaterTank();
            string result = coffeeMat.FillWaterTank();

            Assert.That(result, Is.EqualTo($"Water tank is already full!"));
        }


        [Test]
        public void AddDrinks_WorksProperly_RetursTrue()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string drinkName = "Martini";
            double price = 12.50;

            bool result = coffeeMat.AddDrink(drinkName, price);

            Assert.That(result, Is.True);
        }

        [Test]
        public void AddDrinks_WorksProperly_ThrowsArgumentNullException()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string drinkName = null;
            double price = 12.50;

           Assert.Throws<ArgumentNullException>(()=> coffeeMat.AddDrink(drinkName, price));
        }

        [Test]
        public void AddDrinks_WorksProperly_RetursFalseWhenButtonsCountIsZero()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string drinkName = "Martini";
            double price = 12.50;

            coffeeMat.AddDrink("drinkName", price);
            coffeeMat.AddDrink("drinkName1", price);
            coffeeMat.AddDrink("drinkName2", price);
            coffeeMat.AddDrink("drinkName3", price);
            coffeeMat.AddDrink("drinkName4", price);
            bool result = coffeeMat.AddDrink(drinkName, price);
      
            Assert.That(result, Is.False);
        }

        [Test]
        public void AddDrinks_WorksProperly_RetursFalseWhenTheresAlreadyADrinkWithTheSameName()
        {
            int waterCapacity = 100;
            int buttonsCount = 1000;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string drinkName = "Martini";
            double price = 12.00;
            coffeeMat.AddDrink(drinkName, price);
            bool resultTwo = coffeeMat.AddDrink(drinkName, price);

            Assert.That(resultTwo, Is.False);
        }

        [Test]
        public void BuyDrinks_WorksProperly()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string drinkName = "Martini";
            double price = 12.50;

            coffeeMat.AddDrink(drinkName, price);
            coffeeMat.FillWaterTank();

            string result = coffeeMat.BuyDrink(drinkName);
            Assert.That(result, Is.EqualTo($"Your bill is 12.50$"));
        }


        [Test]
        public void BuyDrinks_WorksProperly_ButRetursThatCoffiMatIsOutOfWatter()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string drinkName = "Martini";
            double price = 12.50;

            coffeeMat.AddDrink(drinkName, price);

            string result = coffeeMat.BuyDrink(drinkName);
            Assert.That(result, Is.EqualTo($"CoffeeMat is out of water!"));
        }

        [Test]
        public void BuyDrinks_WorksProperly_ButRetursThatThereIsNoDrinkWithTHeGivenName()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Martini";
            double price = 12.50;
            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink(drinkName, price);
            string drinkNameToBuy = "Coffe";

            string result = coffeeMat.BuyDrink(drinkNameToBuy);
            Assert.That(result, Is.EqualTo($"Coffe is not available!"));
        }

        [Test]
        public void BuyDrinks_WorksProperly_ButRetursThatCoffiMatIsOutOfWatter2()
        {
            int waterCapacity = 60;
            int buttonsCount = 1000;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string drinkName = "Martini";
            double price = 12.00;
            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink(drinkName, price);

            string result = coffeeMat.BuyDrink(drinkName);
            Assert.That(result, Is.EqualTo($"CoffeeMat is out of water!"));
        }

        [Test]
        public void CollectIncome_WorksProperly()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string drinkName = "Martini";
            double price = 12.50;
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink(drinkName, price);
            coffeeMat.AddDrink("drinkName", price);
            coffeeMat.BuyDrink(drinkName);
            coffeeMat.BuyDrink("drinkName");

            double actualIncome=coffeeMat.Income;
            double result = coffeeMat.CollectIncome();

            Assert.That(result, Is.EqualTo(12.50));
            Assert.That(coffeeMat.Income, Is.EqualTo(0));
            Assert.That(actualIncome, Is.EqualTo(12.50));
        }

        [Test]
        public void CollectIncome_WorksProperly2()
        {
            int waterCapacity = 100;
            int buttonsCount = 5;

            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            double result = coffeeMat.CollectIncome();
            Assert.That(result, Is.EqualTo(0));
            Assert.That(coffeeMat.Income, Is.EqualTo(0));
        }


    }
}