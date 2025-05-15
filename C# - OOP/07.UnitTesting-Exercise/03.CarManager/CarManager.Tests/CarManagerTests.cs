namespace CarManager.Tests;

using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

[TestFixture]
public class CarManagerTests
{
    private string _make, _model;
    private double _fuelComsumption, _fuelCapacity;
    private const double _fuelAmountIsAlwaysZero = 0;

    [SetUp]
    public void SetUpAllTheProperties()
    {
        this._make = RandomStringGenerator();
        this._model = RandomStringGenerator();
        this._fuelComsumption = RandomNumberGenerator();
        this._fuelCapacity = RandomNumberGenerator();
    }

    [Test]
    public void DoCarConstructorsWorkNormally()
    {
        Car car = GeneratorOfCar();

        Assert.IsNotNull(car);
        Assert.That(car.Make, Is.EqualTo(this._make));
        Assert.That(car.Model, Is.EqualTo(this._model));
        Assert.That(car.FuelConsumption, Is.EqualTo(_fuelComsumption));
        Assert.That(car.FuelCapacity, Is.EqualTo(_fuelCapacity));
        Assert.That(car.FuelAmount, Is.EqualTo(_fuelAmountIsAlwaysZero));
    }


    [TestCaseSource(nameof(CasesForTestingTheProperties))]
    public void DoesMakeThrowExceptionIfNullorEmpty(string makeNullEmpty) => Assert.Throws<ArgumentException>(() => new Car(makeNullEmpty, this._model, this._fuelComsumption, this._fuelCapacity));

    [TestCaseSource(nameof(CasesForTestingTheProperties))]
    public void DoesModelThrowExceptionIfNullorEmpty(string modelNullEmpty) => Assert.Throws<ArgumentException>(() => new Car(this._make, modelNullEmpty, this._fuelComsumption, this._fuelCapacity));


    [TestCase(-1), TestCase(-15),TestCase(0)]
    public void DoesFuelConsumptionThrowExceptionIfIsLessThanZero(int negativeNumber) => Assert.Throws<ArgumentException>(() => new Car(this._make, this._model, this._fuelComsumption * negativeNumber, this._fuelCapacity));


    [TestCase(-1), TestCase(-15), TestCase(0)]
    public void DoesFuelCapacityThrowExceptionIfIsLessThanZero(int negativeNumber) => Assert.Throws<ArgumentException>(() => new Car(this._make, this._model, this._fuelComsumption, this._fuelCapacity * negativeNumber));

    [TestCase(10), TestCase(50)]
    public void DoRefuelMethodWorkNormally(double fuelToRefuel)
    {
        Car car = GeneratorOfCar();
        car.Refuel(fuelToRefuel+car.FuelCapacity);
        Assert.That(car.FuelAmount,Is.EqualTo(car.FuelCapacity));
    }

    [TestCase(0), TestCase(-32)]
    public void DoRefuelMethodThrowException(double fuelToRefuel)
    {
        Car car = GeneratorOfCar();
        Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
    }

    [TestCase(10),TestCase(40)]
    public void DoDriveMethodWorkProperly(double distance)
    {
        Car car = GeneratorOfCar();
        double fuelToRefuel = Random.Shared.Next((int)distance)*this._fuelComsumption;
        car.Refuel(fuelToRefuel);
        double carFuelAmoutOrignal = car.FuelAmount;

        car.Drive(distance);
        double fuelNeed= (distance / 100)*car.FuelConsumption;
        Assert.That(car.FuelAmount, Is.EqualTo(carFuelAmoutOrignal-fuelNeed));
    }


    [TestCase(10), TestCase(40)]
    public void DoDriveMethodThrowException(double distance)
    {
        Car car = GeneratorOfCar();
       Assert.Throws<InvalidOperationException>(()=> car.Drive(distance));
    }

    private Car GeneratorOfCar()=>new Car(this._make,this._model,this._fuelComsumption,this._fuelCapacity);
    public static IEnumerable<object[]> CasesForTestingTheProperties()
    {
        yield return new object[] {null};
        yield return new object[] {string.Empty};
    }

    private double RandomNumberGenerator() => (double)Random.Shared.Next(0, Int16.MaxValue);

    private string RandomStringGenerator()
    {
        Random radnom = new Random();
        int lenght = Random.Shared.Next(1, 100);
        string allSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string result = new string(Enumerable.Repeat(allSymbols, lenght).Select(x => x[radnom.Next(x.Length)]).ToArray());
        return result;
    }

}