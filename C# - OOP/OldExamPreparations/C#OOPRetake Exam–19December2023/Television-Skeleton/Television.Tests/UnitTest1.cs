namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private string brand;
        private double price;
        private int screenWidth;
        private int screenHeigth;

        private TelevisionDevice tv = null;

        [SetUp]
        public void Setup()
        {

            this.brand = "Samsung";
            this.price = 1000;
            this.screenWidth = 1050;
            this.screenHeigth = 560;

            this.tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
        }

        [Test]
        public void TelevisionDeviceInitialization()
        {
            string brand = "Samsung";
            double price = 1000;
            int screenWidth = 1050;
            int screenHeigth = 560;
            int lastChannel = 0;
            int lastVolume = 13;
            bool lastMuted = false;

            TelevisionDevice tv= new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            Assert.That(tv, Is.Not.Null);
            Assert.That(brand, Is.EqualTo(tv.Brand));
            Assert.That(price, Is.EqualTo(tv.Price));
            Assert.That(screenWidth, Is.EqualTo(tv.ScreenWidth));
            Assert.That(screenHeigth, Is.EqualTo(tv.ScreenHeigth));
            Assert.That(lastChannel, Is.EqualTo(tv.CurrentChannel));
            Assert.That(lastVolume, Is.EqualTo(tv.Volume));
            Assert.That(lastMuted, Is.EqualTo(tv.IsMuted));
          

        }

        [Test]
        public void MutedWorkcCorrecly_ReturnsTrue ()
        {
            bool lastMuted = false;

           bool isMuted= tv.MuteDevice();
    
            Assert.That(lastMuted, Is.EqualTo(!tv.IsMuted));
            Assert.That(isMuted, Is.EqualTo(true));
        }

        [Test]
        public void MutedWorksCorrecly_ReturnsFalse ()
        {
            bool lastMuted = false;

           bool isMuted= tv.MuteDevice();
    
            Assert.That(lastMuted, Is.EqualTo(!tv.IsMuted));
            Assert.That(isMuted, Is.EqualTo(true));

            isMuted = tv.MuteDevice();
            Assert.That(lastMuted, Is.EqualTo(tv.IsMuted));
            Assert.That(isMuted, Is.EqualTo(false));
        }


        [Test]
        public void SwitchOnWorksCorrecly()
        {
            string result = tv.SwitchOn();
            string sound = "On";

            Assert.That(result, Is.EqualTo($"Cahnnel {tv.CurrentChannel} - Volume {tv.Volume} - Sound {sound}"));

        }

        [Test]
        public void SwitchOnWorksCorrecly_AndReturnsOff()
        {

            tv.MuteDevice();
            string result = tv.SwitchOn();
            string sound = "Off";
            Assert.That(result, Is.EqualTo($"Cahnnel {tv.CurrentChannel} - Volume {tv.Volume} - Sound {sound}"));


        }


        [TestCase(15), TestCase(0), TestCase(100)]
        public void ChangeChannelWorksCorrecly_AndReturnslastChannel(int channelToChange)
        {
            int lastChannelResult=tv.ChangeChannel(channelToChange);


            Assert.That(lastChannelResult, Is.EqualTo(channelToChange));
            Assert.That(tv.CurrentChannel, Is.EqualTo(channelToChange));


        }

        [TestCase(-15), TestCase(-1)]
        public void ChangeChannelThrowsException_WhenChannelIsBelowZero(int channelToChange)
        {

            var exception=Assert.Throws<ArgumentException>(()=>tv.ChangeChannel(channelToChange));


            Assert.That(exception.Message, Is.EqualTo("Invalid key!"));
        }

        [TestCase("UP",10, 23), TestCase("DOWN",50,0), TestCase("DOWN", -10,3)]
        public void VolumeChangeWorksCorrecly(string direction, int units, int volumExpected)
        {
            string result = tv.VolumeChange(direction, units);
           

            Assert.That(result,Is.EqualTo($"Volume: {tv.Volume}"));
            Assert.That(volumExpected, Is.EqualTo(tv.Volume));


        }

        [TestCase("Up",10, 13), TestCase("Down",50,13), TestCase("Boom", -10,13)]
        public void VolumeChangeWorksCorrecly_ButDirectionIsDiffrent(string direction, int units, int volumExpected)
        {
            string result = tv.VolumeChange(direction, units);
           

            Assert.That(result,Is.EqualTo($"Volume: {tv.Volume}"));
            Assert.That(volumExpected, Is.EqualTo(tv.Volume));


        }

        [Test]
        public void TelevisionDeviceToStingMethodWorks()
        {

            string result=tv.ToString();
            Assert.That(result, Is.EqualTo($"TV Device: Samsung, Screen Resolution: 1050x560, Price 1000$"));


        }

    }
}