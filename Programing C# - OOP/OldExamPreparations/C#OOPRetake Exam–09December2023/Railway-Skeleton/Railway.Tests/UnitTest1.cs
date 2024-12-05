namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RailStationInitialization_WorksCorrecly()
        {
            string name = "Tom";

            RailwayStation railwayStation= new RailwayStation(name);

            Assert.That(railwayStation,Is.Not.Null);
            Assert.That(railwayStation.Name,Is.EqualTo(name));
            Assert.That(railwayStation.ArrivalTrains, Is.Not.Null);
            Assert.That(railwayStation.DepartureTrains, Is.Not.Null);    
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(0));
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(0));

        }

        [Test]
        public void RailStationInitialization_ThrowsException_WhenNameIsNull()
        {
            string name = null;

            var excetion=Assert.Throws<ArgumentException>(()=> new RailwayStation(name));

            Assert.That(excetion.Message,Is.EqualTo("Name cannot be null or empty!"));


        }

        [Test]
        public void RailStationInitialization_ThrowsException_WhenNameIsWhiteSpace()
        {
            string name = " ";

            var excetion=Assert.Throws<ArgumentException>(()=> new RailwayStation(name));

            Assert.That(excetion.Message,Is.EqualTo("Name cannot be null or empty!"));


        }


        [Test]
        public void NewArrivalOnBoard_WorksCorrecly()
        {
            string name = "Tom";
            string trainInfo = "Test";
            RailwayStation railwayStation = new RailwayStation(name);
            railwayStation.NewArrivalOnBoard(trainInfo);

            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(1));

            for(int i = 0; i < 5; i++)
            {
                railwayStation.NewArrivalOnBoard($"{i}");
                Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(i + 2));
            }

        }

        [Test]
        public void TrainHasArrived_WorksCorrecly()
        {
            string name = "Tom";
            string trainInfo = "Test";
            RailwayStation railwayStation = new RailwayStation(name);
            railwayStation.NewArrivalOnBoard(trainInfo);

            for(int i = 0; i < 2; i++)
            {
                railwayStation.NewArrivalOnBoard($"{i}");
            }

            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(3));
            string result=railwayStation.TrainHasArrived(trainInfo);
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(1));

            Assert.That(result, Is.EqualTo($"{trainInfo} is on the platform and will leave in 5 minutes."));
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(2));


        }

        [Test]
        public void TrainHasArrived_WorksCorrecly_ButReturs_DiffrentResult()
        {
            string name = "Tom";
            string trainInfo = "Test";
            RailwayStation railwayStation = new RailwayStation(name);

            for(int i = 0; i < 2; i++)
            {
                railwayStation.NewArrivalOnBoard($"{i}");
            }

            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(2));
            string result=railwayStation.TrainHasArrived(trainInfo);
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(0));

            Assert.That(result, Is.EqualTo($"There are other trains to arrive before {trainInfo}."));
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(2));


        }


        [Test]
        public void TrainHasLeft_WorksCorrecly_ReturnsTrue()
        {
            string name = "Tom";
            string trainInfo = "Test";
            RailwayStation railwayStation = new RailwayStation(name);
            railwayStation.NewArrivalOnBoard(trainInfo);


            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(1));
            string result = railwayStation.TrainHasArrived(trainInfo);
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(1));

            bool trainDepartured=railwayStation.TrainHasLeft(trainInfo);

            Assert.That(trainDepartured, Is.True);
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(0));

        }

        [Test]
        public void TrainHasLeft_WorksCorrecly_ReturnsFalse()
        {
            string name = "Tom";
            string trainInfo = "Test";
            RailwayStation railwayStation = new RailwayStation(name);
            railwayStation.NewArrivalOnBoard(trainInfo);


            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(1));
            string result = railwayStation.TrainHasArrived(trainInfo);
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(1));

            bool trainDepartured=railwayStation.TrainHasLeft("DiffrentTrain");

            Assert.That(trainDepartured, Is.False);
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(1));

        }


    }
}